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
    public partial class Form1 : Form
    {
        string filePath;
        string fileName;
        DatabaseManager DBManager = new DatabaseManager();
        public Form1()
        {
            InitializeComponent();
        }

        public void ShowList()
        {
            DBManager.GetRecList();
        }

        public void SaveRec()
        {

        }

        public void EnterRecInfo()
        {

        }

        private void BrowseBtn_Click(object sender, EventArgs e)
        {
            OpenRecDialog.FileName = "Recording";
            OpenRecDialog.DefaultExt = ".xml";
            OpenRecDialog.Filter = "XML files (.xml)|*.xml";

            DialogResult result = OpenRecDialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                filePath = OpenRecDialog.FileName;
                fileName = OpenRecDialog.SafeFileName;
                CurrentRecTB.Text = fileName;
            }
        }

        private void UploadBtn_Click(object sender, EventArgs e)
        {
            DBManager.UploadRec(filePath, fileName);
        }

        private void DownloadBtn_Click(object sender, EventArgs e)
        {
            DBManager.GetRecList();
        }
    }//End class

}//End project
