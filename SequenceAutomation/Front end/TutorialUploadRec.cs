using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

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

        public string mergedJson = "";
        private ConnectionManager connectionManager;

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
            returnJson(new TextEventArgs(mergedJson, "", 1));
        }

        public void returnJson(TextEventArgs e)
        {
            EventHandler<TextEventArgs> eh = goBackEvent;
            if (eh != null)
                eh(this, e);
        }

        private void saveFile(object sender, EventArgs e)
        {
            if (validateInput())
            {

                recManager = new RecordingManager(mergedJson);
                recManager.addInformation(mergedJson, recTitleTb.Text, recDescTb.Text);
                string test = Regex.Replace(recTitleTb.Text, @"[\W]", "");
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.FileName = test;
                dlg.DefaultExt = ".json";
                dlg.Filter = "Recording file (.json) |*.json";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(dlg.FileName, mergedJson);
                    MessageBox.Show("Saved successfully!");
                    recTitleTb.Text = "";
                    recDescTb.Text = "";
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
                connectionManager = new ConnectionManager();
                if (connectionManager.testConnection())
                {
                    recManager = new RecordingManager(mergedJson);
                    mergedJson = recManager.addInformation(mergedJson, recTitleTb.Text, recDescTb.Text);
                    if (connectionManager.Upload(mergedJson))
                        MessageBox.Show("Uploaded");
                    else
                        MessageBox.Show("There was a problem with the server");
                }

                else
                {
                    MessageBox.Show("Could not connect to server");
                }

            }

        }

        private bool validateInput()
        {
            if (recTitleTb.Text == "")
            {
                MessageBox.Show("You must enter a title");
                return false;
            }

            else
                return true;
        }

        private bool validateInput(int option)
        {
            if (mergedJson == null)
            {
                MessageBox.Show("You must create a recording");
                return false;
            }

            if (recTitleTb.Text == "")
            {
                MessageBox.Show("You must enter a title");
                return false;
            }

            if (option == 1 && recDescTb.Text == "")
            {
                MessageBox.Show("You must enter a description");
                return false;
            }

            Console.WriteLine("Input valid");
            return true;
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
