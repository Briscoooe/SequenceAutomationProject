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
 */
namespace SequenceAutomation
{
    public class CreateRecording
    {
        #region Variable declarations

        private delegate IntPtr HookDelegate(int nCode, IntPtr wParam, IntPtr lParam); // The delegate used in the hook process
        private HookDelegate keyboardDelegate; // The delegate variable passed as a parameter to the SetWindowsHookEx function for the keyboard
        private HookDelegate mouseDelegate;
        private Stopwatch watch; // Stopwatch used to track the precise timing of each key press
        private Dictionary<string, Dictionary<long, Dictionary<Keys, IntPtr>>> savedKeys; // Dictionary to store each key pressed, the action (up or down) and the time at which the action was recorded
        private Dictionary<string, Dictionary<long, Dictionary<string, Dictionary<IntPtr, string>>>> contextDict; // Dictionary to store the context at each critical moment
        private Dictionary<string, Dictionary<long, Dictionary<IntPtr, Dictionary<string, int>>>> mouseActions;
        private static IntPtr KEYUP = (IntPtr)0x0101; // Code of the key up signal
        private static IntPtr KEYDOWN = (IntPtr)0x0100; // Code of the key down signal
        private static int WH_KEYBOARD_LL = 13; // Code for the global keyboard hook type
        private static int WH_MOUSE_LL = 14; // Code for the global mouse hook type
        private static IntPtr keyboardHookId = IntPtr.Zero; // The ID of the hook used to listen to the keyboard
        private static IntPtr mouseHookId = IntPtr.Zero; // The ID of the hook used to listen to the mouse
        private string keysJson;

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
            savedKeys = new Dictionary<string, Dictionary<long, Dictionary<Keys, IntPtr>>>();
            savedKeys.Add("Actions", new Dictionary<long, Dictionary<Keys, IntPtr>>());
            contextDict = new Dictionary<string, Dictionary<long, Dictionary<string, Dictionary<IntPtr, string>>>>();
            mouseActions = new Dictionary<string, Dictionary<long, Dictionary<IntPtr, Dictionary<string, int>>>>();
            mouseActions.Add("Actions", new Dictionary<long, Dictionary<IntPtr, Dictionary<string, int>>>());
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
            if (keyboardDelegate != null)
                throw new InvalidOperationException("Cannot hook more than once");


            if (mouseDelegate != null)
                throw new InvalidOperationException("Cannot hook more than once");

            IntPtr hInstance = LoadLibrary("User32"); // Loads the User32 library and returns the module value, assigning it to the hInstance variable
            keyboardDelegate = new HookDelegate(onKeyActivity); // Initialises the keyboardDelegate using the onKeyActivity method
            mouseDelegate = new HookDelegate(onMouseActivity);

            // Installs the hook to the keyboard using the following parameters
            // WH_KEYBOARD_LL stores the value 13, which is the code for the keyboard hook type
            // keyboardDelegate is the variable, of type HookDelegate, which passes a reference to the onKeyActivity method
            // hInstance stores the handle of the module thread
            // 0 is the thread ID. It tells the hook to listen to the activity of all threads, not just the thead containing the program itself
            // The call returns an IntPtr which is stored in the hookId variable. This is the ID of the hook which is later used to remove the hook.
            keyboardHookId = SetWindowsHookEx(WH_KEYBOARD_LL, keyboardDelegate, hInstance, 0);
            mouseHookId = SetWindowsHookEx(WH_MOUSE_LL, mouseDelegate, hInstance, 0);

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
            UnhookWindowsHookEx(keyboardHookId); // Removes the keyboard hook
            UnhookWindowsHookEx(mouseHookId);
            // Merge the context and keys dictionaries into a single JSON string and return it
            keysJson = RecordingManager.mergeToJson(savedKeys, contextDict, mouseActions);
            return keysJson;
        }

        #endregion

        #region Private methods

        /*
         * Method: onKeyActivity()
         * Summary: Method called each time a key action (key up or down) happens. Each key action is recorded along with the time at which it occured
         * Parameter: validityCode - Checks if the call is valid. If this is greater or equal to 0, i.e. successful, execution will continue
         * Parameter: keyActivity - The key activity. Either KEYUP or KEYDOWN
         * Parameter: keyCode - The code of the key pressed
         * Returns: The next hook in the chain
         */
        private IntPtr onKeyActivity(int validityCode, IntPtr keyActivity, IntPtr keyCode)
        {
            if (validityCode >= 0)
            {
                long time = watch.ElapsedTicks; // Number of milliseconds elapsed since the stopwatch began
                Keys keyName = (Keys)(Marshal.ReadInt32(keyCode)); // Convert the integer key value to the Keys data type

                // If the enter key is pressed down, get the current context
                if (keyName.ToString() == "Return" && keyActivity.ToString() == "256")
                    contextDict = ContextManager.getContext(time);

                // If the savedKeys dictionary contains no entry for the current elapsed time, create one

                if(!savedKeys["Actions"].ContainsKey(time))
                        savedKeys["Actions"].Add(time, new Dictionary<Keys, IntPtr>());

                savedKeys["Actions"][time].Add(keyName, keyActivity); //Saves the key and the activity
            }

            // Passes the hook information to the next hook procedure in the current hook chain
            return CallNextHookEx(keyboardHookId, validityCode, keyActivity, keyCode);
        }

        private IntPtr onMouseActivity(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                
                long time = watch.ElapsedTicks; // Number of milliseconds elapsed since the stopwatch began
                string mouseAction = Convert.ToString((MouseMessages)wParam);

                if (mouseAction == "WM_LBUTTONDOWN")
                    contextDict = ContextManager.getContext(time);

                if (!mouseActions["Actions"].ContainsKey(time))
                {
                    mouseActions["Actions"].Add(time, new Dictionary<IntPtr, Dictionary<string, int>>());

                    if (!mouseActions["Actions"][time].ContainsKey(wParam))
                        mouseActions["Actions"][time].Add(wParam, new Dictionary<string, int>());
                }

                MSLLHOOKSTRUCT hookStruct = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));
                mouseActions["Actions"][time][wParam].Add("X", hookStruct.pt.x);
                mouseActions["Actions"][time][wParam].Add("Y", hookStruct.pt.y);
            }
            return CallNextHookEx(mouseHookId, nCode, wParam, lParam);
        }


        #endregion

        #region Mouse structures

        public enum MouseMessages
        {
            WM_LBUTTONDOWN = 0x0201,
            WM_LBUTTONUP = 0x0202,
            WM_MOUSEMOVE = 0x0200,
            WM_MOUSEWHEEL = 0x020A,
            WM_RBUTTONDOWN = 0x0204,
            WM_RBUTTONUP = 0x0205
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct POINT
        {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MSLLHOOKSTRUCT
        {
            public POINT pt;
            public uint mouseData;
            public uint flags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        #endregion
    }
}