using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SequenceAutomation
{
    public class ConnectionManager
    {

        /* 
         * TODO
         * Commmenting
         * Update method
         * Delete method
         */

        HttpWebRequest request;
        HttpWebResponse response;
        string responseStr;

        string urlString = "http://finalyearproject.cloudapp.net/easyAutomator/app/index.php/recordings";
        string domain = "finalyearproject.cloudapp.net";
        IPAddress ip;
        public ConnectionManager() {}

        public bool testConnection()
        {
            TcpClient client = new TcpClient();
            if (!client.ConnectAsync(domain, 80).Wait(1000))
            {
                return false;
            }

            return true;
        }

        public List<string> getRecordings()
        {
            request = (HttpWebRequest)WebRequest.Create(urlString);
            request.Method = "GET";
            List<string> dirContents = new List<string>();

            try
            {
                response = (HttpWebResponse)request.GetResponse();

                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    responseStr = reader.ReadToEnd();
                }
            }
            catch (WebException we)
            {
                Console.WriteLine(we.Message);
                dirContents = null;
            }

            string tmp = string.Join("", responseStr.Split('"','[',']'));
            string[] tmp2 = tmp.Split(',');
            foreach (string t in tmp2)
            {
                dirContents.Add(t);
            }
            return dirContents;
        }

        public string getRecInfo(string recTitle)
        {
            request = (HttpWebRequest)WebRequest.Create(urlString + "/" + recTitle);
            request.Method = "GET";

            try
            {
                response = (HttpWebResponse)request.GetResponse();

                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    responseStr = reader.ReadToEnd();
                }
            }
            catch (WebException we)
            {
                Console.WriteLine(we.Message);
            }

            return responseStr;
        }

        public bool Upload(string jsonString)
        {
            request = (HttpWebRequest)WebRequest.Create(urlString);
            request.ContentType = "text/json";
            request.Method = "POST";

            using (var writer = new StreamWriter(request.GetRequestStream()))
            {
                Console.WriteLine("\nUpload string: {0}", jsonString);
                writer.Write(jsonString);
                writer.Flush();
                writer.Close();
            }

            try {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch(WebException we)
            {
                Console.WriteLine(we.Message);
                return false;
            }

            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                responseStr = reader.ReadToEnd();
            }

            Console.WriteLine("\nResponseStr: {0}", responseStr);
            return true;
        }
    }
}
