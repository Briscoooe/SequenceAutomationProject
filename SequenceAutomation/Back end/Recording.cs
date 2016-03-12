using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SequenceAutomation
{
    public class Recording
    {
        private string recTitle, recDescription, recId, recUsername;
        private Dictionary<long, Dictionary<Keys, IntPtr>> keysDict; // Dictionary to store the savedKeys in the format (time: <keyTitle, action>)
        private Dictionary<long, Dictionary<string, Dictionary<IntPtr, string>>> contextDict;  // Dictionary to store the context in the format (time: <windowHandle, windowTitle>)

        public Recording(string rec)
        {
            dynamic recObj = JsonConvert.DeserializeObject(rec);
            recTitle = recObj.Name;
            recDescription = recObj.Desc;
            recId = recObj.recId;
            recUsername = recObj.userName;
        }

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
    }
}
