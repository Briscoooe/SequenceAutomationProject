using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SequenceAutomation
{
    public partial class TutorialPlayRec : UserControl
    {
        #region Variable declarations
        public event EventHandler<TextEventArgs> goBackEvent;
        public event EventHandler gotoPlayEvent;
        public event EventHandler gotoLoginEvent;

        private PlayRecording playRec;
        public string recJson = "";
        public string recTitle = "";
        public float recSpeed = 1;
        public int recSpeedVal = 3;

        #endregion

        public TutorialPlayRec()
        {
            InitializeComponent();
            onSpeedChange();
        }

        /*
         * Method: addToFavourites
         * Summary: Adds the currently active recording to the users favourites
         */
        private void addToFavourites(object sender, EventArgs e)
        {
            // If there is no recording active
            if (recJson != "" && recJson != null)
            {
                // If the user has no favourites, initialise the list
                if (Properties.Settings.Default.favouriteRecordings == null)
                {
                    Properties.Settings.Default.favouriteRecordings = new List<string>();
                }
                // Initialise a temporary list storing the favourites
                List<string> tmp = new List<string>();
                tmp = Properties.Settings.Default.favouriteRecordings;
                int x = 0;

                // If there are favourites in the list
                if (tmp.Count > 0)
                {
                    // Count the number of occurences of the current recording in the favourites
                    foreach (string s in tmp)
                        if (recJson == s)
                            x++;

                    // If the recording is not already in the users favourites
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

                // Initialise the favourites list
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

            // Save the settings
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

        /*
         * Method: onSpeedChange()
         * Summary: Changes the speed of recording based on what the user has selected
         */
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

        #region Navigation events

        // These methods are event handlers for the various buttons
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

        #endregion

        #region Button hover events

        /*
         * Summary: Each method in this region is an event handler that is triggered when
         * the mouse hovers over a button and then leaves that button. The methods change
         * their specific button to a darker color, indicating that it is being hovered over
         */
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

        #endregion

    }
}
