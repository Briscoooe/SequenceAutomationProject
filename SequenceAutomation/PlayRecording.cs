using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

/*
 * References
 * http://www.pinvoke.net/default.aspx/user32.SendInput */
namespace SequenceAutomation
{
    #region Stucture declarations
    /*
     * Struct MOUSEINPUT
     * Mouse internal input struct
     * See : https://msdn.microsoft.com/en-us/library/windows/desktop/ms646273(v=vs.85).aspx
     */
    internal struct MOUSEINPUT
    {
        public int X;
        public int Y;
        public uint MouseData;
        public uint Flags;
        public uint Time;
        public IntPtr ExtraInfo;
    }

    /*
     * Struct HARDWAREINPUT
     * Hardware internal input struct
     * See : https://msdn.microsoft.com/en-us/library/windows/desktop/ms646269(v=vs.85).aspx
     */
    internal struct HARDWAREINPUT
    {
        public uint Msg;
        public ushort ParamL;
        public ushort ParamH;
    }

    /*
     * Struct KEYBDINPUT
     * Keyboard internal input struct (Yes, actually only this one is used, but we need the 2 others to properly send inputs)
     * See : https://msdn.microsoft.com/en-us/library/windows/desktop/ms646271(v=vs.85).aspx
     */
    internal struct KEYBDINPUT
    {
        public ushort KeyCode; //The keycode of the triggered key. See https://msdn.microsoft.com/en-us/library/windows/desktop/dd375731(v=vs.85).aspx
        public ushort Scan; //Unicode character in some keys (when flags are saying "hey, this is unicode"). Ununsed in our case.
        public uint Flags; //Type of action (keyup or keydown). Specifies too if the key is a "special" key.
        public uint Time; //Timestamp of the event. Ununsed in our case.
        public IntPtr ExtraInfo; //Extra information (yeah, it wasn't that hard to guess). Ununsed in our case.
    }

    /*
     * Struct MOUSEKEYBDHARDWAREINPUT
     * Union struct for key sending 
     * See : https://msdn.microsoft.com/en-us/library/windows/desktop/ms646270%28v=vs.85%29.aspx
     */

    [StructLayout(LayoutKind.Explicit)]
    internal struct MOUSEKEYBDHARDWAREINPUT
    {
        [FieldOffset(0)]
        public MOUSEINPUT Mouse;

        [FieldOffset(0)]
        public KEYBDINPUT Keyboard;

        [FieldOffset(0)]
        public HARDWAREINPUT Hardware;
    }

    /*
     * Struct INPUT
     * Input internal struct for key sending 
     * See : https://msdn.microsoft.com/en-us/library/windows/desktop/ms646270%28v=vs.85%29.aspx
     */

    internal struct INPUT
    {
        public uint Type; //Type of the input (0 = Mouse, 1 = Keyboard, 2 = Hardware)
        public MOUSEKEYBDHARDWAREINPUT Data; //The union of "Mouse/Keyboard/Hardware". Only one is read, depending of the type.
    }

    #endregion

    class PlayRecording
    {
        #region Variable declarations

        public static IntPtr KEYUP = (IntPtr)0x0101; // Code of the "key up" signal
        public static IntPtr KEYDOWN = (IntPtr)0x0100; // Code of the "key down" signal
        private int timeFactor = 2; // The time factor used to determine the speed at which the recording should play
        //private Dictionary<long, Dictionary<Keys, IntPtr>> inputKeys; // Keys to play, with the timing. See KeysSaver.savedKeys for more informations.
        private string inputJson;
        private Dictionary<long, INPUT[]> keysToPlay; // The inputs that will be played. This is a "translation" of inputKeys, transforming Keys into Inputs.
        private Stopwatch watch; // Timer used to respect the strokes timing.
        private long currentFrame; // While playing, keeps the last inputKeys frame that have been played.

        private RecordingManager recManager;
        
        #endregion

        #region Libary importations

        // Importation of native libraries
        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint SendInput(uint numberOfInputs, INPUT[] inputs, int sizeOfInputStructure);

