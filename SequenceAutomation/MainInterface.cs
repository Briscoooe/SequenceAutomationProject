using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.IO;
using System.Xml.Linq;
using System.Xml;

namespace SequenceAutomation
{
    public partial class MainInterface : Form
    {
        private CreateRecording createRec;
        private PlayRecording playRec;
        private bool isPressed = false;

        //Initialisation 
        public MainInterface()
        {
            InitializeComponent();
        }

        /*
         * method launchRecording()
         * Description : Starts to record the keys. Called when the "record" button is triggered.
         */
        private void launchRecording(object sender, EventArgs e)
        {
            createRec = null; // Reinitialise the createRec instance 
            createRec = new CreateRecording();
            createRec.Reset(); // Reinitialises the stopwatch and savedKeys 
            createRec.Start(); //Starts to save the keys
            startButton.Text = "Stop"; //Updates the button
            startButton.Click -= launchRecording;
            startButton.Click += stopRecording;
        }

        /*
         * method stopRecording()
         * Description : Stops to record the keys and logs the recorded keys in the console. Called when the "record" button is triggered.
         */
        private void stopRecording(object sender, EventArgs e)
        {
            isPressed = true;
            startButton.Text = "Record";//Updates the button
            startButton.Click += launchRecording;
            startButton.Click -= stopRecording;
            Dictionary<long, Dictionary<Keys, IntPtr>> keys = createRec.Stop(); //Gets the recorded keys
            //Console.WriteLine("\nCompleted list of keys");
            foreach (KeyValuePair<long, Dictionary<Keys, IntPtr>> keyVal in keys)
            {
                foreach (KeyValuePair<Keys, IntPtr> keyVal2 in keyVal.Value)
                {
                    /*
                    //Displays the recorded keys in the console
                    if (keyVal2.Value == CreateRecording.KEYDOWN)
                    {
                        Console.WriteLine(keyVal.Key + " : (down)" + keyVal2.Key);
                    }
                    if (keyVal2.Value == CreateRecording.KEYUP)
                    {
                        Console.WriteLine(keyVal.Key + " : (up)" + keyVal2.Key);
                    }*/
                }
            }
            playRec = new PlayRecording(keys); //Creates a new player and gives it the recorded keys.
        }

        /*
         * method launchPlaying()
         * Description : Starts to play the keys. Called when the "play" button is triggered.
         */
        private void launchPlaying(object sender, EventArgs e)
        {
            playRec.Start(); //Starts to play the keys.
        }


        /*
         * method startButton_click
         * Description: Auto-generated function to launch a recording
         */
        private void startButton_Click(object sender, EventArgs e)
        {
            launchRecording(sender, e);
        }

        /*
         * method playButton_click
         * Description: Auto-generated function launch a recording
         */
        private void playButton_Click(object sender, EventArgs e)
        {
            launchPlaying(sender, e);
        }

        /*
         * method stopButton_click
         * Description: Auto-generated function to stop creating a recording
         */
        private void stopButton_Click(object sender, EventArgs e)
        {
            stopRecording(sender, e);
        }
    }

}//End project
