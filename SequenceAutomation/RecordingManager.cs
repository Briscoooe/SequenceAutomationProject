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

namespace SequenceAutomation
{
    class RecordingManager
    {
        public string name;
        public Dictionary<long, Dictionary<Keys, IntPtr>> savedKeys;
        JavaScriptSerializer serializer = new JavaScriptSerializer();

        public RecordingManager() { }

        public RecordingManager(Dictionary<long, Dictionary<Keys, IntPtr>> savedKeysPassed)
        {
            savedKeys = savedKeysPassed;
        }

        public void toJson()
        {
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);
            Console.WriteLine(json);
        }
    }
}
