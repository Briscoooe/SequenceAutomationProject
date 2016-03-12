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

        public FavouritesBox()
        {
            InitializeComponent();
            prepareList();
        }

        private void searchListUpdate(object sender, KeyEventArgs e)
        {
           /*
            List<string> temp = new List<string>();
            for (int i = 0; i < recList.Count; i++)
            {
                if (recList[i].ToLower().Contains(searchBox.Text.ToLower()))
                {
                    temp.Add(recList[i]);
                }
            }
            if (temp.Count == 0)
            {
                temp.Add("No results");
            }
            recordingsList.DataSource = temp;*/
        }

        public void prepareList()
        {
            recList = new Dictionary<string, string>();

            foreach (string rec in Properties.Settings.Default.favouriteRecordings.ToArray())
            {

                if (rec != "")
                {
                    Console.WriteLine(recList.Count);
                    dynamic tempObj = JsonConvert.DeserializeObject(rec);
                    string recName = tempObj.Name;

                    if (!recList.ContainsKey(recName))
                    {
                        recList.Add(recName, rec);
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

            string name = "Unavailable";
            string description = "Unavailable";

            if (recJson != "")
            {
                dynamic tempObj = JsonConvert.DeserializeObject(recJson);

                if (tempObj.Name == "" || tempObj.Name == null)
                {
                    name = "Unavailable";
                }

                else
                {
                    name = tempObj.Name;
                }

                if (tempObj.Desc == "" || tempObj.Desc == null)
                {
                    description = "Unavailable";
                }

                else
                {
                    description = tempObj.Desc;
                }
            }

            recTitleLabel.Text = name;
            recDescLabel.Text = description;

        }

        private void deleteFavourite(object sender, EventArgs e)
        {
            foreach (string rec in Properties.Settings.Default.favouriteRecordings.ToArray())
            {
                if(rec != "")
                {
                    dynamic tempObj = JsonConvert.DeserializeObject(rec);

                    if (Convert.ToString(tempObj.Name) == recordingsList.SelectedItem.ToString())
                    {
                        Properties.Settings.Default.favouriteRecordings.Remove(rec);
                        BigMessageBox.Show("Removed from favourites");
                        prepareList();
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
