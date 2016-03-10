﻿using System;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
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

        private List<string> recList;


        public RecordingManager recManager;
        public ConnectionManager connectionManager;

        private string recJson;
        private string recTitle;


        public TutorialSelectRec()
        {
            InitializeComponent();
            recList = new List<string>();

            recManager = new RecordingManager();
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
                MessageBox.Show("You must choose a recording to continue to the next screen");
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
            if (connectionManager.testConnection())
            {
                recList = connectionManager.getRecordings();
                recordingsList.DataSource = recList;
                ActiveControl = recordingsList;
            }

            else
            {
                MessageBox.Show("Could not connect to server");
            }
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
            recordingsList.DataSource = temp;
        }

        private void updateList(object sender, EventArgs e)
        {
            Console.WriteLine("UpdateList");
            recJson = connectionManager.getRecInfo(recordingsList.SelectedItem.ToString());
            updateInfo();
        }

        private void chooseFile(object sender, EventArgs e)
        {
            openFileDialog.FileName = "";
            openFileDialog.DefaultExt = ".json";
            openFileDialog.Filter = "Recording file (.json) |*.json";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fullPath = openFileDialog.FileName;
                if (recManager.validateJson(File.ReadAllText(fullPath)))
                {
                    recJson = File.ReadAllText(fullPath);
                    recTitle = Path.GetFileNameWithoutExtension(fullPath);
                    updateInfo();
                }
                else
                {
                    MessageBox.Show("That file was not a valid recording file");
                }
            }
        }

        private void updateInfo()
        {
            Console.WriteLine("UpdateInfo");
            dynamic tempObj = JsonConvert.DeserializeObject(recJson);
            recTitleLabel.Text = tempObj.Name;
            recDescLabel.Text = tempObj.Desc;
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
