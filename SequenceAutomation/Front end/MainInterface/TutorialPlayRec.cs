using System;
using System.Collections.Generic;
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
        public float recSpeed = 1;

        public int recSpeedVal = 3;

        public TutorialPlayRec()
        {
            InitializeComponent();
            onSpeedChange();
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

        private void returnJson(TextEventArgs e)
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

        private void increaseBtn_MouseLeave(object sender, EventArgs e)
        {
            increaseBtn.BackgroundImage = Properties.Resources.uparrow;
        }

        private void increaseBtn_MouseEnter(object sender, EventArgs e)
        {
            increaseBtn.BackgroundImage = Properties.Resources.uparrow_hover;
        }

        private void decreaseBtn_MouseLeave(object sender, EventArgs e)
        {
            decreaseBtn.BackgroundImage = Properties.Resources.downarrow;
        }

        private void decreaseBtn_MouseEnter(object sender, EventArgs e)
        {
            decreaseBtn.BackgroundImage = Properties.Resources.downarrow_hover;
        }

        private void addFavouriteBtn_MouseEnter(object sender, EventArgs e)
        {
            addFavouriteBtn.BackgroundImage = Properties.Resources.addtofavourites_hover;
        }

        private void addFavouriteBtn_MouseLeave(object sender, EventArgs e)
        {
            addFavouriteBtn.BackgroundImage = Properties.Resources.addtofavourites;
        }

        private void addToFavourites(object sender, EventArgs e)
        {
            if (recJson != "" && recJson != null)
            {
                if (Properties.Settings.Default.favouriteRecordings == null)
                {
                    Properties.Settings.Default.favouriteRecordings = new List<string>();
                }
                List<string> tmp = new List<string>();
                tmp = Properties.Settings.Default.favouriteRecordings;
                int x = 0;

                if (tmp.Count > 0)
                {
                    foreach (string s in tmp)
                    {
                        if (recJson == s)
                        {
                            x++;
                        }
                    }

                    if (x == 0)
                    {
                        Properties.Settings.Default.favouriteRecordings.Add(recJson);
                        BigMessageBox.Show("Added to favourites");
                    }
                    else
                    {
                        BigMessageBox.Show("This recording is already in your favourites");
                    }
                }

                else
                {
                    Properties.Settings.Default.favouriteRecordings = new List<string>();
                    Properties.Settings.Default.favouriteRecordings.Add("");
                    addToFavourites(sender, e);
                }
            }

            else
            {
                BigMessageBox.Show("There is no recording to be added to favourites");
            }

            Properties.Settings.Default.Save();
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
                BigMessageBox.Show("Error: There is no recording to play");
                return;
            }
            playRec = new PlayRecording(recJson, recSpeed); // Initialise the playRec object with the keys returned from the createRec class
            int errors = playRec.Start(); // Begin playback
            if (errors > 0)
                BigMessageBox.Show("The recording may not have played successfully. If this is the case, try reducing the speed");
        }


        private void increaseSpeed(object sender, EventArgs e)
        {
            if(recSpeedVal < 5)
            {
                recSpeedVal++;
                onSpeedChange();
            }
        }

        private void decreaseSpeed(object sender, EventArgs e)
        {
            if (recSpeedVal > 1)
            {
                recSpeedVal--;
                onSpeedChange();
            }
        }

        private void onSpeedChange()
        {
            switch (recSpeedVal.ToString())
            {
                case "1":
                    recSpeedLabel.Text = "1 - Very slow";
                    recSpeed = 6;
                    break;
                case "2":
                    recSpeedLabel.Text = "2 - Slow";
                    recSpeed = 3;
                    break;
                case "3":
                    recSpeedLabel.Text = "3 - Normal";
                    recSpeed = 1;
                    break;
                case "4":
                    recSpeedLabel.Text = "4 - Fast";
                    recSpeed = .75F;
                    break;
                case "5":
                    recSpeedLabel.Text = "5 - Very fast";
                    recSpeed = .5F;
                    break;
                default:
                    break;
            }
        }

    }
}
