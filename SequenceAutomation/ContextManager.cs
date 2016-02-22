using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace SequenceAutomation
{
    public class ContextManager
    {
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

        public bool checkContext(long time, Dictionary<long, Dictionary<string, Dictionary<IntPtr, string>>> contextDict)
        {
            int countOpenWindows = 0;
            int matches = 0;
            foreach (KeyValuePair<long, Dictionary<string, Dictionary<IntPtr, string>>> kvp in contextDict)
                foreach (KeyValuePair<string, Dictionary<IntPtr, string>> kvp2 in kvp.Value)
                    foreach (KeyValuePair<IntPtr, string> kvp3 in kvp2.Value)
                        foreach (KeyValuePair<IntPtr, string> window in GetOpenWindows())
                        {
                            string title = window.Value; // Store the window title
                            Console.WriteLine("\n\nTitle: {0}", title);
                            Console.WriteLine("kvp3.Value: {0}", kvp3.Value, ToString());
                            if (kvp3.Value == title)
                            {
                                matches += 1;
                            }

                            countOpenWindows += 1;
                        }

            countOpenWindows /= 2;

            if(countOpenWindows == matches)
            {
                return true;
            }

            else
            {
                return false;
            }

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