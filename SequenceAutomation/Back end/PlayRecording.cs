using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

/*
 * References
 * SendInput: http://www.pinvoke.net/default.aspx/user32.SendInput 
 * INPUT structure : https://msdn.microsoft.com/en-us/library/windows/desktop/ms646270(v=vs.85).aspx
 * KEYBDINPUT structure: https://msdn.microsoft.com/en-us/library/windows/desktop/ms646271(v=vs.85).aspx
 * HARDWAREINPUT structure: https://msdn.microsoft.com/en-us/library/windows/desktop/ms646269(v=vs.85).aspx
 * MOUSEINPUT structure: https://msdn.microsoft.com/en-us/library/windows/desktop/ms646273(v=vs.85).asp
 */
namespace SequenceAutomation
{
    #region Stucture declarations

    /*
     * Structure: MOUSEINPUT
     * Summary: A structure to store information about simulated mouse input
     * Note: This structure is not directly used and only exists to be combined with the keyboard and hardware structures, thus allowing the INPUT structure to exist
     */
    public struct MOUSEINPUT
    {
        public int X;
        public int Y;
        public uint MouseData;
        public uint Flags;
        public uint Time;
        public IntPtr ExtraInfo;
    }

    /*
     * Structure: HARDWAREINPUT
     * Summary: A structure to store information about simulated hardware input, other than a keyboard or mouse
     * Note: This structure is not directly used and only exists to be combined with the keyboard and mouse structures, thus allowing the INPUT structure to exist
     */
    public struct HARDWAREINPUT
    {
        public uint Msg;
        public ushort ParamL;
        public ushort ParamH;
    }

    /*
     * Structure: KEYBDINPUT
     * Summary: A structure to store information about simulated keyboard input
     * Member: KeyCode - The key code of the key to be simulated
     * Member: Scan - A hardware scan code for the key
     * Member: Flags - The key action, either key up or key down
     * Member: Time - The timestamp for the key even in milliseconds
     * Member: ExtraInfo - An additional value associated with the keystroke
     */
    public struct KEYBDINPUT
    {
        public ushort KeyCode;
        public ushort Scan; 
        public uint Flags;
        public uint Time; 
        public IntPtr ExtraInfo;
    }

    /*
     * Structure: MOUSEKEYBDHARDWAREINPUT
     * Summary: The union of the Mouse, Keyboard and Hardware structures
     * Member: Mouse - An instance of the Mouse structure
     * Member: Keyboard - An instance of the Keyboard structure
     * Member: Hardware - An instance of the Hardware structure
     */
    [StructLayout(LayoutKind.Explicit)]
    public struct MOUSEKEYBDHARDWAREINPUT
    {
        [FieldOffset(0)]
        public MOUSEINPUT Mouse;

        [FieldOffset(0)]
        public KEYBDINPUT Keyboard;

        [FieldOffset(0)]
        public HARDWAREINPUT Hardware;
    }

    /*
     * Structure: INPUT
     * Summary: Used by the sendInput method to execute mouse, keyboard or hardware actions
     * Member: Type - The type of input, 0 for mouse, 1 for keyboard, 2 for hardware
     * Member: Data - The union of the Mouse, Keyboard and Hardware structures
     */
    public struct INPUT
    {
        public uint Type;
        public MOUSEKEYBDHARDWAREINPUT Data; 
    }

    #endregion

    public class PlayRecording
    {
        #region Variable declarations

        public bool stopPlayback;
        private RecordingManager recManager;
        private float timeFactor; // The time factor used to determine the speed at which the recording should play
        private Dictionary<long, Dictionary<Keys, IntPtr>> keysDict; // Dictionary to store each key pressed, the action (up or down) and the time at which the action was recorded
        private Dictionary<long, Dictionary<string, Dictionary<IntPtr, string>>> contextDict; // Dictionary to store the context at each critical moment
        private Dictionary<long, Dictionary<IntPtr, Dictionary<string, int>>> mouseDict;
        private SortedDictionary<long, INPUT[]> keysToPlay; // Dictionary that stores the inputs to be be played. The inputs are determined from the keysDict dictionary
        private Stopwatch watch; // Timer used to compare the times of the recorded keys with the currently elapsed time
        private long currentEntry; // While playing, keeps the last keysDict frame that have been played.
        
