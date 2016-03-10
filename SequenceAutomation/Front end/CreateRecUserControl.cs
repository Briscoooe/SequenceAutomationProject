using System;
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
        private RecordingManager recManager;
        private ConnectionManager connectionManager;
        private PlayRecording playRec;
        private string mergedJson;

        public CreateRecUserControl()
        {
            InitializeComponent();
        }

        private void showTutorial(object sender, EventArgs e)
        {
            if (ShowTutorialEvent != null)
                ShowTutorialEvent(this, e);
        }

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

        /*
         * Method: goBack()
         * Summary: Returns to the previous screen
         * Parameter: sender - The control that the action is for, in this case the button
         * Parameter: e - Any arguments the function may use
         */
        private void goBack(object sender, EventArgs e)
        {
            if(BackButtonEvent != null)
                BackButtonEvent(this, e);
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
            if (mergedJson == null)
            {
                BigMessageBox.Show("Error: There is no recording to play");
                return;
            }
            playRec = new PlayRecording(mergedJson, 1); // Initialise the playRec object with the keys returned from the createRec class
            playRec.Start(); // Begin playback
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
            clearText();

            startStopRecBtn.Tag = "stopRecTag";


            createRec = new CreateRecording(); // Reinitialise the createRec variable, restarting the clock and clearning the dictionary of recorded keys
            createRec.Start(); // Begin recording

            recStatusText.ForeColor = Color.Green;
            recStatusText.Text = "Recording active";

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


            // Alter the button so that clicking no longer invokes the stopRecording method, but instead the launchRecording method
            startStopRecBtn.Click += startRecording;
            startStopRecBtn.Click -= stopRecording;
            mergedJson = createRec.Stop(); // Stop recording  
        }

        /*
         *
         */
        private void uploadRecording(object sender, EventArgs e)
        {
            if(validateInput(1))
            {
                connectionManager = new ConnectionManager();
                if (connectionManager.testConnection())
                {
                    recManager = new RecordingManager(mergedJson);
                    mergedJson = recManager.addInformation(mergedJson, recTitleTb.Text, recDescTb.Text);
                    if (connectionManager.upload(mergedJson))
                        BigMessageBox.Show("Uploaded");
                    else
                        BigMessageBox.Show("There was a problem with the server");
                }

                else
                {
                    BigMessageBox.Show("Could not connect to server");
                }
               
            }
           
        }

        private void saveFile(object sender, EventArgs e)
        {
            if (validateInput(0))
            {
                recManager = new RecordingManager(mergedJson);
                mergedJson = recManager.addInformation(mergedJson, recTitleTb.Text, recDescTb.Text);
                string test = Regex.Replace(recTitleTb.Text, @"[\W]", "");
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.FileName = test;
                dlg.DefaultExt = ".json";
                dlg.Filter = "Recording file (.json) |*.json";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(dlg.FileName, mergedJson);
                    BigMessageBox.Show("Saved successfully!");
                    clearText();
                }
            }

        }

        private void clearText()
        {
            recTitleTb.Text = "";
            recDescTb.Text = "";
        }

        private bool validateInput(int option)
        {
            if(mergedJson == null)
            {
                BigMessageBox.Show("You must create a recording", "Error");
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
    }
}
