using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SequenceAutomation
{
    public partial class FavouritesBox : Form
    {
        public string recJson;
        private Dictionary<string,string> recList;
        public event EventHandler doneSelectingEvent; // The event handler for the "Done" button
        public RecordingManager recording;

        /*
         * Method: FavouritesBox()
         * Summary: The constructor for the FavouritesBox class
         */
        public FavouritesBox()
        {
            InitializeComponent();
            CenterToScreen();
            MaximizeBox = false;
            MinimizeBox = false;
            prepareList();
        }

        /*
         * Method: searchListUpdate()
         * Summary: Updates the list when text is typed into the search box
         * Parameter: sender - The control that the action is for, in this case the text box
         * Parameter: e - The key event arguments
         */
        private void searchListUpdate(object sender, KeyEventArgs e)
        {
            // Create a temporary list
            List<string> temp = new List<string>();
            
            // Iterate over the recording list being searched
            foreach (KeyValuePair<string, string> kvp in recList)
            {
                // If the recording list contains the text in the searchbox, add it to the temporary list
                if (kvp.Key.ToLower().Contains(searchBox.Text.ToLower()))
                {
                    temp.Add(kvp.Key);
                }
            }

            // If no matches are found
            if (temp.Count == 0)
            {
                temp.Add("No results");
                recTitleLabel.Text = "Unavailable";
                recDescLabel.Text = "Unavailable";
            }

            // Set the data source for the recordings list as the temporary list containing the search results
            recordingsList.DataSource = temp;
        }

        /*
         * Method: prepareList()
         * Summary: Prepares the list of favourites
         */
        private void prepareList()
        {
            // Initialise the list
            recList = new Dictionary<string, string>();

            // Iterate over the stored local recordings
            foreach (string rec in Properties.Settings.Default.favouriteRecordings.ToArray())
            {
                if (rec != "")
                {
                    // Instantiate each recording in the favourites and add it to the recordings list
                    recording = new RecordingManager(rec);
                    if (!recList.ContainsKey(recording.Title))
                    {
                        recList.Add(recording.Title, rec);
                    }

                }

            }

            // If there are on favourites
            if(recList.Count == 0)
            {
                recList.Add("No favourites", "");
                recTitleLabel.Text = "Unavailable";
                recDescLabel.Text = "Unavailable";
            }

            // Update the list with the keys in the dictionary
            recordingsList.DataSource = (from keys in recList.Keys select keys).ToList();
            ActiveControl = recordingsList;
            object x = new object();
            EventArgs y = new EventArgs();
            updateInfo(x, y);
        }

        /*
         * Method: updateInfo()
         * Summary: Updates the recording information panel with the information on the currently selected recording
         * Parameter: sender - The control that the action is for
         * Parameter: e - Any arguments the method uses
         */
        private void updateInfo(object sender, EventArgs e)
        {
            // Get the title of the active recording
            string activeRecTitle = recordingsList.SelectedItem.ToString();
            // Find the recording in the recording list
            foreach(KeyValuePair<string, string> kvp in recList)
            {
                if(kvp.Key == activeRecTitle)
                {
                    recJson = kvp.Value;
                }
            }

            string title = "";
            string description = "";

            if (recJson != "")
            {
                // Instantiate the RecordingManager variable
                recording = new RecordingManager(recJson);

                // If the recording title is null or empty
                if (recording.Title == "" || recording.Title == null)
                {
                    title = "Unavailable";
                }

                else
                {
                    title = recording.Title;
                }

                // If the recording description is null or empty
                if (recording.Description == "" || recording.Description == null)
                {
                    description = "Unavailable";
                }

                else
                {
                    description = recording.Description;
                }
            }

            // Set the labels to the recording title and information
            recTitleLabel.Text = title;
            recDescLabel.Text = description;
        }

        /*
         * Method: deleteFavourite()
         * Summary: Deletes the currently highlighted favourite from the list
         * Parameter: sender - The control that the action is for, in this case the delete button
         * Parameter: e - The key event arguments
         */
        private void deleteFavourite(object sender, EventArgs e)
        {
            // Iterate over the users favourites
            foreach (string rec in Properties.Settings.Default.favouriteRecordings.ToArray())
            {
                if(rec != "")
                {
                    // Instantiate the RecordingManager variable
                    recording = new RecordingManager(rec);

                    // If the highlighted recording matches one of the favourites
                    if (Convert.ToString(recording.Title) == recordingsList.SelectedItem.ToString())
                    {
                        // Delete the recording
                        Properties.Settings.Default.favouriteRecordings.Remove(rec);
                        BigMessageBox.Show("Removed from favourites");

                        // Refresh the the list and save the settings
                        prepareList();
                        Properties.Settings.Default.Save();
                        break;
                    }
                }
            }
        }

        /*
         * Method: doneSelecting()
         * Summary: Returns the highlighted recording to the main application interface 
         * Parameter: sender - The control that the action is for, in this case the "Done" button
         * Parameter: e - The key event arguments
         */
        private void doneSelecting(object sender, EventArgs e)
        {
            // Close the window
            Dispose();
            if (doneSelectingEvent != null)
                doneSelectingEvent(this, e);
        }

        #region Button hover events
        /*
         * Summary: Each method in this region is an event handler that is triggered when
         * the mouse hovers over a button and then leaves that button. The methods change
         * their specific button to a darker color, indicating that it is being hovered over
         */

        private void doneBtn_MouseLeave(object sender, EventArgs e)
        {
            doneBtn.BackgroundImage = Properties.Resources.done;
        }

        private void doneBtn_MouseEnter(object sender, EventArgs e)
        {
            doneBtn.BackgroundImage = Properties.Resources.done_hover;
        }

        private void deleteBtn_MouseLeave(object sender, EventArgs e)
        {
            deleteBtn.BackgroundImage = Properties.Resources.delete;
        }

        private void deleteBtn_MouseEnter(object sender, EventArgs e)
        {
            deleteBtn.BackgroundImage = Properties.Resources.delete_hover;
        }

        #endregion

    }
}