        #endregion

        #region Libary importations

        // Importation of native libraries
        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint SendInput(uint numberOfInputs, INPUT[] inputs, int sizeOfInputStructure);

        [DllImport("kernel32.dll")]
        static extern uint GetLastError();

        #endregion

        #region Public methods

        /*
         * Method:  PlayRecording
         * Summary: Class constructor
         * Parameter: inputJson - The JSON string that stores all keys and contexts
         */
        public PlayRecording(string inputJson, float timeFactor)
        {
            currentEntry = 0;
            this.timeFactor = timeFactor;
            stopPlayback = false;
            watch = new Stopwatch();

            // Instantiate the RecordingManager with the input JSON string and initialise the dictionaries accordingly
            recManager = new RecordingManager(inputJson);
            recManager.getDictionaries(inputJson);
            keysDict = recManager.keysDict;
            contextDict = recManager.contextDict;
            mouseDict = recManager.mouseDict;


            // Initialise the keysToPlay dictoinary and load the keys into it
            keysToPlay = new SortedDictionary<long, INPUT[]>();
            prepareKeysToPlay();
        }

        /*
         * Method: Start()
         * Summary: Begins the execution of the inputs in the keysToPlay dictionary
         */
        public int Start()
        {
            currentEntry = 0; 
            watch.Reset();
            watch.Start();
            int errors = 0;
            // The keysToPlay enumerator, used to jump from one entry to another
            IEnumerator<long> enumerator = keysToPlay.Keys.GetEnumerator(); 

            // Moves the next entry in the keysToPlay dictionary
            while (enumerator.MoveNext())
            {
                // Foreach time key in the context dictionary
                foreach (KeyValuePair<long, Dictionary<string, Dictionary<IntPtr, string>>> kvp2 in contextDict)
                {
                    // Check if the timeKey (currentEntry) is also present in the contextDictionary, symbolising that a context entry is present for the exact time
                    if (currentEntry == kvp2.Key)
                    {
                        // Check the current context against the stored context
                        if (ContextManager.checkContext(currentEntry, contextDict))
                        {
                            break;
                        }

                        else
                        {
                            errors += 1;
                            break;
                        }
                    }
                }

                while (watch.ElapsedTicks < (enumerator.Current * timeFactor)) { } // Wait until the exact milisecond

                if (!stopPlayback)
                {

                    // The sendInput call, utilising three parameters
                    // (uint)keysToPlay[enumerator.Current].Length is the number of INPUT structures in the keysToPlay array
                    // keysToPlay[enumerator.Current] is the current entry in the array of INPUT structures, keysToPlay
                    // Marshal.SizeOf(typeof(INPUT)) is the size of an INPUT structure
                    // The return parameter, err, is the status code of the sendInput call, returns 1 if successful, 0 if not
                    uint err = SendInput((uint)keysToPlay[enumerator.Current].Length, keysToPlay[enumerator.Current], Marshal.SizeOf(typeof(INPUT)));
                }

                currentEntry = enumerator.Current; //Updates the currentEntry to the entry just played
            }
            
            return errors;
        }

        /*
         * Method: Stop()
         * Summary: Stops execution of keystrokes
         */
        public bool Stop()
        {
            watch.Stop();
            return true;
        }

        #endregion

        #region Private methods

