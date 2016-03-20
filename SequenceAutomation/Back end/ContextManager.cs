using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace SequenceAutomation
{
    public class ContextManager
    {
        /* 
         * TODO
         * Commmenting
         */
        #region Variable declarations
        private delegate bool EnumWindowsProc(IntPtr windowHandle, int callbackVal); // Delegate needed for the EnumWindows method

        private Dictionary<IntPtr, string> openWindows; // Dictionary to store the handle and title of open windows
        private Dictionary<long, Dictionary<string, Dictionary<IntPtr, string>>> currentContext;
        private IntPtr shellWindow;
        private StringBuilder titleBuffer;

        #endregion

        #region Library imports
        // Importation of native libraries
        [DllImport("user32.dll")]
        private static extern bool EnumWindows(EnumWindowsProc enumFunc, int callbackVal);

        [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll")]
        private static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern IntPtr GetShellWindow();

        #endregion

        #region Public methods
        /*
         * Method: ContextManager()
         * Summary: Class constructor for the ContextManager class
         */
        public ContextManager()
        {
            currentContext = new Dictionary<long, Dictionary<string, Dictionary<IntPtr, string>>>();
        }

        /*
         * Method: ContextManager()
         * Summary: Retrieve the context of the program when the enter key is pressed
         * Returns: A dictionary containing key value pairs of relevant context information
         */
        public Dictionary<long, Dictionary<string, Dictionary<IntPtr, string>>> getContext(long time)
        {
            // Loop through the open windows dicionary returned by GetOpenWindows
            foreach (KeyValuePair<IntPtr, string> window in GetOpenWindows())
            {
                IntPtr handle = window.Key; // Store the window handle
                string title = window.Value; // Store the window title 

                // If the contextDictionary contains no entry for the current elapsed time, create one
                if (!currentContext.ContainsKey(time))
                {
                    currentContext.Add(time, new Dictionary<string, Dictionary<IntPtr, string>>());

                    // If the contextDictionary contains no context at the current elapsed time, create one
                    if (!currentContext[time].ContainsKey("Open windows"))
                    {
                        currentContext[time].Add("Open windows", new Dictionary<IntPtr, string>());
                    }
                }

                // Add the dictionary of window handles and titles at to the dictionary at the current milisecond under the key "Open Windows"
                currentContext[time]["Open windows"].Add(handle, title);
            }

            return currentContext;
        }

        /* 
         * Method: checkContext()
         * Summary: Checks the current context when called and verifies if it matches the context of the recording
         * Parameter: time - The exact time of the context
         * Parameter: contextDict - The dictionary that stores the context
         * Return: True or false depending on the outcome of the context check
         */
        public bool checkContext(long time, Dictionary<long, Dictionary<string, Dictionary<IntPtr, string>>> contextDict)
        {
            // Initialise the number windows stored in the context and the number of matches to 0
            int numOfContextWindows = 0;
            int numOfMatches = 0;
            // Iterate over the key-value pairs in the context dictionary, then the key value pairs of the
            // first nested dictionary, then the values of the third nested dictionary
            foreach (KeyValuePair<long, Dictionary<string, Dictionary<IntPtr, string>>> kvp in contextDict)
                foreach (KeyValuePair<string, Dictionary<IntPtr, string>> kvp2 in kvp.Value)
                    foreach (KeyValuePair<IntPtr, string> kvp3 in kvp2.Value)
                    {
                        numOfContextWindows += 1;
                        // Get the open windows and compare the results to the ones stored in the
                        // context dictionary
                        foreach (KeyValuePair<IntPtr, string> window in GetOpenWindows())
                        {
                            // If the window stored matches one of the current windows, increment the matches variable by one
                            if (kvp3.Value == window.Value)
                            {
                                numOfMatches += 1;
                            }
                        }
                    }

            Console.WriteLine("Matches");
            Console.WriteLine(numOfMatches);
            Console.WriteLine(numOfContextWindows);
            // If the number of windows listed in the context is equal to the number of matches calculated, return true
            if(numOfContextWindows == numOfMatches)
                return true;
            else
                return false;

        }

        /*
         * Method: GetOpenWindows()
         * Summary: Retrieves information on all windows currently open on the system
         * Returns: Dictionary of the handle and titles of all open windows on the system
         * References: http://www.tcx.be/blog/2006/list-open-windows/
         */
        public Dictionary<IntPtr, string> GetOpenWindows()
        {
            shellWindow = GetShellWindow(); // Get the shell window handle, to be omitted from the dictionary
            openWindows = new Dictionary<IntPtr, string>(); // Initialise the openWindows dictionary

            // The EnumWindows call using the EnumWindowsProc as the first parameter and 0 as the callbackValue
            EnumWindows(delegate (IntPtr windowHandle, int callbackVal)
            {
                // If the window listed is the shell window, ignore it
                // The shell window is used in the background to get the list of windows
                if (windowHandle == shellWindow)
                    return true;

                // If the window is not visible, ignore it
                if (!IsWindowVisible(windowHandle))
                    return true;

                // If the window handle length is 0, ignore it
                int length = GetWindowTextLength(windowHandle);
                if (length == 0)
                    return true;

                titleBuffer = new StringBuilder(length); // Assigning the length to the titleBuffer variable

                // For the window with the given windowHandle, add the text to the titleBuffer until the maximum number of characters (length + 1) has been reached
                GetWindowText(windowHandle, titleBuffer, length + 1);

                openWindows[windowHandle] = titleBuffer.ToString(); // For the entry in the dictionary with the given windowHandle, add the title stored in the titleBuffer

                // Continue execution
                return true;

            }, 0);

            return openWindows;
        }

        #endregion


    }

}