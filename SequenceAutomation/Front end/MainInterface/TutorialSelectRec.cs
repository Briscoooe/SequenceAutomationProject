using System;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;

namespace SequenceAutomation
{
    public partial class TutorialSelectRec : UserControl
    {
        #region Variable declarations
        public event EventHandler goBackEvent;
        public event EventHandler<TextEventArgs> goNextEvent;
        public event EventHandler gotoLoginEvent;
        public RecordingManager recording;
        private List<RecordingManager> recObjectList;
        private FavouritesBox fave;
        private List<string> recList;
        private string recJson;
        private string recTitle;
        #endregion


        public TutorialSelectRec()
        {
            InitializeComponent();
            recList = new List<string>();
            recObjectList = new List<RecordingManager>();
        }

        /*
         * Method: prepareList()
         * Summary: Prepares the list of recordings from the server
         */
        public void prepareList()
        {
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
            ActiveControl = recordingsList;
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

        private void updateList(object sender, EventArgs e)
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


        private void doneSelecting(object sender, EventArgs e)
        {
            recJson = fave.recJson;
            updateInfo();
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
                string author = recording.Author;

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
        #region Navigation events
        // These methods are event handlers for button events
        private void gotoLogin(object sender, EventArgs e)
        {
            if (gotoLoginEvent != null)
                gotoLoginEvent(this, e);
        }

        private void goNext(object sender, EventArgs e)
        {
            if (recJson == null)
            {
                BigMessageBox.Show("You must choose a recording to continue to the next screen");
                return;
            }

            returnJson(new TextEventArgs(recJson, recTitle, 1));
        }

        private void goBack(object sender, EventArgs e)
        {
            if (goBackEvent != null)
                goBackEvent(this, e);
        }

        private void returnJson(TextEventArgs e)
        {
            EventHandler<TextEventArgs> eh = goNextEvent;
            if (eh != null)
                eh(this, e);
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

        #endregion
    }
}
