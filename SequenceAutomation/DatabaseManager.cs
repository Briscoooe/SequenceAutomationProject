using System;
using System.Net;
using System.Security;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Windows.Forms;

namespace SequenceAutomation
{
    class DatabaseManager
    {
        #region Variable declarations

        HttpWebRequest Request;
        HttpWebResponse Response;

        string serverURL = "http://finalyearproject.cloudapp.net";
        string query = "";
        byte[] bytes = null;

        #endregion

        #region Public methods

        public bool TestConnection()
        {
            return true;
        }

        public bool UploadRec()
        {
            return true;
        }

        public bool DownloadRec()
        {
            return true;
        }

        public void GetRecList()
        {

        }

        public void GetRecInfo()
        {
           
        }

        public void SearchRec()
        {

        }

        #endregion
    }
}
