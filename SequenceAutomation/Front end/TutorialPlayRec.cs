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
    public partial class TutorialPlayRec : UserControl
    {
        public event EventHandler<TextEventArgs> goBackEvent;
        public event EventHandler gotoPlayEvent;
        public event EventHandler gotoLoginEvent;

        private PlayRecording playRec;

        public string recJson = "";
        public string recTitle = "";
        public int recSpeed = 2;

        public TutorialPlayRec()
        {
            InitializeComponent();
        }

        private void gotoPlay(object sender, EventArgs e)
        {
            if (gotoPlayEvent != null)
                gotoPlayEvent(this, e);
        }

        private void goBack(object sender, EventArgs e)
        {
            returnJson(new TextEventArgs(recJson, "", 1));
        }

        public void returnJson(TextEventArgs e)
        {
            EventHandler<TextEventArgs> eh = goBackEvent;
            if (eh != null)
                eh(this, e);
        }

        private void gotoLogin(object sender, EventArgs e)
        {
            if (gotoLoginEvent != null)
                gotoLoginEvent(this, e);
        }

        private void playRecBtn_MouseLeave(object sender, EventArgs e)
        {
            playRecBtn.BackgroundImage = Properties.Resources.play;
        }

        private void playRecBtn_MouseEnter(object sender, EventArgs e)
        {
            playRecBtn.BackgroundImage = Properties.Resources.play_hover;
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

        private void doneBtn_MouseLeave(object sender, EventArgs e)
        {
            doneBtn.BackgroundImage = Properties.Resources.done;
        }

        private void doneBtn_MouseEnter(object sender, EventArgs e)
        {
            doneBtn.BackgroundImage = Properties.Resources.done_hover;
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
            if (recJson == null)
            {
                MessageBox.Show("Error: There is no recording to play");
                return;
            }
            playRec = new PlayRecording(recJson, 1); // Initialise the playRec object with the keys returned from the createRec class
            playRec.Start(); // Begin playback
        }

    }
}
