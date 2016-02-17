﻿using System;
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

        public string name;
        public Dictionary<long, Dictionary<Keys, IntPtr>> savedKeys; // Dictionary to store the savedKeys in the format (time: <keyTitle, action>)
        public Dictionary<long, Dictionary<IntPtr, string>> context;  // Dictionary to store the context in the format (time: <windowHandle, windowTitle>)
        private string keysJson, contextJson;
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
        public RecordingManager(Dictionary<long, Dictionary<Keys, IntPtr>> savedKeysPassed, Dictionary<long, Dictionary<IntPtr, string>> contextPassed)
        {
            savedKeys = savedKeysPassed;
            context = contextPassed;
        }

        /*
         * Method: toJson()
         * Summary: Converts the savedKeys and context Dictionaries to a single JSON string
         * Return: A string comprising both the savedKeys and contexts as one organised JSON string
         */
        public string toJson()
        {
            // Convert the dictionaries to JSON strings
            keysJson = JsonConvert.SerializeObject(savedKeys, Formatting.Indented);
            contextJson = JsonConvert.SerializeObject(context, Formatting.Indented);

            // Convert the JSON strings to JSON objects
            keysObject = JObject.Parse(keysJson);
            contextObject = JObject.Parse(contextJson);

            // Merge the two JSON objects together at matching values
            // This process merges each each context recorded with the specific enter key press at the exact same milisecond
            keysObject.Merge(contextObject, new JsonMergeSettings { MergeArrayHandling = MergeArrayHandling.Merge });

            return keysObject.ToString();
        }

        #endregion
    }
}
