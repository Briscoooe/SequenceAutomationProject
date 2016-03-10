using System;
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
                MessageBox.Show("Error: There is no recording to play");
            }
            recStatus.Show();
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
                    MessageBox.Show("That file was not a valid recording file");
                }
            }
        }

        private void searchListUpdate(object sender, KeyEventArgs e)
        {
            List<string> temp = new List<string>();
            for (int i = 0; i < recList.Count; i++)
            {
                if (recList[i].ToLower().Contains(searchBox.Text.ToLower()))
                {
                    temp.Add(recList[i]);
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
            }

            else
            {
                recList.Clear();
                recList.Add("Could not connect to server");
                MessageBox.Show("Could not connect to server");
            }

            recordingsList.DataSource = recList;
            ActiveControl = recordingsList;
        }

        private void updateList(object sender, EventArgs e)
        {
            recJson = connectionManager.getRecInfo(recordingsList.SelectedItem.ToString());
            updateInfo();
        }

        private void updateInfo()
        {
            dynamic tempObj = JsonConvert.DeserializeObject(recJson);

            if (tempObj.Name == "" || tempObj.Name == null)
            {
                tempObj.Name = "Unavailable";
            }

            if (tempObj.Desc == "" || tempObj.Desc == null)
            {
                tempObj.Desc = "Unavailable";
            }

            recTitleLabel.Text = tempObj.Name;
            recDescLabel.Text = tempObj.Desc;

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
                    recSpeed = 3;
                    break;
                case "2":
                    recSpeedLabel.Text = "2 - Slow";
                    recSpeed = 2;
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
