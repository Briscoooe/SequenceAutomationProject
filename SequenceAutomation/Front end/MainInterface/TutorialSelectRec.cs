using System;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;

namespace SequenceAutomation
{
    public partial class TutorialSelectRec : UserControl
    {
        /* 
         * TODO
         * Commmenting
         */

        public event EventHandler goBackEvent;
        public event EventHandler<TextEventArgs> goNextEvent;
        public event EventHandler gotoLoginEvent;

        public RecordingManager recording;
        private List<RecordingManager> recObjectList;
        private FavouritesBox fave;

        private List<string> recList;

        public ConnectionManager connectionManager;

        private string recJson;
        private string recTitle;


        public TutorialSelectRec()
        {
            InitializeComponent();
            recList = new List<string>();
            recObjectList = new List<RecordingManager>();

            recording = new RecordingManager();
        }

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

        private void returnJson(TextEventArgs e)
        {
            EventHandler<TextEventArgs> eh = goNextEvent;
            if (eh != null)
                eh(this, e);
        }

        public void prepareList()
        {
            connectionManager = new ConnectionManager();
            recList.Clear();
            if (connectionManager.testConnection())
            {
                foreach (RecordingManager rec in connectionManager.getRecordings())
                {
                    recObjectList.Add(rec);
                    recList.Add(rec.Title);
                }
            }

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
                    recJson = connectionManager.getRecInfo(rec.Id);
                    updateInfo(rec);
                }
            }
        }


        private void doneSelecting(object sender, EventArgs e)
        {
            recJson = fave.recJson;
            updateInfo();
        }

        private void showFavourites(object sender, EventArgs e)
        {
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

        private void chooseFile(object sender, EventArgs e)
        {
            openFileDialog.FileName = "";
            openFileDialog.DefaultExt = ".json";
            openFileDialog.Filter = "Recording file (.json) |*.json";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fullPath = openFileDialog.FileName;
                if (recording.validateJson(File.ReadAllText(fullPath)))
                {
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

        private void updateInfo(RecordingManager rec)
        {
            if (rec != null)
            {
                recTitleLabel.Text = rec.Title;
                recDescLabel.Text = rec.Description;
                recAuthorLabel.Text = rec.Author;
            }

        }

        private void updateInfo()
        {
            if (recJson != null && recJson != "")
            {
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

        private void goBack(object sender, EventArgs e)
        {
            if (goBackEvent != null)
                goBackEvent(this, e);
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
    }
}
