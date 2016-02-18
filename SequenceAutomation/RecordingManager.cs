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


        public Dictionary<long, Dictionary<string, Dictionary<IntPtr, string>>> getContext(string inputJson)
        {
            contextDict = new Dictionary<long, Dictionary<string, Dictionary<IntPtr, string>>>();

            dynamic parsedObject = JsonConvert.DeserializeObject(inputJson);
            foreach (dynamic entry in parsedObject)
            {
                string time = entry.Name;
                dynamic value = entry.Value;

                foreach (dynamic entry2 in value)
                {
                    string key = entry2.Name;
                    Console.WriteLine("Key: {0}", key);
                    dynamic action = entry2.Value;
                    Console.WriteLine("Action: {0}", action);

                    if (key == "Open windows")
                    {
                        foreach (dynamic entry3 in action)
                        {
                            string value3 = entry3.Value;
                            Console.WriteLine("Windows: {0}", value3);
                        }
                    }
                }
            }

            return contextDict;
        }

        public Dictionary<long, Dictionary<Keys, IntPtr>> getKeys(string inputJson)
        {
            
            keysDict = new Dictionary<long, Dictionary<Keys, IntPtr>>();

            dynamic parsedObject = JsonConvert.DeserializeObject(inputJson);
            // Iterating over the time key of the JSON string
            foreach (dynamic timeKeys in parsedObject)
            {
                long time = Convert.ToInt64(timeKeys.Name);

                dynamic child = timeKeys.Value;
                
                // Iterating over the name keys of the JSON string
                foreach (dynamic nameKeys in child)
                {
                    string keyNameStr = nameKeys.Name;

                    // Iterating over the action keys of the JSON string
                    foreach (dynamic actionKeys in nameKeys.Value)
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

                        Console.WriteLine("\nTIME: {0}\nKEYNAMESTR: {1}\nKEYACTION: {2}", time, keyNameStr, keyAction);

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

            Console.WriteLine("Complete");
            return keysDict;
        }

        #endregion
    }
}
