using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SequenceAutomation
{
    class RecordingManager
    {
        public string name;
        public Dictionary<long, Dictionary<Keys, IntPtr>> savedKeys;
        public Dictionary<long, Dictionary<IntPtr, string>> context;
        JavaScriptSerializer serializer = new JavaScriptSerializer();

        public RecordingManager() { }

        public RecordingManager(Dictionary<long, Dictionary<Keys, IntPtr>> savedKeysPassed, 
                                Dictionary<long, Dictionary<IntPtr, string>> contextPassed)
        {
            savedKeys = savedKeysPassed;
            context = contextPassed;
        }

        public void addToJson()
        {

        }
        public string toJson()
        {
            string keysJson = JsonConvert.SerializeObject(savedKeys, Formatting.Indented);
            string contextJson = JsonConvert.SerializeObject(context, Formatting.Indented);
            Console.WriteLine("\nKeys JSON string: {0}", keysJson);
            Console.WriteLine("\nContext JSON string: {0}", contextJson);
            JObject o1 = JObject.Parse(keysJson);
            JObject o2 = JObject.Parse(contextJson);

            // Loop through o2, remove windows ID, add open windows as parent and add all windows as children
            // "window title" : { window title, window title }
            // OR use "info" : "open windows" { window title, window title }

            o2.Add("info", "open windows");
            o1.Merge(o2, new JsonMergeSettings { MergeArrayHandling = MergeArrayHandling.Merge });
            Console.WriteLine("\nMerged JSON Object: {0}", o1.ToString());
            return o1.ToString();
        }
    }
}
