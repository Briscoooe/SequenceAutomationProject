using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceAutomation
{
    public class TextEventArgs : EventArgs
    {
        private string mergedJson;

        public TextEventArgs(string mergedJson)
        {
            this.mergedJson = mergedJson;
        }

        public string json
        {
            get { return mergedJson; }
        }
    }
}
