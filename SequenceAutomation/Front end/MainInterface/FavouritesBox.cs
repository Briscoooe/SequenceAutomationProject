using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SequenceAutomation
{
    public partial class FavouritesBox : Form
    {
        public string recJson;
        private Dictionary<string,string> recList;
        public event EventHandler doneSelectingEvent;
        public RecordingManager recording;

        public FavouritesBox()
        {
            InitializeComponent();
            CenterToScreen();
            MaximizeBox = false;
            MinimizeBox = false;
            prepareList();
        }

        private void searchListUpdate(object sender, KeyEventArgs e)
        {
            List<string> temp = new List<string>();
            foreach (KeyValuePair<string, string> kvp in recList)
            {
                if (kvp.Key.ToLower().Contains(searchBox.Text.ToLower()))
                {
                    temp.Add(kvp.Key);
                }
            }

            if (temp.Count == 0)
            {
                temp.Add("No results");
                recTitleLabel.Text = "Unavailable";
                recDescLabel.Text = "Unavailable";
            }
            recordingsList.DataSource = temp;
        }

        public void prepareList()
        {
            recList = new Dictionary<string, string>();

            foreach (string rec in Properties.Settings.Default.favouriteRecordings.ToArray())
            {

                if (rec != "")
                {
                    Console.WriteLine(recList.Count);
                    recording = new RecordingManager(rec);

                    if (!recList.ContainsKey(recording.Title))
                    {
                        recList.Add(recording.Title, rec);
                    }

                }

                else
                {
                    Console.WriteLine( recList.Count);
                }
            }

            if(recList.Count == 0)
            {
                recList.Add("No favourites", "");
                recTitleLabel.Text = "Unavailable";
                recDescLabel.Text = "Unavailable";
            }
            recordingsList.DataSource = (from keys in recList.Keys select keys).ToList();
            ActiveControl = recordingsList;
            object x = new object();
            EventArgs y = new EventArgs();
            updateInfo(x, y);
        }

        private void updateInfo(object sender, EventArgs e)
        {
            string activeRecTitle = recordingsList.SelectedItem.ToString();
            foreach(KeyValuePair<string, string> kvp in recList)
            {
                if(kvp.Key == activeRecTitle)
                {
                    recJson = kvp.Value;
                }
            }

            string title = "Unavailable";
            string description = "Unavailable";

            if (recJson != "")
            {
                recording = new RecordingManager(recJson);
                if (recording.Title == "" || recording.Title == null)
                {
                    title = "Unavailable";
                }

                else
                {
                    title = recording.Title;
                }

                if (recording.Description == "" || recording.Description == null)
                {
                    description = "Unavailable";
                }

                else
                {
                    description = recording.Description;
                }
            }

            recTitleLabel.Text = title;
            recDescLabel.Text = description;

        }

        private void deleteFavourite(object sender, EventArgs e)
        {
            foreach (string rec in Properties.Settings.Default.favouriteRecordings.ToArray())
            {
                if(rec != "")
                {
                    recording = new RecordingManager(rec);

                    if (Convert.ToString(recording.Title) == recordingsList.SelectedItem.ToString())
                    {
                        Properties.Settings.Default.favouriteRecordings.Remove(rec);
                        BigMessageBox.Show("Removed from favourites");
                        prepareList();
                        Properties.Settings.Default.Save();
                        break;
                    }
                }
            }
        }

        private void doneSelecting(object sender, EventArgs e)
        {
            Hide();
            if (doneSelectingEvent != null)
                doneSelectingEvent(this, e);
        }

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

    }
}
