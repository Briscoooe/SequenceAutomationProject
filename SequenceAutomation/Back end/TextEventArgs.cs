using System;

namespace SequenceAutomation
{
    /*
     * Summary: This class is used by buttons in the interface classes to pass information between screens
     */
    public class TextEventArgs : EventArgs
    {
        #region Variable declarations
        private string recJson;
        private string filename;
        private float recSpeed;

        #endregion

        #region Public methods
        /*
         * Method: TextEventArgs()
         * Summary: The constructor for the TextEventArgs class. It instantiates the class members
         * Parameter: recJson - A string containing a recording in the JSON format
         * Parameter: filename - The filename of the recording being passed in
         * Parameter: recSpeed - The speed of the recording
         */
        public TextEventArgs(string recJson, string filename, int recSpeed)
        {
            this.recJson = recJson;
            this.filename = filename;
            this.recSpeed = recSpeed;
        }
        #endregion

        #region Getter methods
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
        #endregion
    }
}
