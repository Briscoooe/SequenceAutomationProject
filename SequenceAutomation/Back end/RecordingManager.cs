using System;
using System.Collections.Generic;
using System.Windows.Forms;

// External library used: http://www.newtonsoft.com/json
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace SequenceAutomation
{
    public class RecordingManager
    {
        /* 
         * TODO
         * Commmenting
         */
        #region Variable declaration

        public Dictionary<long, Dictionary<Keys, IntPtr>> keysDict; // Dictionary to store the savedKeys in the format (time: <keyTitle, action>)
        public Dictionary<long, Dictionary<string, Dictionary<IntPtr, string>>> contextDict;  // Dictionary to store the context in the format (time: <windowHandle, windowTitle>)
        public Random randomNum;
        public string keysJson, recTitle, recDescription, recId, recUsername;

        #endregion

        #region Public methods

        public string Title
        {
            get { return recTitle; }
        }

        public string Description
        {
            get { return recDescription; }
        }

        public string Id
        {
            get { return recId; }
        }

        public string Username
        {
            get { return recUsername; }
        }

        /*
         * Method: RecordingManager()
         * Summary: Class Constructor
         */
        public RecordingManager(string inputJson)
        {
            dynamic recObj = JsonConvert.DeserializeObject(inputJson);
            recTitle = recObj.Name;
            recDescription = recObj.Desc;
            recId = recObj.recId;
            recUsername = recObj.userName;
            getDictionaries(inputJson);
        }

        public RecordingManager() {}

        /*
         * Method: RecordingManager()
         * Summary: Class Constructor
         * Parameter: keysDict - The dictionary of keys pressed, the key action, and the time it was pressed
         * Parameter: contextDict - The context of each "Return" key press
         */
        public RecordingManager(Dictionary<long, Dictionary<Keys, IntPtr>> keysDict, Dictionary<long, Dictionary<string, Dictionary<IntPtr, string>>> contextDict)
        {
            this.keysDict = keysDict;
            this.contextDict = contextDict;
            mergeToJson();
        }

        public string addInformation(string keysString, string title, string description)
        {
            Guid guid = Guid.NewGuid();
            string recId = guid.ToString();
            dynamic tempObj = JsonConvert.DeserializeObject(keysString);
            tempObj.Name = title;
            tempObj.Desc = description;
            tempObj.recId = recId;
            tempObj.userName = Properties.Settings.Default.currentUser;

            return JsonConvert.SerializeObject(tempObj);
        }

        public bool validateJson(string recJson)
        {
            try
            {
                Recording recording = new Recording(recJson);
                Console.WriteLine(recording.Title);
                Console.WriteLine(recording.Description);
                Console.WriteLine(recording.Id);
                Console.WriteLine(recording.Username);

                if (recording.Title == null || recording.Description == null 
                    || recording.Id == null || recording.Username == null)
                {
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        /*
         * Method: toJson()
         * Summary: Converts the savedKeys and context Dictionaries to a single JSON string
         * Return: A string comprising both the savedKeys and contexts as one organised JSON string
         */
        private bool mergeToJson()
        {
            // Convert the dictionaries to JSON strings
            string keysJsonStr = JsonConvert.SerializeObject(keysDict, Formatting.Indented);
            string contextJsonStr = JsonConvert.SerializeObject(contextDict, Formatting.Indented);

            // Convert the JSON strings to JSON objects
            JObject keysObject = JObject.Parse(keysJsonStr);
            JObject contextObject = JObject.Parse(contextJsonStr);

            // Merge the two JSON objects together at matching values
            // This process merges each each context recorded with the specific enter key press at the exact same milisecond
            keysObject.Merge(contextObject, new JsonMergeSettings { MergeArrayHandling = MergeArrayHandling.Merge });

            keysJson =  keysObject.ToString();

            return true;

        }

        /*
         * Method: getDictionaries()
         * Summary: Translates a single, merged JSON string back into two separate dictionaries for keys and context
         * Parameter: inputJson - The merged JSON string storing both dictionaries
         */
        private void getDictionaries(string inputJson)
        {
            // Initialise the dictionaries and randomNum variable
            contextDict = new Dictionary<long, Dictionary<string, Dictionary<IntPtr, string>>>();
            keysDict = new Dictionary<long, Dictionary<Keys, IntPtr>>();
            randomNum = new Random();

            // Store the inputJson string into a dynamic object
            dynamic timeKeys = JsonConvert.DeserializeObject(inputJson);

            // Iterate over the outer layer of the JSON string, in this instance it is the time keys of the JSON string
            foreach (dynamic timeVal in timeKeys)
            {
                if (Convert.ToString(timeVal.Name) == "Name" || Convert.ToString(timeVal.Name) == "Desc")
                {
                    Console.WriteLine("Valid key");
                }

                else {
                    try
                    {
                        // Store the time value as a long, necessary for a dictionary entry
                        long time = Convert.ToInt64(timeVal.Name);

                        // Store the timeVal.Value, in this instance it is the key name, into a dynamic object
                        dynamic nameKeys = timeVal.Value;

                        // Iterate over the key names
                        foreach (dynamic nameVal in nameKeys)
                        {
                            // Store the key name in a string variable
                            // In this instance it will be either a key name or the "Open windows"
                            string keyNameStr = nameVal.Name;

                            // Iterate over the nameVal.Values, in this instance it will be either a window title or key action 
                            foreach (dynamic windowVal in nameVal.Value)
                            {
                                // Store the key action (key up or key down) into a string variable
                                string keyActionStr = windowVal.Value;

                                // If the key name is equal to "Open windows", begin the process of adding the open windows to the contextDict
                                // The key name may be "Open windows" due to the fact the keys and context dictionaries were merged into a single JSON string
                                if (keyNameStr == "Open windows")
                                {
                                    // If the contextDict dictionary contains no entry for the current elapsed time, create one
                                    if (!contextDict.ContainsKey(time))
                                    {
                                        contextDict.Add(time, new Dictionary<string, Dictionary<IntPtr, string>>());

                                        // If the contextDictionary contains no context for open windows at the current elapsed time, create one
                                        if (!contextDict[time].ContainsKey("Open windows"))
                                        {
                                            contextDict[time].Add("Open windows", new Dictionary<IntPtr, string>());
                                        }
                                    }

                                    // Initialise a random pointer to be added to the context dictionary. During recording the pointer
                                    // would represent the value of the window handle. This information is required for recording but not
                                    // For playback and thus the value can be generated at random
                                    IntPtr windowHandle = new IntPtr(randomNum.Next());

                                    // Add the entry to the context dictionary
                                    contextDict[time]["Open windows"].Add(windowHandle, keyActionStr);
                                }

                                // If the keyNameStr is a valid key, begin the process of adding an entry to the keys Dictionary
                                else
                                {

                                    // Initialise the keyAction and keyActionStr variables
                                    IntPtr keyAction = (IntPtr)0x0100;

                                    // Convert the key name string variable to the Key data type
                                    Keys keyName;
                                    Enum.TryParse(keyNameStr, out keyName);

                                    // If the key is pressed up or down, assign the keyAction variable the appropriate pointer value
                                    if (keyActionStr == "256")
                                    {
                                        keyAction = (IntPtr)0x0100;

                                        /*
                                         * While regex is true, concatenate string, add "typed: " to beginning, add string to list item[x]
                                         * if not true, add "Pressed {0} key", add string to list item[x]
                                         * work out where to increment x
                                         */

                                        Regex rex = new Regex(@"^[a-zA-Z][0-9]{0,1}$");
                                        if (rex.IsMatch(keyNameStr))
                                        {
                                            //tempstr += keyNameStr + ",";
                                        }
                                    }

                                    else if (keyActionStr == "257")
                                    {
                                        keyAction = (IntPtr)0x0101;
                                    }

                                    // If the key name string is a valid key name, i.e. NOT "Open windows"
                                    if (keyNameStr != "Open windows")
                                    {
                                        // If the keysDict dictionary contains no entry for the current elapsed time, create one
                                        if (!keysDict.ContainsKey(time))
                                            keysDict.Add(time, new Dictionary<Keys, IntPtr>());

                                        // Add the entry to the keysDict dictionary
                                        keysDict[time].Add(keyName, keyAction);
                                    }
                                }
                            }
                        }
                    }

                    catch (FormatException e)
                    {
                        Console.WriteLine("\nInvalid key");
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }

        #endregion
    }
}
