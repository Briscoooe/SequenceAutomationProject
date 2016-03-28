using System;
using System.Drawing;
using System.Windows.Forms;

namespace SequenceAutomation
{
    public partial class TutorialStartRec : UserControl
    {

        /* 
         * TODO
         * Commmenting
         */

        public event EventHandler gotoLoginEvent;
        public event EventHandler<TextEventArgs> goNextEvent;
        public event EventHandler goBackEvent;
        private KeyboardShortcut shortcut;
        private CreateRecording createRec;
        private RecStatus recStatus;
        private string mergedJson;


        public TutorialStartRec()
        {
            InitializeComponent();
        }

        public void reset()
        {
            recCreatedLabel.Hide();
        }

        private void recStatus_StopCreate(object sender, EventArgs e)
        {
            stopRecording(sender, e);
        }


        /*
         * Method: startRecording()
         * Summary: Begins the playback of keystrokes
         * Parameter: sender - The control that the action is for, in this case the button
         * Parameter: e - Any arguments the function may use
         */
        private void startRecording(object sender, EventArgs e)
        {
            BigMessageBox.Show("Recording has now begun. Press control and space to end the recording, or use the buttons in the application");
            startStopRecBtn.BackgroundImage = Properties.Resources.stop;
            recButtonLabel.Text = "Press the red button again to stop the recording";
            recButtonLabel2.Hide();

            startStopRecBtn.Tag = "stopRecTag";

            createRec = new CreateRecording(); // Reinitialise the createRec variable, restarting the clock and clearning the dictionary of recorded keys
            createRec.Start(); // Begin recording

            recCreatedLabel.Hide();

            recStatusText.ForeColor = Color.Green;
            recStatusText.Text = "Recording active";

            // Initialise the keyboard shortcut
            shortcut = new KeyboardShortcut();
            shortcut.KeyPressed += new EventHandler<KeyPressedEventArgs>(shortcut_Pressed);
            // Display the status box containing the elapsed time and a stopbutton
            recStatus = new RecStatus(1);
            recStatus.stopButtonEvent += recStatus_StopCreate;
            recStatus.Show();

            // Alter the button so that clicking no longer invokes the launchRecording method, but instead the stopRecording method
            startStopRecBtn.Click -= startRecording;
            startStopRecBtn.Click += stopRecording;
        }

        private void shortcut_Pressed(object sender, KeyPressedEventArgs e)
        {
            stopRecording(sender, e);
        }

        /*
         * Method: stopRecording()
         * Summary: Stops the recording of keystrokes
         * Parameter: sender - The control that the action is for, in this case the button
         * Parameter: e - Any arguments the function may use
         */
        private void stopRecording(object sender, EventArgs e)
        {
            startStopRecBtn.BackgroundImage = Properties.Resources.record;
            recButtonLabel.Text = "Press the red button to begin the recording";
            recStatusText.ForeColor = Color.Red;
            recStatusText.Text = "Not recording";

            startStopRecBtn.Tag = "startRecTag";

            recButtonLabel2.Show();
            recCreatedLabel.Show();

            // Alter the button so that clicking no longer invokes the stopRecording method, but instead the launchRecording method
            startStopRecBtn.Click += startRecording;
            startStopRecBtn.Click -= stopRecording;
            mergedJson = createRec.Stop(); // Stop recording  
            recStatus.Dispose();
            shortcut.Dispose();


        }


        private void gotoLogin(object sender, EventArgs e)
        {
            if (gotoLoginEvent != null)
                gotoLoginEvent(this, e);
        }

        private void goNext(object sender, EventArgs e)
        {
            if(mergedJson == null)
            {
                BigMessageBox.Show("You must create a recording to continue to the next screen");
                return;
            }

            returnJson(new TextEventArgs(mergedJson, "", 1));
        }

        private void returnJson(TextEventArgs e)
        {
            EventHandler<TextEventArgs> eh = goNextEvent;
            if (eh != null)
                eh(this, e);
        }

        private void goBack(object sender, EventArgs e)
        {
            if (goBackEvent != null)
                goBackEvent(this, e);
        }

        private void goBackBtn_MouseLeave(object sender, EventArgs e)
        {
            goBackBtn.BackgroundImage = Properties.Resources.backbutton;
        }

        private void goBackBtn_MouseEnter(object sender, EventArgs e)
        {
            goBackBtn.BackgroundImage = Properties.Resources.backbutton_hover;
        }

        private void homeBtn_MouseLeave(object sender, EventArgs e)
        {
            homeBtn.BackgroundImage = Properties.Resources.home;
        }

        private void homeBtn_MouseEnter(object sender, EventArgs e)
        {
            homeBtn.BackgroundImage = Properties.Resources.home_hover;
        }

        private void nextBtn_MouseLeave(object sender, EventArgs e)
        {
            nextBtn.BackgroundImage = Properties.Resources.forwardbutton;
        }

        private void nextBtn_MouseEnter(object sender, EventArgs e)
        {
            nextBtn.BackgroundImage = Properties.Resources.forwardbutton_hover;
        }

        private void startStopRecBtn_MouseEnter(object sender, EventArgs e)
        {
            if (startStopRecBtn.Tag.ToString() == "stopRecTag")
            {
                startStopRecBtn.BackgroundImage = Properties.Resources.stop_hover;
            }

            else if (startStopRecBtn.Tag.ToString() == "startRecTag")
            {
                startStopRecBtn.BackgroundImage = Properties.Resources.record_hover;
            }
        }

        private void startStopRecBtn_MouseLeave(object sender, EventArgs e)
        {
            if (startStopRecBtn.Tag.ToString() == "stopRecTag")
            {
                startStopRecBtn.BackgroundImage = Properties.Resources.stop;
            }

            else if (startStopRecBtn.Tag.ToString() == "startRecTag")
            {
                startStopRecBtn.BackgroundImage = Properties.Resources.record;
            }
        }
    }
}
