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
        /* 
         * TODO
         * Commmenting
         */
        public event EventHandler BackButtonEvent;
        public event EventHandler ShowTutorialEvent;

        private CreateRecording createRec;
        private AccountContainer accountContainer;
        private RecordingManager recManager;
        private RecStatus recStatus;
        private ConnectionManager connectionManager;
        private PlayRecording playRec;
        private string recJson;

        public CreateRecUserControl()
        {
            InitializeComponent();
        }

        private void recStatus_StopCreate(object sender, EventArgs e)
        {
            stopRecording(sender, e);
        }

        private void recStatus_StopPlay(object sender, EventArgs e)
        {
            playRec.stopPlayback = true;
        }

        #region Navigation events
        private void showTutorial(object sender, EventArgs e)
        {
            if (ShowTutorialEvent != null)
                ShowTutorialEvent(this, e);
        }

        private void returnLogin(object sender, EventArgs e)
        {
            checkLogin();
        }

        /*
         * Method: goBack()
         * Summary: Returns to the previous screen
         * Parameter: sender - The control that the action is for, in this case the button
         * Parameter: e - Any arguments the function may use
         */
        private void goBack(object sender, EventArgs e)
        {
            if (BackButtonEvent != null)
                BackButtonEvent(this, e);
        }

        #endregion

        #region Button hover events

        private void startStopRecBtn_MouseEnter(object sender, EventArgs e)
        {
            if (startStopRecBtn.Tag.ToString() == "stopRecTag")
            {
                startStopRecBtn.BackgroundImage = Properties.Resources.stop_hover;
            }

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

        /*
         * Method: launchPlaying()
         * Summary: Begins the playback of keystrokes
         * Parameter: sender - The control that the action is for, in this case the button
         * Parameter: e - Any arguments the function may use
         */
        private void testRecording(object sender, EventArgs e)
        {

            // Display the status box containing the elapsed time and a stopbutton
            RecStatus recStatusbox = new RecStatus(2);
            recStatusbox.stopButtonEvent += recStatus_StopPlay;
            recStatusbox.Show();

            // If there are no keys loaded to play, display a message informing the user of this
            if (recJson == null)
            {
                BigMessageBox.Show("Error: There is no recording to play");
                return;
            }

            playRec = new PlayRecording(recJson, 1); // Initialise the playRec object with the keys returned from the createRec class
            playRec.Start(); // Begin playback
            recStatus.Dispose();
        }

        /*
         * Method: startRecording()
         * Summary: Begins the playback of keystrokes
         * Parameter: sender - The control that the action is for, in this case the button
         * Parameter: e - Any arguments the function may use
         */
        private void startRecording(object sender, EventArgs e)
        {
            startStopRecBtn.BackgroundImage = Properties.Resources.stop;
            recButtonLabel.Text = "Stop recording";
            recTitleTb.Text = "";
            recDescTb.Text = "";

            startStopRecBtn.Tag = "stopRecTag";

            createRec = new CreateRecording(); // Reinitialise the createRec variable, restarting the clock and clearning the dictionary of recorded keys
            createRec.Start(); // Begin recording

            recStatusText.ForeColor = Color.Green;
            recStatusText.Text = "Recording active";

            // Display the status box containing the elapsed time and a stopbutton
            recStatus = new RecStatus(1);
            recStatus.stopButtonEvent += recStatus_StopCreate;
            recStatus.Show();

            // Alter the button so that clicking no longer invokes the launchRecording method, but instead the stopRecording method
            startStopRecBtn.Click -= startRecording;
            startStopRecBtn.Click += stopRecording;
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
        }


        /*
         *
         */
        private void uploadRecording(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (validateInput(1))
            {
                connectionManager = new ConnectionManager();
                if (connectionManager.testConnection())
                {
                    recManager = new RecordingManager(recJson);
                    recJson = recManager.addInformation(recJson, recTitleTb.Text, recDescTb.Text);
                    if (connectionManager.uploadRecording(recJson))
                        BigMessageBox.Show("Uploaded");
                    else
                        BigMessageBox.Show("There was a problem with the server");
                }

                else
                {
                    BigMessageBox.Show("Could not connect to server");
                }
               
            }
            Cursor.Current = Cursors.Arrow;

        }

        private void saveFile(object sender, EventArgs e)
        {
            if (validateInput(0))
            {
                recManager = new RecordingManager(recJson);
                recJson = recManager.addInformation(recJson, recTitleTb.Text, recDescTb.Text);
                string test = Regex.Replace(recTitleTb.Text, @"[\W]", "");
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.FileName = test;
                dlg.DefaultExt = ".json";
                dlg.Filter = "Recording file (.json) |*.json";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(dlg.FileName, recJson);
                    BigMessageBox.Show("Saved successfully!");
                }
            }

        }


        private bool validateInput(int option)
        {
            if (Properties.Settings.Default.currentUser == "" && option == 1)
            {
                BigMessageBox.Show("You must be logged in to upload recordings. You can do this using the \"login\" option below");
                return false;
            }

            if (recJson == null)
            {
                BigMessageBox.Show("You must create a recording");
                return false;
            }

            if (recTitleTb.Text == "")
            {
                BigMessageBox.Show("You must enter a title");
                return false;
            }

            if(option == 1 && recDescTb.Text == "")
            {
                BigMessageBox.Show("You must enter a description");
                return false;
            }
            return true;
        }

        private void addToFavourites(object sender, EventArgs e)
        {
            if (validateInput(1))
            {
                if (recJson != "" && recJson != null)
                {
                    Console.WriteLine("recJson {0}", recJson);
                    recManager = new RecordingManager(recJson);
                    string test = recManager.addInformation(recJson, recTitleTb.Text, recDescTb.Text);
                    List<string> tmp = new List<string>();

                    Console.WriteLine("test: {0}", test);
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
                            Properties.Settings.Default.favouriteRecordings.Add(test);
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
            }

            Properties.Settings.Default.Save();


        }

        public bool checkLogin()
        {
            if(Properties.Settings.Default.currentUser == "")
            {
                loginBtn.Text = "Login";
            }

            else
            {
                loginBtn.Text = "Logout";
            }

            return true;
        }


        private void login(object sender, EventArgs e)
        {
            accountContainer = new AccountContainer();

            if(loginBtn.Text == "Login")
            {
                accountContainer.Show();
                accountContainer.loggedInEvent += returnLogin;
            }

            else
            {
                Properties.Settings.Default.currentUser = "";
                BigMessageBox.Show("Logged out");
                checkLogin();
            }
        }
    }
}
