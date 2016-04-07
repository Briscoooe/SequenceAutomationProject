using System;
using System.Collections.Generic;
using System.Windows.Forms;

// External library used: http://www.newtonsoft.com/json
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace SequenceAutomation
{
    public class RecordingManager
    {
        #region Variable declaration

        public Dictionary<long, Dictionary<Keys, IntPtr>> keysDict; // Dictionary to store the savedKeys in the format (time: <keyTitle, action>)
        public Dictionary<long, Dictionary<string, Dictionary<IntPtr, string>>> contextDict;  // Dictionary to store the context in the format (time: <windowHandle, windowTitle>)
        public Dictionary<long, Dictionary<IntPtr, Dictionary<string, int>>> mouseDict;
        private Random randomNum; // A random number used when extracting the dictionary values
        public string recTitle, recDescription, recId, recAuthor, userId; // The string class members

        #endregion

        #region Getter methods

        // Each of these methods returns the class member specified in the return of the "get" call
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

        public string Author
        {
            get { return recAuthor; }
        }

        public string UserId
        {
            get { return userId; }
        }

        #endregion

        #region Public methods


        /*
         * Method: RecordingManager()
         * Summary: Class constructor
         * Parameter: inputJson - A JSON string in the recording format
         */
        public RecordingManager(string inputJson)
        {
            try
            {
                // Attempt to extract the recording information from the JSON string
                dynamic recObj = JsonConvert.DeserializeObject(inputJson);
                recTitle = recObj.Name;
                recDescription = recObj.Desc;
                recId = recObj.recId;
                userId = recObj.userId;

                // If the recording contains a value for the name key
                if(recObj.AuthorFirstname != null)
                {
                    // Combine the value of the author firstname and surname to the author name class member
                    recAuthor = Convert.ToString(recObj.AuthorFirstname) + " " + Convert.ToString(recObj.AuthorSurname);
                }
            }

            // If the recording is in the incorrect format
            catch (JsonReaderException j)
            {
                Console.WriteLine(j.Message);
                throw;
            }
        }


        /*
         * Method: addInformation()
         * Summary: Adds identifying information to a recording string
         * Parameter: keysString - The dictionary of keys pressed, the key action, and the time it was pressed
         * Parameter: title - The tite to be added to the string
         * Parameter: description - The description to be added to the string
         * Return: A JSON string containing the added information
         */
        public static string addInformation(string keysString, string title, string description)
        {
            dynamic tempObj = JsonConvert.DeserializeObject(keysString);

            tempObj.Name = title;
            tempObj.Desc = description;
            tempObj.recId = "";
            tempObj.AuthorFirstname = Properties.Settings.Default.currentUserFirstname;
            tempObj.AuthorSurname = Properties.Settings.Default.currentUserSurname;
            tempObj.UserId = Properties.Settings.Default.currentUser;

            return JsonConvert.SerializeObject(tempObj);
        }

        /*
         * Method: validateJson()
         * Summary: Validates whether or not a string in in the valid JSON format
         * Parameter: recJson - The string to be validated
         * Return: True or false depending on whether or not the recording is in the valid format
         */
        public static bool validateJson(string recJson)
        {
            try
            {
                // Instantate the recording
                RecordingManager recording = new RecordingManager(recJson);

                // If the title or description are empty or non-existent
                if (recording.Title == null || recording.Title == "" ||
                    recording.Description == null || recording.Description == "")
                {
                    return false;
                }

                // Store the inputJson string into a dynamic object
                dynamic jsonKeys = JsonConvert.DeserializeObject(recJson);

                // Iterate over the outer layer of the JSON string, in this instance it is the time keys of the JSON string
                foreach (dynamic key in jsonKeys)
                {
                    // If the key is one of the information keys
                    if (Convert.ToString(key.Name) == "Name" || Convert.ToString(key.Name) == "Desc" ||
                    Convert.ToString(key.Name) == "recId" || Convert.ToString(key.Name) == "userName" || 
                    Convert.ToString(key.Name) == "AuthorFirstname" || Convert.ToString(key.Name) == "AuthorSurname" ||
                    Convert.ToString(key.Name) == "UserId")
                    {
                        Console.WriteLine("Not time val");
                    }

                    else
                    {
                        try
                        {
                            // Try and convert the key to a long
                            long time = Convert.ToInt64(key.Name);
                        }

                        // If the key cannot be converted to a long
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            return false;
                        }

                    }
                }
                return true;
            }

            // If the instantiation fails
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        /*
        * Method: containsMouse()
        * Summary: Checks to see if a recording contains mouse activity
        * Parameter: recJson - The recording to check
        * Returns: True or false
        */
        public static bool containsMouse(string recJson)
        {
            var keysObject = JObject.Parse(recJson);

            // Iterate over the properties in the JSON string
            var props = keysObject.Properties().ToList();
            foreach (var prop in props)
            {
                foreach (JProperty layer3 in prop.Value)
                {
                    // If a mouse object is detected
                    if (layer3.Name == "512" || layer3.Name == "513" || layer3.Name == "514" ||
                            layer3.Name == "516" || layer3.Name == "517" || layer3.Name == "522")
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /*
        * Method: removeMouse()
        * Summary: Removes any mouse activity from the recording
        * Parameter: recJson - The recording to check
        * Returns: A recording string without any mouse entries
        */
        public static string removeMouse(string recJson)
        {
            var keysObject = JObject.Parse(recJson);
            var props = keysObject.Properties().ToList();

            // Iterate over the properties in the JSON string
            foreach (var prop in props)
            {
                foreach (JProperty layer3 in prop.Value)
                {
                    // If a mouse object is reached, remove it from the keys object
                    if (layer3.Name == "512" || layer3.Name == "513" || layer3.Name == "514" ||
                            layer3.Name == "516" || layer3.Name == "517" || layer3.Name == "522")
                    {
                        keysObject.Property(prop.Name).Remove();
                    }
                }
            }
            return keysObject.ToString();
        }

        /*
        * Method: getRecId()
        * Summary: Extracts the ID from a recording
        * Parameter: recJson - The recording to retrive the ID of
        * Returns: A string containing the recording ID
        */
        public static string getRecId(string recJson)
        {
            RecordingManager rec = new RecordingManager(recJson);
            return rec.Id;
        }

        /*
        * Method: getDictionaries()
        * Summary: Translates a single, merged JSON string back into two separate dictionaries for keys and context
        * Parameter: inputJson - The merged JSON string storing both dictionaries
        */
        public void getDictionaries(string inputJson)
        {
            // Initialise the dictionaries and randomNum variable
            contextDict = new Dictionary<long, Dictionary<string, Dictionary<IntPtr, string>>>();
            keysDict = new Dictionary<long, Dictionary<Keys, IntPtr>>();
            mouseDict = new Dictionary<long, Dictionary<IntPtr, Dictionary<string, int>>>();
            randomNum = new Random();
            
            var keysObject = JObject.Parse(inputJson);

            var props = keysObject.Properties().ToList();
            foreach (var prop in props)
            {
                long time = Convert.ToInt64(prop.Name);
                foreach(JProperty layer3 in prop.Value)
                {
                    // If a context object is reached
                    if (layer3.Name == "Open windows")
                    {
                        // Add the time key
                        if (!contextDict.ContainsKey(time))
                            contextDict.Add(time, new Dictionary<string, Dictionary<IntPtr, string>>());

                        foreach (JProperty layer4 in layer3.Value)
                        {
                            // Add the "Open windows" key
                            if (!contextDict[time].ContainsKey("Open windows"))
                                contextDict[time].Add("Open windows", new Dictionary<IntPtr, string>());

                            // Add the window handle and title
                            IntPtr windowHandle = new IntPtr(randomNum.Next());
                            contextDict[time]["Open windows"].Add(windowHandle, Convert.ToString(layer4.Value));
                        }
                    }

                    // If a mouse object is reached
                    else if(layer3.Name == "512" || layer3.Name == "513" || layer3.Name == "514" ||
                            layer3.Name == "516" || layer3.Name == "517" || layer3.Name == "522")
                    {
                        // Create a new entry in the mouse dictionary
                        if (!mouseDict.ContainsKey(time))
                            mouseDict.Add(time, new Dictionary<IntPtr, Dictionary<string, int>>());

                        foreach (JProperty layer4 in layer3.Value)
                        {
                            // Initialise the mouse message pointer which represents the mouse action (left click, right click etc.)
                            IntPtr mouseMessage = (IntPtr)Convert.ToInt32(layer3.Name);

                            // Add the mouseMessage key to the dictionary
                            if (!mouseDict[time].ContainsKey(mouseMessage))
                                mouseDict[time].Add(mouseMessage, new Dictionary<string, int>());

                            // Add the coordinates to the mouse dictionary
                            if (!mouseDict[time][mouseMessage].ContainsKey(layer4.Name))
                                mouseDict[time][mouseMessage].Add(layer4.Name, Convert.ToInt32(layer4.Value));
                        }
                    }
                    // If a key object is reached
                    else
                    {
                        // Iterate over the key-action key-value pairs
                        foreach (JProperty layer4 in layer3.Value)
                        {
                            // Declare the key action pointer
                            IntPtr keyAction;

                            // Initialise the key name
                            Keys keyName;
                            Enum.TryParse(layer3.Name, out keyName);

                            // Declare the action pointer
                            if (Convert.ToString(layer4.Value) == "256")
                                keyAction = (IntPtr)0x0100;
                            else
                                keyAction = (IntPtr)0x0101;

                            // Create the dictionary entry
                            if (!keysDict.ContainsKey(time))
                                keysDict.Add(time, new Dictionary<Keys, IntPtr>());

                            // Add the entry to the keysDict dictionary
                            keysDict[time].Add(keyName, keyAction);
                        }
                    }
                }
            }
        }

        /*
         * Method: mergeToJson()
         * Summary: Converts the keys, mouse and context Dictionaries to a single JSON string
         * Return: A JSON string comprising the three dictoinaries
         */
        public static string mergeToJson(Dictionary<string, Dictionary<long, Dictionary<Keys, IntPtr>>> keysDict,
                                Dictionary<string, Dictionary<long, Dictionary<string, Dictionary<IntPtr, string>>>> contextDict,
                                Dictionary<string, Dictionary<long, Dictionary<IntPtr, Dictionary<string, int>>>> mouseDict)
        {
            // Convert the dictionaries to JSON strings
            string keysJsonStr = JsonConvert.SerializeObject(keysDict, Formatting.Indented);
            string contextJsonStr = JsonConvert.SerializeObject(contextDict, Formatting.Indented);
            string mouseJsonStr = JsonConvert.SerializeObject(mouseDict, Formatting.Indented);

            // Convert the JSON strings to JSON objects
            var keysObject = JObject.Parse(keysJsonStr);
            var contextObject = JObject.Parse(contextJsonStr);
            var mouseObject = JObject.Parse(mouseJsonStr);

            // Merge the context JSON object to the mouse and key objects at the matching values
            // This process merges each each context recorded with the specific enter key press at the exact same milisecond
            keysObject.Merge(contextObject, new JsonMergeSettings { MergeArrayHandling = MergeArrayHandling.Merge });
            mouseObject.Merge(contextObject, new JsonMergeSettings { MergeArrayHandling = MergeArrayHandling.Merge });

            // Merge the keys and mouse dictionaries
            keysObject.Merge(mouseObject, new JsonMergeSettings { MergeArrayHandling = MergeArrayHandling.Union });

            // Sort the dictionary to chronological order
            keysObject = sort(keysObject);
            return keysObject.ToString();

        }

        #endregion

        #region Private methods

        /*
         * Method: sort()
         * Summary: Sorts the dictionary keys to numerical order
         * Return: A string comprising both the savedKeys and contexts as one organised JSON string
         */
        private static JObject sort(JObject obj)
        {
            // Declare a list to store the times
            List<long> timeList = new List<long>();

            // Declare a temporary object to store the ordered keys
            JObject tempObj = new JObject();
            
            // Declare an object and iterate over it
            var props = obj.Properties().ToList();
            foreach (var prop in props.OrderBy(p => p.Value))
                foreach(JProperty prop2 in prop.Value)
                {
                    // If key is a time key, add it to the list
                    long time = Convert.ToInt64(prop2.Name);
                    if (time != 512 && time != 513 && time != 514 && time != 516 && time != 517 && time != 522)
                        timeList.Add(time);
                }

            // Sort the list of times and iterate over it
            timeList.Sort();
            foreach (long l in timeList)
                foreach(var prop in props)
                    foreach(JProperty prop2 in prop.Value)
                        // If the time key is equal to a value in the original object, add it to the temporary object
                        if(prop2.Name == Convert.ToString(l))
                            tempObj.Add(prop2);

            // Return the temporary object
            return tempObj;
        }

        #endregion
    }
}
