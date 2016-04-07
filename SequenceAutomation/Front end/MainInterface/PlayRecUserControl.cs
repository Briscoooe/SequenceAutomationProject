using System;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;

namespace SequenceAutomation
{
    public partial class PlayRecUserControl : UserControl
    {
        #region Variable declarations
        public event EventHandler BackButtonEvent;
        public event EventHandler TutorialEvent;
        public event EventHandler gotoLoginEvent;
        private List<string> recList;
        private List<RecordingManager> recObjectList;
        private PlayRecording playRec;
        private FavouritesBox fave;
        private RecordingManager recording;

        public string recJson = "";
        public string recTitle = "";
        public string recFileName = "";
        public string author = "";
        public float recSpeed = 1;
        public int recSpeedVal = 3;

        #endregion

        public PlayRecUserControl()
        {
            recList = new List<string>();
            recObjectList = new List<RecordingManager>();
            InitializeComponent();
            onSpeedChange();
        }

        // Returns the selected recording from the favourites box
        private void doneSelecting(object sender, EventArgs e)
        {
            recJson = fave.recJson;
            updateInfo();
        }

        /*
         * Method: addToFavourites
         * Summary: Adds the currently active recording to the users favourites
         */
        private void addToFavourites(object sender, EventArgs e)
        {
            // If there is no recording active
            if(recJson != "" && recJson != null)
            {
                // If the user has no favourites, initialise the list
                if(Properties.Settings.Default.favouriteRecordings == null)
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
         * Method: showFavourites()
         * Summary: Begins the "Favourites" window
         * Parameter: sender - The control that the action is for, in this case the button
         * Parameter: e - Any arguments the function may use
         */
        private void showFavourites(object sender, EventArgs e)
        {
            // If there are favourites
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

            playRec = new PlayRecording(recJson, recSpeed); // Initialise the playRec object with the keys returned from the createRec class
            int errors = playRec.Start(); // Begin playback
            if (errors > 0)
                BigMessageBox.Show("The recording may not have played successfully. If this is the case, try reducing the speed");

        }

        /*
         * Method: chooseFile()
         * Summary: Opens a file explorer to allow a user choose a recording from local storage
         * Parameter: sender - The control that the action is for, in this case the text box
         * Parameter: e - The key event arguments
         */
        private void chooseFile(object sender, EventArgs e)
        {
            // Set the parameters of the file explorer
            openFileDialog.FileName = "";
            openFileDialog.DefaultExt = ".json";
            openFileDialog.Filter = "Recording file (.json) |*.json";

            // If a file was chosen
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fullPath = openFileDialog.FileName;

                // Validate the selected file
                if (RecordingManager.validateJson(File.ReadAllText(fullPath)))
                {
                    // Update the information displayed to match the recording
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

        /*
         * Method: searchListUpdate()
         * Summary: Updates the list when text is typed into the search box
         * Parameter: sender - The control that the action is for, in this case the text box
         * Parameter: e - The key event arguments
         */
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

        /*
         * Method: prepareList()
         * Summary: Prepares the list of recordings from the server
         */
        public void prepareList()
        {
            // Clear the list
            recList.Clear();

            // Test the connection
            if (ConnectionManager.testConnection())
            {
                // Retrieve the recordings and add them to the list
                foreach (RecordingManager rec in ConnectionManager.getRecordings())
                {
                    recObjectList.Add(rec);
                    recList.Add(rec.Title);
                }
            }

            // If the connection test fails
            else
            {
                recList.Clear();
                recList.Add("Could not connect to server");
                recordingsList.Enabled = false;
                BigMessageBox.Show("Could not connect to server");
            }

            recordingsList.DataSource = recList;
            refreshList();
        }

        private void updateList(object sender, EventArgs e)
        {
            refreshList();
        }

        private void refreshList()
        {
            foreach (RecordingManager rec in recObjectList)
            {
                if (rec.Title == recordingsList.SelectedItem.ToString())
                {
                    recJson = ConnectionManager.getRecInfo(rec.Id);
                    updateInfo(rec);
                }
            }
        }

        /* 
         * Summary: Updates the recording info with the currently selected one
         */
        private void updateInfo(RecordingManager rec)
        {
            if (rec != null)
            {
                recTitleLabel.Text = rec.Title;
                recDescLabel.Text = rec.Description;
                recAuthorLabel.Text = rec.Author;
            }

        }

        /*
         * Method: updateInfo()
         * Summary: Updates the recording information displayed 
         */
        private void updateInfo()
        {
            if (recJson != null && recJson != "")
            {
                // Instantiate a recording manager variable and extract the title, description and author
                recording = new RecordingManager(recJson);
                string title = recording.Title;
                string description = recording.Description;
                author = recording.Author;

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
                recAuthorLabel.Text = author;
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

        /*
         * Method: deleteRec()
         * Summary: Deletes a recording from the server
         */
        private void deleteRec(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            // If the user is not logged in
            if (Properties.Settings.Default.currentUser != "")
            {
                // Attempt to delete the recording
                if (ConnectionManager.deleteRecording(recJson))
                {
                    // Instantiate a RecordingManager class
                    RecordingManager rec = new RecordingManager(recJson);
                    
                    // Iterate over the recordings and remove the one just deleted
                    foreach (RecordingManager recording in recObjectList.ToArray())
                    {
                        if (rec.Id == recording.Id)
                        {
                            BigMessageBox.Show("Deleted");
                            recObjectList.Remove(recording);
                        }
                    }
                }

                else
                {
                    BigMessageBox.Show("You cannot delete recordings you did not create");
                }
            }
            else
                BigMessageBox.Show("You must be logged in to delete recordings");

            refreshList();
            Cursor.Current = Cursors.Arrow;

        }

        #region Navigation events

        // These methods are event handlers for button events
        private void goBack(object sender, EventArgs e)
        {
            if (BackButtonEvent != null)
                BackButtonEvent(this, e);
        }

        private void showTutorial(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (TutorialEvent != null)
                TutorialEvent(this, e);
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

        private void deleteBtn_mouseEnter(object sender, EventArgs e)
        {
            deleteBtn.BackgroundImage = Properties.Resources.delete_hover;
        }

        private void deleteBtn_mouseLeave(object sender, EventArgs e)
        {
            deleteBtn.BackgroundImage = Properties.Resources.delete;
        }
        #endregion
    }
}
