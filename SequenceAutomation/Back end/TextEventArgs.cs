using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceAutomation
{
    public class TextEventArgs : EventArgs
    {
        private string recJson;
        private string filename;
        private int recSpeed;

        public TextEventArgs(string recJson, string filename, int recSpeed)
        {
            this.recJson = recJson;
            this.filename = filename;
            this.recSpeed = recSpeed;
        }

        public string json
        {
            get { return recJson; }
        }

        public string name
        {
            get { return filename; }
        }

        public int speed
        {
            get { return recSpeed; }
        }
    }
}
