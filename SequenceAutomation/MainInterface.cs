using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SequenceAutomation
{
    public partial class MainInterface : Form
    {
        #region Variable declarations

        private CreateRecording createRec;
        private PlayRecording playRec;
        private string mergedJson;

        #endregion

        #region Public methods

        /*
         * Method: MainInterface()
         * Summary: Class constructor
         */
        public MainInterface()
        {
            InitializeComponent();
        }

        #endregion

        #region Private methods

        /*
         * Method: launchRecording()
         * Summary: Begins the recording of keystrokes
         * Parameter: sender - The control that the action is for, in this case the button
         * Parameter: e - Any arguments the function may use
         */
        private void launchRecording(object sender, EventArgs e)
        {
            startStopButton.Text = "Stop";
            createRec = new CreateRecording(); // Reinitialise the createRec variable, restarting the clock and clearning the dictionary of recorded keys
            createRec.Start(); // Begin recording

            // Alter the button so that clicking no longer invokes the launchRecording method, but instead the stopRecording method
            startStopButton.Click -= launchRecording; 
            startStopButton.Click += stopRecording; 
        }

        /*
         * Method: stopRecording()
         * Summary: Stops the recording of keystrokes
         * Parameter: sender - The control that the action is for, in this case the button
         * Parameter: e - Any arguments the function may use
         */
        private void stopRecording(object sender, EventArgs e)
        {
            startStopButton.Text = "Record";

            // Alter the button so that clicking no longer invokes the stopRecording method, but instead the launchRecording method
            startStopButton.Click += launchRecording;
            startStopButton.Click -= stopRecording;
            mergedJson = createRec.Stop(); // Stop recording
            outputBox.Text = mergedJson;
        }

        /*
         * Method: launchPlaying()
         * Summary: Begins the playback of keystrokes
         * Parameter: sender - The control that the action is for, in this case the button
         * Parameter: e - Any arguments the function may use
         */
        private void launchPlaying(object sender, EventArgs e)
        {
            // If there are no keys loaded to play, display a message informing the user of this
            if (mergedJson == null)
            {
                MessageBox.Show("Error: There is no recording to play");
                return;
            }
            playRec = new PlayRecording(mergedJson); // Initialise the playRec object with the keys returned from the createRec class
            playRec.Start(); // Begin playback
        }

        #endregion
    }

}
