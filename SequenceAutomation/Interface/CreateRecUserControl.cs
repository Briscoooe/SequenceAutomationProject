using System;
using System.Drawing;
using System.Windows.Forms;

namespace SequenceAutomation
{
    public partial class CreateRecUserControl : UserControl
    {
        public event EventHandler BackButtonEvent;

        private CreateRecording createRec;
        private ConnectionManager conn;
        private PlayRecording playRec;
        private string mergedJson;

        public CreateRecUserControl()
        {
            InitializeComponent();
            conn = new ConnectionManager();
        }

        /*
         * Method: goBack()
         * Summary: Returns to the previous screen
         * Parameter: sender - The control that the action is for, in this case the button
         * Parameter: e - Any arguments the function may use
         */
        public void goBack(object sender, EventArgs e)
        {
            if(BackButtonEvent != null)
                BackButtonEvent(this, e);
        }

        /*
         * Method: launchPlaying()
         * Summary: Begins the playback of keystrokes
         * Parameter: sender - The control that the action is for, in this case the button
         * Parameter: e - Any arguments the function may use
         */
        private void testRecording(object sender, EventArgs e)
        {
            // If there are no keys loaded to play, display a message informing the user of this
            if (mergedJson == null)
            {
                MessageBox.Show("Error: There is no recording to play");
                return;
            }
            playRec = new PlayRecording(mergedJson, 1); // Initialise the playRec object with the keys returned from the createRec class
            playRec.Start(); // Begin playback
        }

        /*
         * Method: startRecording()
         * Summary: Begins the playback of keystrokes
         * Parameter: sender - The control that the action is for, in this case the button
         * Parameter: e - Any arguments the function may use
         */
        private void startRecording(object sender, EventArgs e)
        {
            startStopRecBtn.Text = "Stop Recording";
            createRec = new CreateRecording(); // Reinitialise the createRec variable, restarting the clock and clearning the dictionary of recorded keys
            createRec.Start(); // Begin recording

            recStatusText.ForeColor = Color.Green;
            recStatusText.Text = "Recording active";

            // Alter the button so that clicking no longer invokes the launchRecording method, but instead the stopRecording method
            startStopRecBtn.Click -= startRecording;
            startStopRecBtn.Click += stopRecording;
        }

        /*
         * Method: stopRecording()
         * Summary: Stops the recording of keystrokes
         * Parameter: sender - The control that the action is for, in this case the button
         * Parameter: e - Any arguments the function may use
         */
        private void stopRecording(object sender, EventArgs e)
        {
            startStopRecBtn.Text = "Begin Recording";

            recStatusText.ForeColor = Color.Red;
            recStatusText.Text = "Not recording";

            // Alter the button so that clicking no longer invokes the stopRecording method, but instead the launchRecording method
            startStopRecBtn.Click += startRecording;
            startStopRecBtn.Click -= stopRecording;
            mergedJson = createRec.Stop(); // Stop recording  

            uploadTb.Text = "rec001.json";
        }

        /*
         *
         */
        private void upload(object sender, EventArgs e)
        {
            Console.WriteLine("upload called");
            if(conn.Upload(mergedJson))
                Console.WriteLine("Uploaded");

            else
                Console.WriteLine("Failed");
        }
    }
}
