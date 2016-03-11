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
        private string recJson;
        public List<string> recList;
        public FavouritesBox()
        {
            InitializeComponent();
            prepareList();
        }

        private void searchListUpdate(object sender, KeyEventArgs e)
        {
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
            recordingsList.DataSource = temp;
        }

        public void prepareList()
        {
            recList = new List<string>();

            foreach (string s in Properties.Settings.Default.favouriteRecordings.ToArray())
            {
                recList.Add(s);
            }
            recordingsList.DataSource = recList;
            ActiveControl = recordingsList;
        }

        private void updateList(object sender, EventArgs e)
        {
            //recJson = connectionManager.getRecInfo(recordingsList.SelectedItem.ToString());
            //updateInfo();
        }

        private void updateInfo()
        {
            /*
            dynamic tempObj = JsonConvert.DeserializeObject(recJson);

            if (tempObj.Name == "" || tempObj.Name == null)
            {
                tempObj.Name = "Unavailable";
            }

            if (tempObj.Desc == "" || tempObj.Desc == null)
            {
                tempObj.Desc = "Unavailable";
            }

            recTitleLabel.Text = tempObj.Name;
            recDescLabel.Text = tempObj.Desc;*/

        }
    }
}
