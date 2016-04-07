using System;
using System.Windows.Forms;

namespace SequenceAutomation.Interface
{
    public partial class TutorialTestRec : UserControl
    {
        public event EventHandler gotoLoginEvent;
        public event EventHandler<TextEventArgs> goNextEvent;
        public event EventHandler goBackEvent;

        public string mergedJson = "";
        private PlayRecording playRec;

        public TutorialTestRec()
        {
            InitializeComponent();
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
                BigMessageBox.Show("Error: There is no recording to play");
                return;
            }
            playRec = new PlayRecording(mergedJson, 1); // Initialise the playRec object with the keys returned from the createRec class
            int result = playRec.Start(); // Begin playback

            testRecBtn.Click -= testRecording;
            if (result >= 0)
                BigMessageBox.Show("Complete");

            testRecBtn.Click += testRecording;
        }

        #region Navigation events
        // These methods are event handlers for button events
        private void gotoLogin(object sender, EventArgs e)
        {
            if (gotoLoginEvent != null)
                gotoLoginEvent(this, e);
        }

        private void goNext(object sender, EventArgs e)
        {
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
        #endregion

        #region Button hover events

        /*
         * Summary: Each method in this region is an event handler that is triggered when
         * the mouse hovers over a button and then leaves that button. The methods change
         * their specific button to a darker color, indicating that it is being hovered over
         */

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

        private void playBtn_MouseLeave(object sender, EventArgs e)
        {
           testRecBtn.BackgroundImage = Properties.Resources.play;

        }

        private void playBtn_MouseEnter(object sender, EventArgs e)
        {
            testRecBtn.BackgroundImage = Properties.Resources.play_hover;
        }
        #endregion
    }
}
