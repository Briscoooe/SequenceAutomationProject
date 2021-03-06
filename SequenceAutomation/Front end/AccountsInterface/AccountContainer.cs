﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace SequenceAutomation
{
    public partial class AccountContainer : Form
    {
        public event EventHandler loggedInEvent;

        public AccountContainer()
        {
            InitializeComponent();
            MaximizeBox = false;
            MinimizeBox = false;
            CenterToScreen();

            options.GoBackEvent += close;
            options.LoginEvent += gotoLogin;
            options.RegisterEvent += gotoRegister;

            register1.GoBackEvent += gotoOptions;
            register1.RegisterEvent += gotoLogin;

            login1.GoBackEvent += gotoOptions;
            login1.LoginEvent += loggedIn;
        }

        private void loggedIn(object sender, EventArgs e)
        {
            if (loggedInEvent != null)
                loggedInEvent(this, e);
            Dispose();
        }

        private void gotoOptions(object sender, EventArgs e)
        {
            options.BringToFront();
            ClientSize = new Size(860, 458);
            CenterToScreen();
        }

        private void gotoRegister(object sender, EventArgs e)
        {
            register1.BringToFront();
            ClientSize = new Size(613, 713);
            CenterToScreen();
        }

        private void gotoLogin(object sender, EventArgs e)
        {
            login1.BringToFront();
            ClientSize = new Size(515, 415);
            CenterToScreen();
        }

        private void close(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
