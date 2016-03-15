using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;

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

        string domain, urlString;

        public ConnectionManager()
        {
            urlString = Properties.Settings.Default.urlString;
            domain = Properties.Settings.Default.domain;
        }

        public bool testConnection()
        {
            try
            {
                TcpClient client = new TcpClient();
                if (!client.ConnectAsync(domain, 80).Wait(2000))
                {
                    return false;
                }
            }
            catch (AggregateException e)
            {
                Console.WriteLine(e.InnerException.Message);
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

            string tmp = string.Join("", responseStr.Split('"', '[', ']'));
            string[] tmp2 = tmp.Split(',');
            foreach (string t in tmp2)
            {
                if(t != "." && t != "..")
                {
                    string tmp3 = getRecInfo(t);
                    Recording recording = new Recording(tmp3);
                    string tempName = Convert.ToString(recording.Title);
                    dirContents.Add(tempName);
                }
            }
            dirContents.Sort();
            return dirContents;
        }

        public string getRecInfo(string recTitle)
        {
            if(recTitle.Substring(recTitle.Length -5) != ".json")
            {
                recTitle = string.Join("", recTitle.Split(' ', '_', '-')) + ".json";
            }
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

        public bool upload(string jsonString)
        {
            request = (HttpWebRequest)WebRequest.Create(urlString);
            request.ContentType = "text/json";
            request.Method = "POST";

            using (var writer = new StreamWriter(request.GetRequestStream()))
            {
                writer.Write(jsonString);
                writer.Flush();
                writer.Close();
            }

            try
            {
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
            return true;
        }
    }
}
