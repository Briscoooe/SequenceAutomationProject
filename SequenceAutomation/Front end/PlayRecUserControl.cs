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
    public partial class PlayRecUserControl : UserControl
    {
        public event EventHandler BackButtonEvent;
        public event EventHandler TutorialEvent;
        public event EventHandler gotoLoginEvent;

        private PlayRecording playRec;
        private ToolTip tooltip;

        public string recJson = "";
        public string recTitle = "";
        public float recSpeed = 1;

        public int recSpeedVal = 3;

        public string temptooltiptext = "";


        public PlayRecUserControl()
        {
            InitializeComponent();
            onSpeedChange();

            tooltip = new ToolTip();
            tooltip.AutoPopDelay = 5000;
            tooltip.InitialDelay = 1000;
            tooltip.ReshowDelay = 500;
            tooltip.Draw += new DrawToolTipEventHandler(tooltip_Draw);
            tooltip.Popup += new PopupEventHandler(tooltip_Popup);

            tooltip.ShowAlways = true;

            tooltip.SetToolTip(playRecBtn, "Play the recording");
            tooltip.SetToolTip(goBackBtn, "Return to the previous page");
            tooltip.SetToolTip(homeBtn, "Go to the home screen");
            tooltip.SetToolTip(addFavouriteBtn, "Add to favourites");
            tooltip.SetToolTip(favouriteBtn, "Choose a recording from favourites");
            tooltip.SetToolTip(browseBtn,  "Choose a recording from local storage");
            tooltip.SetToolTip(increaseBtn, "Increase the playback speed of the recording");
            tooltip.SetToolTip(decreaseBtn, "Decrease the playback speed of the recording");

        }

        private void tooltip_Draw(object sender, DrawToolTipEventArgs e)
        {
            Font tooltipFont = new Font("calibri", 15.0f);
            e.DrawBackground();
            e.DrawBorder();
            temptooltiptext = e.ToolTipText;
            e.Graphics.DrawString(e.ToolTipText, tooltipFont, Brushes.Black, new PointF(2, 2));
        }

        private void tooltip_Popup(object sender, PopupEventArgs e)
        {
            e.ToolTipSize = TextRenderer.MeasureText(tooltip.GetToolTip(e.AssociatedControl), new Font("calibri", 15.0f));
        }

        /*
         * Method: launchPlaying()
         * Summary: Begins the playback of keystrokes
         * Parameter: sender - The control that the action is for, in this case the button
         * Parameter: e - Any arguments the function may use
         */
        private void playRecording(object sender, EventArgs e)
        {
            // If there are no keys loaded to play, display a message informing the user of this
            if (recJson == "")
            {
                MessageBox.Show("Error: There is no recording to play");
                return;
            }

            Console.WriteLine("\nREC SPEED BEFORE EXEC {0}", recSpeed.ToString());
            playRec = new PlayRecording(recJson, recSpeed); // Initialise the playRec object with the keys returned from the createRec class
            playRec.Start(); // Begin playback
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

        private void increaseSpeed(object sender, EventArgs e)
        {
            if (recSpeedVal < 5)
            {
                recSpeedVal++;
                onSpeedChange();
            }

            Console.WriteLine(recSpeedVal.ToString());
        }

        private void decreaseSpeed(object sender, EventArgs e)
        {
            if (recSpeedVal > 1)
            {
                recSpeedVal--;
                onSpeedChange();
            }
            Console.WriteLine(recSpeedVal.ToString());
        }

        private void onSpeedChange()
        {
            switch (recSpeedVal.ToString())
            {
                case "1":
                    recSpeedLabel.Text = "1 - Very slow";
                    recSpeed = 3;
                    break;
                case "2":
                    recSpeedLabel.Text = "2 - Slow";
                    recSpeed = 2;
                    break;
                case "3":
                    recSpeedLabel.Text = "3 - Normal";
                    recSpeed = 1;
                    break;
                case "4":
                    recSpeedLabel.Text = "4 - Fast";
                    recSpeed = .75F;
                    break;
                case "5":
                    recSpeedLabel.Text = "5 - Very fast";
                    recSpeed = .5F;
                    break;
                default:
                    break;
            }
        }

        public void goBack(object sender, EventArgs e)
        {
            if (BackButtonEvent != null)
                BackButtonEvent(this, e);
        }

        public void showTutorial(object sender, EventArgs e)
        {
            if (TutorialEvent != null)
                TutorialEvent(this, e);
        }

        private void gotoLogin(object sender, EventArgs e)
        {
            if (gotoLoginEvent != null)
                gotoLoginEvent(this, e);
        }

        private void playRecBtn_MouseLeave(object sender, EventArgs e)
        {
            playRecBtn.BackgroundImage = Properties.Resources.play;
        }

        private void playRecBtn_MouseEnter(object sender, EventArgs e)
        {
            playRecBtn.BackgroundImage = Properties.Resources.play_hover;
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

        private void increaseBtn_MouseLeave(object sender, EventArgs e)
        {
            increaseBtn.BackgroundImage = Properties.Resources.uparrow;
        }

        private void increaseBtn_MouseEnter(object sender, EventArgs e)
        {
            increaseBtn.BackgroundImage = Properties.Resources.uparrow_hover;
        }

        private void decreaseBtn_MouseLeave(object sender, EventArgs e)
        {
            decreaseBtn.BackgroundImage = Properties.Resources.downarrow;
        }

        private void decreaseBtn_MouseEnter(object sender, EventArgs e)
        {
            decreaseBtn.BackgroundImage = Properties.Resources.downarrow_hover;
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

        private void addFavouriteBtn_MouseEnter(object sender, EventArgs e)
        {
            addFavouriteBtn.BackgroundImage = Properties.Resources.addtofavourites_hover;
        }

        private void addFavouriteBtn_MouseLeave(object sender, EventArgs e)
        {
            addFavouriteBtn.BackgroundImage = Properties.Resources.addtofavourites;
        }

    }
}
