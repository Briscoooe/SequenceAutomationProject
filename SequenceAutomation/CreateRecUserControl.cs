using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SequenceAutomation
{
    public partial class CreateRecUserControl : UserControl
    {
        private CreateRecording createRec;
        private PlayRecording playRec;
        private string mergedJson;

        public CreateRecUserControl()
        {
            InitializeComponent();
        }

        private void goBack(object sender, EventArgs e)
        {
            Hide();
            LoginUserControl x = new LoginUserControl();
            x.Show();
        }

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

        private void stopRecording(object sender, EventArgs e)
        {
            startStopRecBtn.Text = "Begin Recording";

            recStatusText.ForeColor = Color.Red;
            recStatusText.Text = "Not recording";

            // Alter the button so that clicking no longer invokes the stopRecording method, but instead the launchRecording method
            startStopRecBtn.Click += startRecording;
            startStopRecBtn.Click -= stopRecording;
            mergedJson = createRec.Stop(); // Stop recording

            Console.WriteLine(mergedJson);
            //outputBox.Text = mergedJson;
        }
    }
}
