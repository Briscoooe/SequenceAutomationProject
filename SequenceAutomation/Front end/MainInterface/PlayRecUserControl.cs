﻿using System;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace SequenceAutomation
{
    public partial class PlayRecUserControl : UserControl
    {
        /* 
         * TODO
         * Commmenting
         */

        public event EventHandler BackButtonEvent;
        public event EventHandler TutorialEvent;
        public event EventHandler gotoLoginEvent;
        private RecStatus recStatus;

        private List<string> recList;

        private PlayRecording playRec;
        private ConnectionManager connectionManager;
        private FavouritesBox fave;
        private Recording recording;

        public string recJson = "";
        public string recTitle = "";
        public string recFileName = "";
        public float recSpeed = 1;

        public int recSpeedVal = 3;

        public string temptooltiptext = "";


        public PlayRecUserControl()
        {
            recList = new List<string>();
            InitializeComponent();
            onSpeedChange();


            recStatus = new RecStatus();
        }

        private void doneSelecting(object sender, EventArgs e)
        {
            recJson = fave.recJson;
            updateInfo();
        }

        private void addToFavourites(object sender, EventArgs e)
        {
            if(recJson != "" && recJson != null)
            {
                if(Properties.Settings.Default.favouriteRecordings == null)
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

        private void showFavourites(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.favouriteRecordings != null)
            {
                fave = new FavouritesBox();
                fave.doneSelectingEvent += doneSelecting;
                fave.Show();
            }

            else
            {
                BigMessageBox.Show("You have no favourites to show");
            }

        }

        /*
         * Method: launchPlaying()
         * Summary: Begins the playback of keystrokes
         * Parameter: sender - The control that the action is for, in this case the button
         * Parameter: e - Any arguments the function may use
         */
        private void playRecording(object sender, EventArgs e)
        {
            // If there are no keys loaded to play, display a message informing the user of this
            if (recJson == "")
            {
                BigMessageBox.Show("Error: There is no recording to play");
            }
            //recStatus.Show();
            playRec = new PlayRecording(recJson, recSpeed); // Initialise the playRec object with the keys returned from the createRec class
            playRec.Start();
            //recStatus.Hide();

        }

        private void chooseFile(object sender, EventArgs e)
        {
            openFileDialog.FileName = "";
            openFileDialog.DefaultExt = ".json";
            openFileDialog.Filter = "Recording file (.json) |*.json";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fullPath = openFileDialog.FileName;
                RecordingManager recManager = new RecordingManager();
                if (recManager.validateJson(File.ReadAllText(fullPath)))
                {
                    recJson = File.ReadAllText(fullPath);
                    recTitle = Path.GetFileNameWithoutExtension(fullPath);
                    updateInfo();
                }
                else
                {
                    BigMessageBox.Show("That file was not a valid recording file");
                }
            }
        }

        private void searchListUpdate(object sender, KeyEventArgs e)
        {
            List<string> temp = new List<string>();
            foreach (string name in recList)
            {
                if (name.ToLower().Contains(searchBox.Text.ToLower()))
                {
                    temp.Add(name);
                }
            }
            if (temp.Count == 0)
            {
                temp.Add("No results");
            }
            recordingsList.DataSource = temp;
        }

        public void prepareList()
        {
            connectionManager = new ConnectionManager();
            if (connectionManager.testConnection())
            {
                recList = connectionManager.getRecordings();
                recordingsList.Enabled = true;
                ActiveControl = recordingsList;
            }

            else
            {
                recList.Clear();
                recList.Add("Could not connect to server");
                recordingsList.Enabled = false;
                BigMessageBox.Show("Could not connect to server");
            }

            recordingsList.DataSource = recList;
        }

        private void updateList(object sender, EventArgs e)
        {
            recJson = connectionManager.getRecInfo(recordingsList.SelectedItem.ToString());
            updateInfo();
        }

        private void updateInfo()
        {
            if (recJson != null && recJson != "")
            {
                recording = new Recording(recJson);

                string title = recording.Title;
                string description = recording.Description;

                if (recording.Title == "" || recording.Title == null)
                {
                    title = "Unavailable";
                }

                if (recording.Description == "" || recording.Description == null)
                {
                    description = "Unavailable";
                }

                recTitleLabel.Text = title;
                recDescLabel.Text = description;
            }

        }

        private void increaseSpeed(object sender, EventArgs e)
        {
            if (recSpeedVal < 5)
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

        private void goBack(object sender, EventArgs e)
        {
            if (BackButtonEvent != null)
                BackButtonEvent(this, e);
        }

        private void showTutorial(object sender, EventArgs e)
        {
            if (TutorialEvent != null)
                TutorialEvent(this, e);
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

        private void favouriteBtn_MouseEnter(object sender, EventArgs e)
        {
            favouriteBtn.BackgroundImage = Properties.Resources.favourite_hover;
        }

        private void favouriteBtn_MouseLeave(object sender, EventArgs e)
        {
            favouriteBtn.BackgroundImage = Properties.Resources.favourite;
        }

        private void browseBtn_MouseEnter(object sender, EventArgs e)
        {
            browseBtn.BackgroundImage = Properties.Resources.browse_hover;
        }

        private void browseBtn_MouseLeave(object sender, EventArgs e)
        {
            browseBtn.BackgroundImage = Properties.Resources.browse;
        }

        private void addFavouriteBtn_MouseEnter(object sender, EventArgs e)
        {
            addFavouriteBtn.BackgroundImage = Properties.Resources.addtofavourites_hover;
        }

        private void addFavouriteBtn_MouseLeave(object sender, EventArgs e)
        {
            addFavouriteBtn.BackgroundImage = Properties.Resources.addtofavourites;
        }
    }
}