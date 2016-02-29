using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SequenceAutomation
{
    public partial class TutorialSelectRec : UserControl
    {
        public event EventHandler goBackEvent;
        public event EventHandler<TextEventArgs> goNextEvent;
        public event EventHandler gotoLoginEvent;

        private string recJson;
        private string recTitle;


        public TutorialSelectRec()
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
            if (recJson == null)
            {
                MessageBox.Show("You must create a recording to continue to the next screen");
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

        public void chooseFile(object sender, EventArgs e)
        {
            openFileDialog.FileName = "";
            openFileDialog.DefaultExt = ".json";
            openFileDialog.Filter = "Recording file (.json) |*.json";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fullPath = openFileDialog.FileName;
                recTitle = Path.GetFileNameWithoutExtension(fullPath);
                recNameLabel.Text = recTitle;
                recJson = File.ReadAllText(fullPath);
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
