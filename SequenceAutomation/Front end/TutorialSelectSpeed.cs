using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SequenceAutomation
{
    public partial class TutorialSelectSpeed : UserControl
    {
        public event EventHandler goBackEvent;
        public event EventHandler<TextEventArgs> goNextEvent;
        public event EventHandler gotoLoginEvent;

        private string recJson;

        public TutorialSelectSpeed()
        {
            InitializeComponent();
            speedDropDown.Items.Add("1 - Very slow");
            speedDropDown.Items.Add("2 - Slow");
            speedDropDown.Items.Add("3 - Average");
            speedDropDown.Items.Add("4 - Fast");
            speedDropDown.Items.Add("5 - Very fast");
            speedDropDown.SelectedIndex = 2;

        }

        private void goNext(object sender, EventArgs e)
        {
            returnJson(new TextEventArgs(recJson, "", speedDropDown.SelectedIndex));
        }

        private void returnJson(TextEventArgs e)
        {
            EventHandler<TextEventArgs> eh = goNextEvent;
            if (eh != null)
                eh(this, e);
        }

        private void goBack(object sender, EventArgs e)
        {
            if (goBackEvent != null)
                goBackEvent(this, e);
        }

        private void gotoLogin(object sender, EventArgs e)
        {
            if (gotoLoginEvent != null)
                gotoLoginEvent(this, e);
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
    }
}
