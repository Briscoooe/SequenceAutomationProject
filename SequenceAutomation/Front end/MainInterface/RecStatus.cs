using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SequenceAutomation
{
    public partial class RecStatus : Form
    {
        public event EventHandler stopButtonEvent;
        private DateTime startTime;
        private TimeSpan currentElapsedTime;
        private TimeSpan totalElapsedTime;

        public RecStatus(int messageNum)
        {
            InitializeComponent();
            Timer timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);

            startTime = DateTime.Now;
            currentElapsedTime = TimeSpan.Zero;
            totalElapsedTime = currentElapsedTime;

            if (messageNum == 1)
                recButtonLabel.Text = "Stop recording";
            else if (messageNum == 2)
                recButtonLabel.Text = "Stop playback";

            timer.Interval = (1000) * (1);
            timer.Enabled = true;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            var timeSinceStartTime = DateTime.Now - startTime;
            timeSinceStartTime = new TimeSpan(timeSinceStartTime.Hours,
                                              timeSinceStartTime.Minutes,
                                              timeSinceStartTime.Seconds);
            currentElapsedTime = timeSinceStartTime + totalElapsedTime;


            timerLabel.Text = timeSinceStartTime.ToString();
        }

        private void showMessage(object sender, EventArgs e)
        {
            if (stopButtonEvent != null)
                stopButtonEvent(this, e);
        }

        private void RecStatus_Load(object sender, EventArgs e)
        {

        }
    }
}