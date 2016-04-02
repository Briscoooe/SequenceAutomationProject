using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections.Generic;

namespace SequenceAutomation
{
    public partial class TutorialUploadRec : UserControl
    {

        /* 
         * TODO
         * Commmenting
         */

        public event EventHandler gotoLoginEvent;
        public event EventHandler goNextEvent;
        public event EventHandler<TextEventArgs> goBackEvent;
        private RecordingManager recManager;
        private AccountContainer accountContainer;

        public string recJson = "";

        public TutorialUploadRec()
        {
            InitializeComponent();
        }


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

        private void addToFavourites(object sender, EventArgs e)
        {
            if(validateInput(0))
            {
                if (recJson != "" && recJson != null)
                {
                    string test = RecordingManager.addInformation(recJson, recTitleTb.Text, recDescTb.Text);
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

        private void saveFile(object sender, EventArgs e)
        {
            if (validateInput(0))
            {
                recJson = RecordingManager.addInformation(recJson, recTitleTb.Text, recDescTb.Text);
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

        /*
         *
         */
        private void uploadRecording(object sender, EventArgs e)
        {
            if (validateInput(1))
            {
                if (ConnectionManager.testConnection())
                {
                    recJson = RecordingManager.addInformation(recJson, recTitleTb.Text, recDescTb.Text);
                    if (ConnectionManager.uploadRecording(recJson))
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

            if (recDescTb.Text == "")
            {
                BigMessageBox.Show("You must enter a description");
                return false;
            }

            return true;
        }

        public bool checkLogin()
        {
            if (Properties.Settings.Default.currentUser == "")
            {
                loginBtn.Text = "Login";
            }

            else
            {
                loginBtn.Text = "Logout";
            }

            return true;
        }

        private void returnLogin(object sender, EventArgs e)
        {
            checkLogin();
        }

        private void login(object sender, EventArgs e)
        {
            accountContainer = new AccountContainer();

            if (loginBtn.Text == "Login")
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

    }
}
