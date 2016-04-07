using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SequenceAutomation
{
    public partial class CreateRecUserControl : UserControl
    {
        #region Variable declarations
        public event EventHandler BackButtonEvent; // The event handler for the back button
        public event EventHandler ShowTutorialEvent; // The event handler for the tutorial button
        private KeyboardShortcut shortcut; 
        private CreateRecording createRec;
        private RecStatus recStatus;
        private PlayRecording playRec;
        private string recJson;

        #endregion

        #region Public methods
        public CreateRecUserControl()
        {
            InitializeComponent();
        }

        #endregion

        #region Private methods
        /*
         * Method: testRecording()
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

            startStopRecBtn.Click -= startRecording;
            playRec = new PlayRecording(recJson, 1); // Initialise the playRec object with the keys returned from the createRec class
            int result = playRec.Start(); // Begin playback

            if (result >= 0)
                BigMessageBox.Show("Complete");

            startStopRecBtn.Click += startRecording;
        }


        /*
         * Method: startRecording()
         * Summary: Begins the playback of keystrokes
         * Parameter: sender - The control that the action is for, in this case the button
         * Parameter: e - Any arguments the function may use
         */
        private void startRecording(object sender, EventArgs e)
        {
            BigMessageBox.Show("Recording has now begun. Press control and space to end the recording, or use the buttons in the application");
            startStopRecBtn.BackgroundImage = Properties.Resources.stop;
            recButtonLabel.Text = "Stop recording";
            recTitleTb.Text = "";
            recDescTb.Text = "";

            startStopRecBtn.Tag = "stopRecTag";

            createRec = new CreateRecording(); // Reinitialise the createRec variable, restarting the clock and clearning the dictionary of recorded keys
            createRec.Start(); // Begin recording

            recStatusText.ForeColor = Color.Green;
            recStatusText.Text = "Recording active";

            // Initialise the keyboard shortcut
            shortcut = new KeyboardShortcut();
            shortcut.KeyPressed += new EventHandler<KeyPressedEventArgs>(shortcut_PressedCreate);

            // Display the status box containing the elapsed time and a stopbutton
            recStatus = new RecStatus(1);
            recStatus.stopButtonEvent += recStatus_StopCreate;
            recStatus.Show();

            // Alter the button so that clicking no longer invokes the launchRecording method, but instead the stopRecording method
            startStopRecBtn.Click -= startRecording;
            startStopRecBtn.Click += stopRecording;
        }

        /*
         * Method: shortcut_PressedCreate()
         * Summary: An event handler for the "Stop" keyboard shortcut. 
         * Parameter: sender - The sender of the action
         * Parameter: e - The keypress arguments i.e. the shortcut pressed to trigger the event
         */
        private void shortcut_PressedCreate(object sender, KeyPressedEventArgs e)
        {
            // Call the stopRecording method to end the recording
            stopRecording(sender, e);
        }

        /*
         * Method: recStatus_StopCreate()
         * Summary: An event handler for the "Stop" button in the recStatus dialog box 
         * Parameter: sender - The control that the action is for, in this case the button
         * Parameter: e - Any arguments the function may use
         */
        private void recStatus_StopCreate(object sender, EventArgs e)
        {
            // Call the stopRecording method to end the recording
            stopRecording(sender, e);
        }

        /*
         * Method: stopRecording()
         * Summary: Stops the recording of keystrokes
         * Parameter: sender - The control that the action is for, in this case the button
         * Parameter: e - Any arguments the function may use
         */
        private void stopRecording(object sender, EventArgs e)
        {
            startStopRecBtn.BackgroundImage = Properties.Resources.record;
            recButtonLabel.Text = "Begin recording";
            recStatusText.ForeColor = Color.Red;
            recStatusText.Text = "Not recording";

            startStopRecBtn.Tag = "startRecTag";

            // Alter the button rso that clicking no longer invokes the stopRecording method, but instead the launchRecording method
            startStopRecBtn.Click += startRecording;
            startStopRecBtn.Click -= stopRecording;
            recJson = createRec.Stop(); // Stop recording  
            recStatus.Dispose();
            shortcut.Dispose();
            shortcut = null;
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

            // Validate the input
            // Note, the value "1" passed to the validateInput method requires the user to be
            // logged in to pass
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
                string filename = Regex.Replace(recTitleTb.Text, @"[\W]", "");

                // Create a new save dialog box instanc
                SaveFileDialog dialog = new SaveFileDialog();

                // Set the dialog members
                dialog.FileName = filename;
                dialog.DefaultExt = ".json";
                dialog.Filter = "Recording file (.json) |*.json";

                // Open the dialog box, if successful, display an appropriate error message
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(dialog.FileName, recJson);
                    BigMessageBox.Show("Saved successfully!");
                }
            }

        }

        /*
         * Method: addToFavorites()
         * Summary: Adds the current recording to the users local favourites
         * Parameter: sender - The object that called the function
         * Parameter: e - Any arguments the function may use
         */
        private void addToFavourites(object sender, EventArgs e)
        {
            // Validate the input
            if (validateInput(0))
            {
                // If no recording has been created
                if (recJson != "" && recJson != null)
                {
                    // Initialise a temporary list variable to store the users favourites
                    List<string> favourites = new List<string>();
                    favourites = Properties.Settings.Default.favouriteRecordings;
                    int x = 0;


                    // If the user has at least one favourite
                    if (favourites.Count > 0)
                    {
                        // Add the information to the recording
                        string recording = RecordingManager.addInformation(recJson, recTitleTb.Text, recDescTb.Text);

                        // Iterate over the favourites and count the number of times the current
                        // Recording is exists in their favourites
                        foreach (string s in favourites)
                        {
                            if (recording == s)
                            {
                                x++;
                            }
                        }

                        // If there are no matches
                        if (x == 0)
                        {
                            // Add the recording to the users favourites
                            Properties.Settings.Default.favouriteRecordings.Add(recording);
                            BigMessageBox.Show("Added to favourites");
                        }

                        // If the recording is already in the users favourites
                        else
                        {
                            BigMessageBox.Show("This recording is already in your favourites");
                        }
                    }

                    // If the user has no favourites, initialise the favourites the list
                    else
                    {
                        Properties.Settings.Default.favouriteRecordings = new List<string>();
                        Properties.Settings.Default.favouriteRecordings.Add("");
                        addToFavourites(sender, e);
                    }
                }

                // If there is no recording
                else
                {
                    BigMessageBox.Show("There is no recording to be added to favourites");
                }
            }

            // Save changes made to the users recordings
            Properties.Settings.Default.Save();
        }

        /*
         * Method: checkLogin()
         * Summary: Checks if there is a user currently logged 
         * Returns: True or false depending on whether or not a user is logged in
         */
        public bool checkLogin()
        {
            // If no user is logged in, set the text of the login button to "Login"
            if(Properties.Settings.Default.currentUser == "")
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
            return true;
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
            if(loginBtn.Text == "Login")
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

        #endregion


        #region Navigation events

        // These methods are event handlers for the navigation buttons
        private void showTutorial(object sender, EventArgs e)
        {
            if (ShowTutorialEvent != null)
                ShowTutorialEvent(this, e);
        }

        private void goBack(object sender, EventArgs e)
        {
            if (BackButtonEvent != null)
                BackButtonEvent(this, e);
        }

        #endregion

        #region Button hover events

        /*
         * Summary: Each method in this region is an event handler that is triggered when
         * the mouse hovers over a button and then leaves that button. The methods change
         * their specific button to a darker color, indicating that it is being hovered over
         */

        private void startStopRecBtn_MouseEnter(object sender, EventArgs e)
        {
            // This logic is necessary as the start button and stop button share the same control
            // The image changes depending on whether or not recording is active

            //If the stop button is being shown, change the button to the stop_hover image
            if (startStopRecBtn.Tag.ToString() == "stopRecTag")
            {
                startStopRecBtn.BackgroundImage = Properties.Resources.stop_hover;
            }

            //If the start button is being shown, change the button to the start_hover image
            else if (startStopRecBtn.Tag.ToString() == "startRecTag")
            {
                startStopRecBtn.BackgroundImage = Properties.Resources.record_hover;
            }
        }

        private void startStopRecBtn_MouseLeave(object sender, EventArgs e)
        {
            if (startStopRecBtn.Tag.ToString() == "stopRecTag")
            {
                startStopRecBtn.BackgroundImage = Properties.Resources.stop;
            }

            else if (startStopRecBtn.Tag.ToString() == "startRecTag")
            {
                startStopRecBtn.BackgroundImage = Properties.Resources.record;
            }
        }

        private void testRecBtn_MouseLeave(object sender, EventArgs e)
        {
            testRecBtn.BackgroundImage = Properties.Resources.play;
        }

        private void testRecBtn_MouseEnter(object sender, EventArgs e)
        {
            testRecBtn.BackgroundImage = Properties.Resources.play_hover;
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