        /*
         * Method: prepareKeysToPlay()
         * Summary: Translates the keysDict entries into INPUT structures that are necessary for the sendInput call
         */
        private void prepareKeysToPlay()
        {
            // For each key-value pair in the keysDict dictionary
            foreach (KeyValuePair<long, Dictionary<Keys, IntPtr>> kvp in keysDict)
            {
                // Create a list of inputs
                List<INPUT> inputs = new List<INPUT>();

                // For each key-value pair in the kvp.Values, i.e. the keys played
                foreach (KeyValuePair<Keys, IntPtr> kvp3 in kvp.Value)
                {
                    // Add the key and a pointer to the key action (up or down) to the list of INPUTS
                    inputs.Add(loadKey(kvp3.Key, getFlags(kvp3.Value)));
                }

                // Load the time value (kvp.Key) and list of inputs to the keysToPlay dictionary
                keysToPlay.Add(kvp.Key, inputs.ToArray());
            }

            foreach (KeyValuePair<long, Dictionary<IntPtr, Dictionary<string, int>>> mouseKvp in mouseDict)
            {
                List<INPUT> inputs = new List<INPUT>();

                foreach (KeyValuePair<IntPtr, Dictionary<string, int>> mouseKvp2 in mouseKvp.Value)
                {
                    int x = 0;
                    int y = 0;
                    foreach (KeyValuePair<string, int> mouseKvp3 in mouseKvp2.Value)
                    {
                        if (mouseKvp3.Key == "X")
                            x = Convert.ToInt32(mouseKvp3.Value);
                        if (mouseKvp3.Key == "Y")
                            y = Convert.ToInt32(mouseKvp3.Value);
                    }

                    x = 65535 * x / Screen.PrimaryScreen.WorkingArea.Width;
                    y = 65535 * y / Screen.PrimaryScreen.WorkingArea.Height;
                    inputs.Add(loadMouse(x, y, getFlags(mouseKvp2.Key) | 0x8000 ));
                }
                keysToPlay.Add(mouseKvp.Key, inputs.ToArray());
            }
        }

        /*
         * Method: intPtrToFlags()
         * Summary: Translate the IntPtr reference for the key or mouse activity to an unsigned integer flag necessary for storage in the INPUT list
         * Parameter: activity - The key or mouse activity (up, down, click etc.)
         * Return: An insigned integer representing either the appropriate hex code
         */
         
        private uint getFlags(IntPtr activity)
        {
            string activityInt = Convert.ToString(activity);
            switch(activityInt)
            {
                case "256":
                    return 0;
                case "257":
                    return 0x0002;
                case "512":
                    return 0x0001;
                case "513":
                    return 0x0002;
                case "514":
                    return 0x0004;
                case "516":
                    return 0x0008;
                case "517":
                    return 0x0010;
                case "522":
                    return 0x0800;
                default:
                    return 0;
            }
        }

        /*
         * Method: loadKey()
         * Summary: Transforms the Key and key activity into an INPUT data structure, as declared at the beginning of this class
         * Parameter: key - A Key data type representing the key pressed
         * Parameter: flags - Flags representing the key activity (key up or key down)
         * Return: An INPUT structure comprising the necessary information as specified in the above data structure
         */
        private INPUT loadKey(Keys key, uint flags)
        {
            return new INPUT
            {
                Type = 1, // 1 represents a keyboard event
                Data =
                {
                    // Creating a KEYBDINPUT structure as per the definition at the beginning of this file
                    Keyboard = new KEYBDINPUT
                    {
                        KeyCode = (ushort)key,
                        Scan = 0,
                        Flags = flags,
                        Time = 0,
                        ExtraInfo = IntPtr.Zero
                    }
                }
            };
        }


        private INPUT loadMouse(int x, int y, uint flags)
        {
            return new INPUT
            {
                Type = 0, // 0 represents a mouse event
                Data =
                {
                    // Creating a MOUSEINPUT structure as per the definition at the beginning of this file
                    Mouse = new MOUSEINPUT
                    {
                        X = x,
                        Y = y,
                        MouseData = 0,
                        Flags = flags,
                        Time = 0,
                        ExtraInfo = IntPtr.Zero
                    }
                }
            };
        }

        #endregion
    }

}