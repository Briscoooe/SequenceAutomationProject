using System;

namespace SequenceAutomation
{
    public class TextEventArgs : EventArgs
    {
        private string recJson;
        private string filename;
        private float recSpeed;

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

        public float speed
        {
            get { return recSpeed; }
        }
    }
}
