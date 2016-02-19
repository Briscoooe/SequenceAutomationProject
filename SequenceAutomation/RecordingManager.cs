using System;
using System.Collections.Generic;
using System.Windows.Forms;

// External library used: http://www.newtonsoft.com/json
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using Newtonsoft.Json.Converters;
using System.Runtime.InteropServices;

namespace SequenceAutomation
{
    class RecordingManager
    {
        #region Variable declaration

        public Dictionary<long, Dictionary<Keys, IntPtr>> keysDict; // Dictionary to store the savedKeys in the format (time: <keyTitle, action>)
        public Dictionary<long, Dictionary<string, Dictionary<IntPtr, string>>> contextDict;  // Dictionary to store the context in the format (time: <windowHandle, windowTitle>)
        private string keysJsonStr, contextJsonStr;
        private JObject keysObject, contextObject;

        #endregion

        #region Public methods

        /*
         * Method: RecordingManager()
         * Summary: Class Constructor
         */
        public RecordingManager() { }

        /*
         * Method: RecordingManager()
         * Summary: Class Constructor
         */
        public RecordingManager(Dictionary<long, Dictionary<Keys, IntPtr>> keysDict, Dictionary<long, Dictionary<string, Dictionary<IntPtr, string>>> contextDict)
        {
            this.keysDict = keysDict;
            this.contextDict = contextDict;
        }

        /*
         * Method: toJson()
         * Summary: Converts the savedKeys and context Dictionaries to a single JSON string
         * Return: A string comprising both the savedKeys and contexts as one organised JSON string
         */
        public string mergeToJson()
        {
            // Convert the dictionaries to JSON strings
            keysJsonStr = JsonConvert.SerializeObject(keysDict, Formatting.Indented);
            contextJsonStr = JsonConvert.SerializeObject(contextDict, Formatting.Indented);

            // Convert the JSON strings to JSON objects
            keysObject = JObject.Parse(keysJsonStr);
            contextObject = JObject.Parse(contextJsonStr);

            // Merge the two JSON objects together at matching values
            // This process merges each each context recorded with the specific enter key press at the exact same milisecond
            keysObject.Merge(contextObject, new JsonMergeSettings { MergeArrayHandling = MergeArrayHandling.Merge });

            return keysObject.ToString();
        }


        public Dictionary<long, Dictionary<string, Dictionary<IntPtr, string>>> getContextDict(string inputJson)
        {
            contextDict = new Dictionary<long, Dictionary<string, Dictionary<IntPtr, string>>>();

            dynamic timeKeys = JsonConvert.DeserializeObject(inputJson);
            foreach (dynamic timeVal in timeKeys)
            {
                long time = Convert.ToInt64(timeVal.Name);
                dynamic nameKeys = timeVal.Value;

                foreach (dynamic nameVal in nameKeys)
                {
                    string key = nameVal.Name;
                    Console.WriteLine("Key: {0}", key);
                    dynamic windows = nameVal.Value;
                    Console.WriteLine("Action: {0}", windows);

                    dynamic actionKeys = nameVal.Value;

                    if (key == "Open windows" && actionKeys.Value == "256")
                    {
                        foreach (dynamic windowVal in windows)
                        {
                            Random randomNum = new Random();
                            IntPtr windowHandle = new IntPtr(randomNum.Next());
                            string windowTitle = windowVal.Value;
                            Console.WriteLine("windowTitle: {0}", windowTitle);
                            Console.WriteLine("windowHandle: {0}", windowHandle);

                            // If the contextDict dictionary contains no entry for the current elapsed time, create one
                            if (!contextDict.ContainsKey(time))
                            {
                                contextDict.Add(time, new Dictionary<string, Dictionary<IntPtr, string>>());

                                // If the contextDictionary contains no context at the current elapsed time, create one
                                if (!contextDict[time].ContainsKey("Open windows"))
                                {
                                    contextDict[time].Add("Open windows", new Dictionary<IntPtr, string>());
                                }
                            }

                            contextDict[time]["Open windows"].Add(windowHandle, windowTitle);

                        }
                    }
                }
            }

            return contextDict;
        }

        public Dictionary<long, Dictionary<Keys, IntPtr>> getKeysDict(string inputJson)
        {
            
            keysDict = new Dictionary<long, Dictionary<Keys, IntPtr>>();

            dynamic timeKeys = JsonConvert.DeserializeObject(inputJson);
            // Iterating over the time key of the JSON string
            foreach (dynamic timeVal in timeKeys)
            {
                long time = Convert.ToInt64(timeVal.Name);
                dynamic nameKeys = timeVal.Value;
                
                // Iterating over the name keys of the JSON string
                foreach (dynamic nameVal in nameKeys)
                {
                    string keyNameStr = nameVal.Name;

                    // Iterating over the action keys of the JSON string
                    foreach (dynamic actionKeys in nameVal.Value)
                    {
                        IntPtr keyAction = (IntPtr)0x0100;
                        string keyActionStr = actionKeys.Value;

                        if (keyActionStr == "256")
                        {
                            keyAction = (IntPtr)0x0100;
                        }

                        else if(keyActionStr == "257")
                        {
                            keyAction = (IntPtr)0x0101;
                        }

                        Keys keyName;
                        Enum.TryParse(keyNameStr, out keyName);

                        if(keyNameStr != "Open windows")
                        {
                            // If the savedKeys dictionary contains no entry for the current elapsed time, create one
                            if (!keysDict.ContainsKey(time))
                                keysDict.Add(time, new Dictionary<Keys, IntPtr>());
                            keysDict[time].Add(keyName, keyAction); //Saves the key and the 
                        }
                    }

                }
            }

            return keysDict;
        }

        #endregion
    }
}
