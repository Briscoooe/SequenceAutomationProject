using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

/* 
 * References
 * SetWindowsHookEx: http://www.pinvoke.net/default.aspx/user32/SetWindowsHookEx.html
 * UnhookWindowsHookEx: http://www.pinvoke.net/default.aspx/user32/UnhookWindowsHookEx.html
 * CallNextHookEx: http://www.pinvoke.net/default.aspx/user32/CallNextHookEx.html
 * GetModuleHandle: http://www.pinvoke.net/default.aspx/kernel32/getmodulehandle.html?diff=y
 */
namespace SequenceAutomation
{
    public class CreateRecording
    {
        #region Variable declarations

        public delegate IntPtr HookDelegate(int validityCode, IntPtr keyActivity, IntPtr keyCode); // The delegate used in the hook process
        private RecordingManager recManager;
        private ContextManager contextManager;
        private HookDelegate callbackDelegate; // The delegate variable passed as a parameter to the SetWindowsHookEx function
        private Stopwatch watch; // Stopwatch used to track the precise timing of each key press
        private Dictionary<long, Dictionary<Keys, IntPtr>> savedKeys; // Dictionary to store each key pressed, the action (up or down) and the time at which the action was recorded
        private Dictionary<long, Dictionary<string, Dictionary<IntPtr, string>>> contextDict; // Dictionary to store the context at each critical moment
        public static IntPtr KEYUP = (IntPtr)0x0101; // Code of the key up signal
        public static IntPtr KEYDOWN = (IntPtr)0x0100; // Code of the key down signal
        public static int WH_KEYBOARD_LL = 13; // Code for the global keyboard hook type
        private static IntPtr hookId = IntPtr.Zero; // The ID of the hook used to listen to the keyboard
        public string keysJson, recDescription;

        #endregion

        #region Library imports

        // Importation of native libraries
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int hookId, HookDelegate hookProc, IntPtr hookInstance, uint threadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hookHandle);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hookHandle, int validityCode, IntPtr keyActivity, IntPtr keyCode);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string handle);

        [DllImport("kernel32.dll")]
        static extern IntPtr LoadLibrary(string lpFileName);

        #endregion

        #region Public methods

        /*
         * Method: CreateRecording()
         * Summary: The constructor for the CreateRecording class
         */
        public CreateRecording()
        {
            contextManager = new ContextManager();
            savedKeys = new Dictionary<long, Dictionary<Keys, IntPtr>>();
            contextDict = new Dictionary<long, Dictionary<string, Dictionary<IntPtr, string>>>();
            watch = new Stopwatch();
        }

        /*
         * Method: Start()
         * Summary: Hooks the keyboard to the program and begins recording each key press 
         */
        public void Start()
        {
            // If there is still a hook attached, throw an exception
            // This had to be included as I was having huge problems as a result of multiple hook/unhook operations in a single execution
            // This line ensures that the program will not try set another hook if one already exists
            if (callbackDelegate != null)
                throw new InvalidOperationException("Cannot hook more than once");

            IntPtr hInstance = LoadLibrary("User32"); // Loads the User32 library and returns the module value, assigning it to the hInstance variable
            callbackDelegate = new HookDelegate(onActivity); // Initialises the callbackDelegate using the onActivity method

            // Installs the hook to the keyboard using the following parameters
            // WH_KEYBOARD_LL stores the value 13, which is the code for the keyboard hook type
            // callbackDelegate is the variable, of type HookDelegate, which passes a reference to the onActivity method
            // hInstance stores the handle of the module thread
            // 0 is the thread ID. It tells the hook to listen to the activity of all threads, not just the thead containing the program itself
            // The call returns an IntPtr which is stored in the hookId variable. This is the ID of the hook which is later used to remove the hook.
            hookId = SetWindowsHookEx(WH_KEYBOARD_LL, callbackDelegate, hInstance, 0);
            watch.Start(); // Starts the timer
        }

        /*
         * Method: Stop()
         * Summary: Stops recording and saves the keys to the savedKeys dictionary
         * Return: The merged JSON containing all keys recorded and the context of each "Return" key press
         */
        public string Stop()
        {
            watch.Stop();
            UnhookWindowsHookEx(hookId); // Removes the keyboard hook

            // Merge the context and keys dictionaries into a single JSON string and return it
            recManager = new RecordingManager(savedKeys, contextDict);
            keysJson = recManager.keysJson;
            return keysJson;
        }

        #endregion

        #region Private methods

        /*
         * Method: onActivity()
         * Summary: Method called each time a key action (key up or down) happens. Each key action is recorded along with the time at which it occured
         * Parameter: validityCode - Checks if the call is valid. If this is greater or equal to 0, i.e. successful, execution will continue
         * Parameter: keyActivity - The key activity. Either KEYUP or KEYDOWN
         * Parameter: keyCode - The code of the key pressed
         * Returns: IntPtr
         */
        private IntPtr onActivity(int validityCode, IntPtr keyActivity, IntPtr keyCode)
        {
            if (validityCode >= 0)
            {
                long time = watch.ElapsedMilliseconds; // Number of milliseconds elapsed since the stopwatch began
                Keys keyName = (Keys)(Marshal.ReadInt32(keyCode)); // Convert the integer key value to the Keys data type

                // If the enter key is pressed down, get the current context
                if (keyName.ToString() == "Return" && keyActivity.ToString() == "256")
                    contextDict = contextManager.getContext(time);

                // If the savedKeys dictionary contains no entry for the current elapsed time, create one
                if (!savedKeys.ContainsKey(time))
                    savedKeys.Add(time, new Dictionary<Keys, IntPtr>());

                savedKeys[time].Add(keyName, keyActivity); //Saves the key and the activity
            }

            // Passes the hook information to the next hook procedure in the current hook chain
            return CallNextHookEx(hookId, validityCode, keyActivity, keyCode);
        }

        #endregion
    }
}