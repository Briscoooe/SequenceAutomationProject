using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

/* 
 * http://www.pinvoke.net/default.aspx/user32/SetWindowsHookEx.html
 * http://www.pinvoke.net/default.aspx/user32/UnhookWindowsHookEx.html
 * http://www.pinvoke.net/default.aspx/user32/CallNextHookEx.html
 * http://www.pinvoke.net/default.aspx/kernel32/getmodulehandle.html?diff=y
 */
namespace SequenceAutomation
{
    class CreateRecording
    {
        public delegate IntPtr HookDelegate(int Code, IntPtr keyActivity, IntPtr keyName);

        private static HookDelegate hookProc;

        public RecordingManager recManager;
        public string contextJson, keysJson;
        public ContextManager contxtManager = new ContextManager();
        private Dictionary<long, Dictionary<IntPtr, string>> contextDict;

        public static IntPtr KEYUP = (IntPtr)0x0101; // Code of the "key up" signal
        public static IntPtr KEYDOWN = (IntPtr)0x0100; // Code of the "key down" signal
        public static int WH_KEYBOARD_LL = 13;
        private Stopwatch watch; // Timer used to trace at which millisecond each key have been pressed
        private Dictionary<long, Dictionary<Keys, IntPtr>> savedKeys; // Recorded keys activity, indexed by the millisecond the have been pressed. The activity is indexed by the concerned key ("Keys" type) and is associated with the activity code (0x0101 for "key up", 0x0100 for "key down").
        private IntPtr hookId; // Hook used to listen to the keyboard

        /*
         * Constructor 
         */
        public CreateRecording()
        {
            savedKeys = new Dictionary<long, Dictionary<Keys, IntPtr>>();
            contextDict = new Dictionary<long, Dictionary<IntPtr, string>>();
            watch = new Stopwatch();
            hookProc = new HookDelegate(onActivity);
        }

        public void Reset()
        {
            watch.Restart();
            savedKeys.Clear();
        }

        /*
         * method Start()
         * Description : starts to save the keyboard inputs.
         */

        public void Start()
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule) // Get the actual thread
            {
                // Installs a hook to the keyboard (the "13" params means "keyboard", see the link above for the codes), by saying "Hey, I want the function 
                //'onActivity' being called at each activity. You can find this function in the actual thread (GetModuleHandle(curModule.ModuleName)), and you listen to the 
                //keyboard activity of ALL the treads (code : 0)

                hookId = SetWindowsHookEx(WH_KEYBOARD_LL, hookProc, GetModuleHandle(curModule.ModuleName), 0);
            }
            watch.Start(); // Starts the timer
        }

        /*
         * method Stop()
         * Description : stops to save the keyboard inputs.
         * Returns : the recorded keys activity since Start().
         */
        public Dictionary<long, Dictionary<Keys, IntPtr>> Stop()
        {
            watch.Stop(); // Stops the timer
            UnhookWindowsHookEx(hookId); //Uninstalls the hook of the keyboard (the one we installed in Start())
            return savedKeys;
        }

        public string getJson()
        {
            recManager = new RecordingManager(savedKeys, contextDict);
            keysJson = recManager.toJson();
            return keysJson;
        }

        /*
         * method onActivity()
         * Description : function called each time there is a keyboard activity (key up of key down). Saves the detected activity and the time at the moment it have been done.
         * @validityCode : Validity code. If >= 0, we can use the information, otherwise we have to let it.
         * @keyActivity : Activity that have been detected (keyup or keydown). Must be compared to KeysSaver.KEYUP and KeysSaver.KEYDOWN to see what activity it is.
         * @keyName : (once read and casted) Key of the keyboard that have been triggered.
         */
        private IntPtr onActivity(int validityCode, IntPtr keyActivity, IntPtr keyName)
        {
            if (validityCode >= 0) //We check the validity of the informations. If >= 0, we can use them.
            {
                long time = watch.ElapsedMilliseconds; //Number of milliseconds elapsed since we called the Start() method
                int vkCode = Marshal.ReadInt32(keyName); //We read the value associated with the pointer (?)
                Keys key = (Keys)vkCode; //We convert the int to the Keys type
                if(key.ToString() == "Return" && keyActivity.ToString() == "256")
                {
                    
                    foreach (KeyValuePair<IntPtr, string> window in contxtManager.GetOpenWindows())
                    {
                        IntPtr handle = window.Key;
                        string title = window.Value;

                        if(!contextDict.ContainsKey(time))
                        {
                            contextDict.Add(time, new Dictionary<IntPtr, string>());
                        }

                        contextDict[time].Add(handle, title);

                    }

                }
                if (!savedKeys.ContainsKey(time))
                {
                    // If no key activity have been detected for this millisecond yet, we create the entry in the savedKeys Dictionary
                    savedKeys.Add(time, new Dictionary<Keys, IntPtr>());
                }
                
                Console.WriteLine("\nkey: {0}", key.ToString());
                Console.WriteLine("keyActivity: {0}", keyActivity.ToString());
                Console.WriteLine("time: {0}", time.ToString());
                savedKeys[time].Add(key, keyActivity); //Saves the key and the activity
            }
            return CallNextHookEx(IntPtr.Zero, validityCode, keyActivity, keyName); //Bubbles the informations for others applications using similar hooks
        }

        // Importation of native libraries
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int hookId, HookDelegate hookProc, IntPtr hookInstance, uint threadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hookHandle);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hookHandle, int validityCode, IntPtr keyActivity, IntPtr keyName);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string handle);

    }
}
