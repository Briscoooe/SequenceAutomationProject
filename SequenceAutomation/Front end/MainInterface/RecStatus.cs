using System;
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
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();

            // Iinitialise the event handler and event handler
            Timer timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
            startTime = DateTime.Now;
            currentElapsedTime = TimeSpan.Zero;
            totalElapsedTime = currentElapsedTime;

            if (messageNum == 1)
                recButtonLabel.Text = "Stop recording";

            // Start the time
            timer.Interval = (1000) * (1);
            timer.Enabled = true;
            timer.Start();
        }

        // An event handler for each time the clock ticks
        private void timer_Tick(object sender, EventArgs e)
        {
            // Format the time into a human readable format
            var timeSinceStartTime = DateTime.Now - startTime;
            timeSinceStartTime = new TimeSpan(timeSinceStartTime.Hours,
                                              timeSinceStartTime.Minutes,
                                              timeSinceStartTime.Seconds);
            currentElapsedTime = timeSinceStartTime + totalElapsedTime;
            
            // Set the timer label to the time
            timerLabel.Text = timeSinceStartTime.ToString();
        }

        private void showMessage(object sender, EventArgs e)
        {
            if (stopButtonEvent != null)
                stopButtonEvent(this, e);
        }
    }
}