        [DllImport("kernel32.dll")]
        static extern uint GetLastError();

        #endregion

        #region Public methods

        /*
         * Method:  PlayRecording
         * Summary: Class constructor
         * Parameter: 
         */
        //public PlayRecording(Dictionary<long, Dictionary<Keys, IntPtr>> inputKeys)
        public PlayRecording(string inputJson)
        {
            recManager = new RecordingManager();
            this.inputJson = inputJson;
            //keysToPlay = new Dictionary<long, INPUT[]>();
            watch = new Stopwatch();
            currentFrame = 0;
            loadkeysToPlay();
        }

        /*
         * Method: Start()
         * Summary: starts to play the keyboard inputs.
         */
        public void Start()
        {
            currentFrame = 0;  //currentFrame is 0 at the beginning.
            watch.Reset(); //Resets the timer
            watch.Start(); //Starts the timer (yeah, pretty obvious)
            IEnumerator<long> enumerator = keysToPlay.Keys.GetEnumerator(); //The keysToPlay enumerator. Used to jump from one frame to another.
            while (enumerator.MoveNext()) //Moves the pointer of the keysToPlay dictionary to the next entry (so, to the next frame).
            {
                /* The thread sleeps until the millisecond before the next frame. For exemple, if there is an input at the 42th millisecond,
                 * the thread will sleep to the 41st millisecond. Seems optionnal, since we have a "while" that waits, but it allows to consume less 
                 * ressources. Also, in a too long "while", the processor tends to "forget" the thread for a long time, resulting in desyncs. */
                Thread.Sleep(((int)(enumerator.Current - currentFrame - 1)) * timeFactor); 
                while (watch.ElapsedMilliseconds < enumerator.Current) { } //We wait until the very precise millisecond 
                uint err = SendInput((uint)keysToPlay[enumerator.Current].Length, keysToPlay[enumerator.Current], Marshal.SizeOf(typeof(INPUT))); //Simulate the inputs of the actual frame

                Console.WriteLine(enumerator.Current.ToString());
                currentFrame = enumerator.Current; //Updates the currentFrame to the frame we just played.
            }
        }

        /*
         * Method: Stop()
         * Summary: stops to play the keyboard inputs.
         */
        public void Stop()
        {
            watch.Stop(); //Stops the timer.
        }

        #endregion

        #region Private methods

        /*
         * Method: loadkeysToPlay()
         * Summary: Transforms the inputKeys dictionnary into a sequence of inputs. Also, pre-load the inputs we need (loading takes a bit of time that could lead to desyncs).
         */
        private void loadkeysToPlay()
        {
            foreach (KeyValuePair<long, Dictionary<Keys, IntPtr>> kvp in recManager.parseJson(inputJson))
            {
                List<INPUT> inputs = new List<INPUT>(); //For each recorded frame, creates a list of inputs
                foreach (KeyValuePair<Keys, IntPtr> kvp2 in kvp.Value)
                {
                    inputs.Add(loadKey(kvp2.Key, intPtrToFlags(kvp2.Value))); //Load the key that will be played and adds it to the list. 
                }
                keysToPlay.Add(kvp.Key, inputs.ToArray());//Transforms the list into an array and adds it to the keysToPlay "partition".
            }
        }

        /*
         * Method: intPtrToFlags()
         * Summary: Translate the IntPtr which references the activity (keydown/keyup) into input flags.
         */
        private uint intPtrToFlags(IntPtr activity)
        {
            if (activity == KEYDOWN) //Todo : extended keys
            {
                return 0;
            }
            if (activity == KEYUP)
            {
                return 0x0002;
            }
            return 0;
        }

        /*
         * Method: loadKey()
         * Summary: Transforms the Key into a sendable input (using the above structures).
         */
        private INPUT loadKey(Keys key, uint flags)
        {
            return new INPUT
            {
                Type = 1, //1 = "this is a keyboad event"
                Data =
                {
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

        #endregion
    }

}