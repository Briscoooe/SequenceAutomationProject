using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Security.Cryptography;

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

        string domain, recordingUrl, usersUrl;

        public ConnectionManager()
        {
            recordingUrl = Properties.Settings.Default.recordingUrl;
            usersUrl = Properties.Settings.Default.usersUrl;
            domain = Properties.Settings.Default.domain;
        }

        public bool loginUser(string username, string password)
        {
            prepareRequest(usersUrl + "/" + username, "text/json", "GET");

            try
            {
                response = (HttpWebResponse)request.GetResponse();

                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    responseStr = reader.ReadToEnd();
                }
                string tmp = string.Join("", responseStr.Split('{', '}', '"'));
                string[] tmp2 = tmp.Split(':');
                foreach (string t in tmp2)
                {
                    Console.WriteLine("\n{0}", t);
                    Console.WriteLine("{0}", encryptPassword(password));
                    if(t == encryptPassword(password))
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
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

        public bool prepareRequest(string url, string content, string method)
        {
            request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = method;
            if(content != "")
            {
                request.ContentType = "text/json";
            }

            return true;
        }

        public bool register(List<string> userList)
        {
            prepareRequest(usersUrl, "text/json", "POST");

            string password = encryptPassword(userList[4]);

            JObject userInfo = new JObject(new JProperty("firstname", userList[0]),
                            new JProperty("surname", userList[1]),
                            new JProperty("email", userList[2]),
                            new JProperty("username", userList[3]),
                            new JProperty("password", password));

            using (var writer = new StreamWriter(request.GetRequestStream()))
            {
                writer.Write(userInfo.ToString());
                writer.Flush();
                writer.Close();
            }

            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException we)
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

        public bool validateUsername(string username)
        {
            prepareRequest(usersUrl + "/" +  username, "text/json", "GET");

            try
            {
                response = (HttpWebResponse)request.GetResponse();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            
        }

        public int validateEmail(string email)
        {

            prepareRequest(usersUrl + "/emails/" + email, "text/json", "GET");

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);

                response = (HttpWebResponse)request.GetResponse();
                return 0;
            }

            catch(FormatException e)
            {
                Console.WriteLine(e.Message);
                return 2;
            }
            catch (WebException e)
            {
                Console.WriteLine(e.Message);
                return 1;
            }
        }

        public List<string> getRecordings()
        {
            prepareRequest(recordingUrl, "", "GET");

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

            RecordingManager recording;
            string tmp = string.Join("", responseStr.Split('"', '[', ']', ' ', '\n'));
            string[] tmp2 = tmp.Split(',');
            foreach (string t in tmp2)
            {
                if(t != "." && t != "..")
                {
                    string tmp3 = getRecInfo(t);
                    recording = new RecordingManager(tmp3);
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

            prepareRequest(recordingUrl + "/" + recTitle, "", "GET");

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

        public bool uploadRecording(string jsonString)
        {
            prepareRequest(recordingUrl, "text/json", "POST");

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

        public bool deleteRecording(string recJson)
        {
            prepareRequest(recordingUrl, "text/json", "DELETE");

            return true;
        }

        public string encryptPassword(string plaintextPassword)
        {
            var bytes = new UTF8Encoding().GetBytes(plaintextPassword);
            byte[] hashBytes;
            using (var algorithm = new SHA512Managed())
            {
                hashBytes = algorithm.ComputeHash(bytes);
            }
            return Convert.ToBase64String(hashBytes);
        }
    }
}
