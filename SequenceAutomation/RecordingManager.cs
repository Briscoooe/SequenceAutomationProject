using System;
using System.Collections.Generic;
using System.Windows.Forms;

// External library used: http://www.newtonsoft.com/json
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SequenceAutomation
{
    class RecordingManager
    {
        #region Variable declaration

        public Dictionary<long, Dictionary<Keys, IntPtr>> savedKeys; // Dictionary to store the savedKeys in the format (time: <keyTitle, action>)
        public Dictionary<long, Dictionary<string, Dictionary<IntPtr, string>>> context;  // Dictionary to store the context in the format (time: <windowHandle, windowTitle>)
        private string keysJsonStr, contextJsonStr;
        private JObject keysObject, contextObject;
        private NestedDictionary<string, string> nested;

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
        public RecordingManager(Dictionary<long, Dictionary<Keys, IntPtr>> savedKeys, Dictionary<long, Dictionary<string, Dictionary<IntPtr, string>>> context, NestedDictionary<string,string> test)
        {
            this.savedKeys = savedKeys;
            this.context = context;
            this.nested = test;
        }

        /*
         * Method: toJson()
         * Summary: Converts the savedKeys and context Dictionaries to a single JSON string
         * Return: A string comprising both the savedKeys and contexts as one organised JSON string
         */
        public string mergeToJson()
        {
            // Convert the dictionaries to JSON strings
            keysJsonStr = JsonConvert.SerializeObject(savedKeys, Formatting.Indented);
            contextJsonStr = JsonConvert.SerializeObject(context, Formatting.Indented);

            string test = JsonConvert.SerializeObject(nested, Formatting.Indented);

            Console.WriteLine(test);
            // Convert the JSON strings to JSON objects
            keysObject = JObject.Parse(keysJsonStr);
            contextObject = JObject.Parse(contextJsonStr);

            // Merge the two JSON objects together at matching values
            // This process merges each each context recorded with the specific enter key press at the exact same milisecond
            keysObject.Merge(contextObject, new JsonMergeSettings { MergeArrayHandling = MergeArrayHandling.Merge });

            return keysObject.ToString();
        }

        public Dictionary<long, Dictionary<Keys, IntPtr>> parseJson(string mergedJson)
        {
            Console.WriteLine(mergedJson);
            return JsonConvert.DeserializeObject<Dictionary<long, Dictionary<Keys, IntPtr>>>(mergedJson);
        }

        #endregion
    }
}
