using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections.Generic;

namespace SequenceAutomation
{
    public partial class TutorialUploadRec : UserControl
    {

        public event EventHandler gotoLoginEvent;
        public event EventHandler goNextEvent;
        public event EventHandler<TextEventArgs> goBackEvent;
        private AccountContainer accountContainer;

        public string recJson = "";

        public TutorialUploadRec()
        {
            InitializeComponent();
        }

        /*
         * Method: addToFavourites
         * Summary: Adds the currently active recording to the users favourites
         */
        private void addToFavourites(object sender, EventArgs e)
        {
            // Validate the input boxes
            if(validateInput(0))
            {
                // If there is a recording
                if (recJson != "" && recJson != null)
                {
                    // Add the information to the recording
                    string test = RecordingManager.addInformation(recJson, recTitleTb.Text, recDescTb.Text);

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
                            Properties.Settings.Default.favouriteRecordings.Add(test);
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
            }

            Properties.Settings.Default.Save();

        }

        /*
         * Method: saveFile()
         * Summary: Saves a file to local storage by opening a Windows native file explorer
         * Parameter: sender - The object that called the function
         * Parameter: e - Any arguments the function may use
         */
        private void saveFile(object sender, EventArgs e)
        {
            // Validate the input
            if (validateInput(0))
            {
                // Add the information to the recJson string
                recJson = RecordingManager.addInformation(recJson, recTitleTb.Text, recDescTb.Text);

                // Remove all but the alphanumeric characters from the recording title
                string test = Regex.Replace(recTitleTb.Text, @"[\W]", "");
                SaveFileDialog dlg = new SaveFileDialog();

                // Set the dialog members
                dlg.FileName = test;
                dlg.DefaultExt = ".json";
                dlg.Filter = "Recording file (.json) |*.json";

                // Open the dialog box, if successful, display an appropriate error message
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(dlg.FileName, recJson);
                    BigMessageBox.Show("Saved successfully!");
                }
            }

        }

        /*
         * Method: uploadRecording()
         * Summary: Attempts to upload a recording to the server
         * Parameter: sender - The object that called the function
         * Parameter: e - Any arguments the function may use
         */
        private void uploadRecording(object sender, EventArgs e)
        {
            // Change the mouse cursor to the "Wait" cursor
            Cursor.Current = Cursors.WaitCursor;

            // Validate the input boxes
            if (validateInput(1))
            {
                // Test the connection
                if (ConnectionManager.testConnection())
                {
                    // Add the information to the recJson string
                    recJson = RecordingManager.addInformation(recJson, recTitleTb.Text, recDescTb.Text);

                    // Attempt the upload, inform the user of the success or failure of it
                    if (ConnectionManager.uploadRecording(recJson))
                        BigMessageBox.Show("Uploaded");
                    else
                        BigMessageBox.Show("There was a problem with the server");
                }

                // If the connection test fails
                else
                {
                    BigMessageBox.Show("Could not connect to server");
                }

            }

            // Change the mouse cursor back to the standard arrow pointer
            Cursor.Current = Cursors.Arrow;
        }

        /*
         * Method: validateInput()
         * Summary: Ensures that the user has entered a title, description and is logged in
         * Parameter: option - The path taken for validation. Necessary as saving locally or adding to favourites does not require login
         * Returns: True or false depending on the validation
         */
        private bool validateInput(int option)
        {
            // If the validation requires log in and there is no user currently logged in
            if (Properties.Settings.Default.currentUser == "" && option == 1)
            {
                BigMessageBox.Show("You must be logged in to upload recordings. You can do this using the \"login\" option below");
                return false;
            }

            // If no recording has been created
            if (recJson == null)
            {
                BigMessageBox.Show("You must create a recording");
                return false;
            }

            // If no title has been entered
            if (recTitleTb.Text == "")
            {
                BigMessageBox.Show("You must enter a title");
                return false;
            }

            // If no description has been entered
            if (recDescTb.Text == "")
            {
                BigMessageBox.Show("You must enter a description");
                return false;
            }

            // If the recording contains mouse activity
            if (RecordingManager.containsMouse(recJson))
            {
                BigMessageBox.Show("You cannot contain mouse activity in recordings. All mouse activity will be removed from your recording before upload");
                recJson = RecordingManager.removeMouse(recJson);
            }
            return true;
        }

        /*
         * Method: checkLogin()
         * Summary: Checks if there is a user currently logged 
         * Returns: True or false depending on whether or not a user is logged in
         */
        public bool checkLogin()
        {
            // If no user is logged in, set the text of the login button to "Login"
            if (Properties.Settings.Default.currentUser == "")
            {
                loginBtn.Text = "Login";
            }

            // If a user is logged in, set the login button text to "Logout"
            else
            {
                loginBtn.Text = "Logout";
            }

            return true;
        }

        /*
         * Method: returnLogin()
         * Summary: Changes the button text to "Logout" once a user logs in
         * Parameter: sender - The object that called the function
         * Parameter: e - Any arguments the function may use
         */
        private void returnLogin(object sender, EventArgs e)
        {
            checkLogin();
        }
        /*
         * Method: login()
         * Summary: Opens up a new window with the login options
         * Parameter: sender - The object that called the function
         * Parameter: e - Any arguments the function may use
         */
        private void login(object sender, EventArgs e)
        {
            // If the login button text is "Login"
            if (loginBtn.Text == "Login")
            {
                // Initialise the accounts container window and show it
                AccountContainer accountContainer = new AccountContainer();
                accountContainer.Show();

                // Subscribe returnLogin event in accounts container
                accountContainer.loggedInEvent += returnLogin;
            }

            // If a user is logged in, log the user out and display a message informing them of this
            else
            {
                Properties.Settings.Default.currentUser = "";
                BigMessageBox.Show("Logged out");

                // Update the button text
                checkLogin();
            }
        }

        #region Navigation events

        private void gotoLogin(object sender, EventArgs e)
        {
            if (gotoLoginEvent != null)
                gotoLoginEvent(this, e);
        }

        private void goNext(object sender, EventArgs e)
        {
            if (goNextEvent != null)
                goNextEvent(this, e);
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
            nextBtn.BackgroundImage = Properties.Resources.done;
        }

        private void nextBtn_MouseEnter(object sender, EventArgs e)
        {
            nextBtn.BackgroundImage = Properties.Resources.done_hover;
        }

        private void uploadBtn_MouseEnter(object sender, EventArgs e)
        {
            uploadBtn.BackgroundImage = Properties.Resources.upload_hover;
        }

        private void uploadBtn_MouseLeave(object sender, EventArgs e)
        {
            uploadBtn.BackgroundImage = Properties.Resources.upload;
        }

        private void saveBtn_MouseEnter(object sender, EventArgs e)
        {
            saveBtn.BackgroundImage = Properties.Resources.save_hover;
        }

        private void saveBtn_MouseLeave(object sender, EventArgs e)
        {
            saveBtn.BackgroundImage = Properties.Resources.save;
        }

        private void favouriteBtn_MouseEnter(object sender, EventArgs e)
        {
            favouriteBtn.BackgroundImage = Properties.Resources.favourite_hover;
        }

        private void favouriteBtn_MouseLeave(object sender, EventArgs e)
        {
            favouriteBtn.BackgroundImage = Properties.Resources.favourite;
        }

        #endregion

    }
}
