using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace SequenceAutomation
{
    public static class ConnectionManager
    {

        /* 
         * TODO
         * Commmenting
         * Update method
         * Delete method
         */

        private static HttpWebRequest request;
        private static HttpWebResponse response;
        private static string responseStr;

        private static string recordingUrl = Properties.Settings.Default.recordingUrl;
        private static string usersUrl = Properties.Settings.Default.usersUrl;
        private static string domain = Properties.Settings.Default.domain;

        public static bool loginUser(string username, string password)
        {
            bool result;
            prepareRequest(usersUrl, "text/json", "POST");

            password = encryptPassword(password);
            JObject userInfo = new JObject(new JProperty("requestType", "login"),
                            new JProperty("username", username),
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
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    responseStr = reader.ReadToEnd();
                }
                string tmp = string.Join("", responseStr.Split('"', '{', '}', '\n'));
                string[] tmp2 = tmp.Split(':', ',');
                Properties.Settings.Default.currentUser = tmp2[1];
                Properties.Settings.Default.currentUserFirstname = tmp2[3];
                Properties.Settings.Default.currentUserSurname = tmp2[5];

                if (response.StatusCode == HttpStatusCode.Accepted)
                    result = true;
                else
                    result = false;

                response.Dispose();
            }
            catch (WebException we)
            {
                Console.WriteLine(we.Message);
                result = false;
            }

            return result;
        }

        public static bool testConnection()
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

        public static string register(List<string> userList)
        {
            string responseStr = "ERROR";
            if (userList[4] == userList[5])
            {
                if (validateEmail(userList[2]) == 1)
                {
                    if (!validateUsername(userList[3]))
                    {
                        prepareRequest(usersUrl, "text/json", "POST");

                        string password = encryptPassword(userList[4]);

                        JObject userInfo = new JObject(new JProperty("requestType", "register"),
                                        new JProperty("firstname", userList[0]),
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

                            using (var reader = new StreamReader(response.GetResponseStream()))
                            {
                                responseStr = reader.ReadToEnd();
                            }

                            responseStr = "REGISTER_SUCCESSFUL";

                            if (response != null)
                                response.Dispose();
                        }
                        catch (WebException we)
                        {
                            Console.WriteLine(we.Message);
                            responseStr = "CONNECTION_ERROR";
                        }
                    }

                    else
                        responseStr = "USERNAME_EXISTS";
                }
                else if (validateEmail(userList[2]) == 0)
                    responseStr = "EMAIL_EXISTS";

                else if (validateEmail(userList[2]) == 2)
                    responseStr = "EMAIL_INVALID";
            }
            else
                responseStr = "PASSWORD_NO_MATCH";

            return responseStr;
        }

        public static List<RecordingManager> getRecordings()
        {
            prepareRequest(recordingUrl, "", "GET");

            List<RecordingManager> dirContents = new List<RecordingManager>();

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
                    dirContents.Add(recording);
                }
            }

            if (response != null)
                response.Dispose();
            return dirContents;
        }

        public static string getRecInfo(string recId)
        {
            string extension = recId.Substring(recId.Length - 5);

            if(extension == ".json")
            {
                recId = recId.Remove(recId.Length - 5);
            }
            prepareRequest(recordingUrl + "/" + recId, "", "GET");
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
                throw;
            }

            if (response != null)
                response.Dispose();
            return responseStr;
        }

        public static bool uploadRecording(string jsonString)
        {
            prepareRequest(recordingUrl, "text/json", "POST");
            bool result = false;
            try
            {
                if(RecordingManager.validateJson(jsonString))
                {
                    using (var writer = new StreamWriter(request.GetRequestStream()))
                    {
                        writer.Write(jsonString);
                        writer.Flush();
                        writer.Close();
                    }

                    try
                    {
                        response = (HttpWebResponse)request.GetResponse();
                        HttpStatusCode code = response.StatusCode;
                        response.Dispose();
                        if (code == HttpStatusCode.Created)
                            result = true;
                        else
                            result = false;
                    }
                    catch (WebException we)
                    {
                        Console.WriteLine(we.Message);
                        result = false;
                    }

                }

            }

            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            return result;

        }

        public static bool deleteRecording(string recJson)
        {
            prepareRequest(recordingUrl, "text/json", "DELETE");
            RecordingManager recording = new RecordingManager(recJson);
            bool result = false;

            try
            {

                JObject recInfo = new JObject(
                    new JProperty("recId", recording.Id),
                    new JProperty("UserId", Properties.Settings.Default.currentUser));

                using (var writer = new StreamWriter(request.GetRequestStream()))
                {
                    writer.Write(recInfo.ToString());
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
                }

                response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                    result = true;
            }
            catch (WebException we)
            {
                Console.WriteLine(we.Message);
                result = false;
            }

            if (response != null)
                response.Dispose();
            return result;

        }

        private static string encryptPassword(string plaintextPassword)
        {
            var bytes = new UTF8Encoding().GetBytes(plaintextPassword);
            byte[] hashBytes;
            using (var algorithm = new SHA512Managed())
            {
                hashBytes = algorithm.ComputeHash(bytes);
            }
            string encryptedPassword = Convert.ToBase64String(hashBytes);
            encryptedPassword = string.Join("", encryptedPassword.Split('\\', '/'));

            return encryptedPassword;
        }

        private static bool prepareRequest(string url, string content, string method)
        {
            request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = method;
            if (content != "")
            {
                request.ContentType = "text/json";
            }

            // Accept all certificates
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback = delegate (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
            return true;
        }

        private static bool validateUsername(string username)
        {
            prepareRequest(usersUrl + "/" + username, "text/json", "GET");

            bool result;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                    result = true;
                else
                    result = false;
                if (response != null)
                    response.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                result = false;
            }

            return result;

        }

        private static int validateEmail(string email)
        {

            prepareRequest(usersUrl + "/email/" + email, "text/json", "GET");
            int result;
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);

                response = (HttpWebResponse)request.GetResponse();
                result = 0;
                if (response != null)
                    response.Dispose();
            }

            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                result = 2;
            }
            catch (WebException e)
            {
                Console.WriteLine(e.Message);
                result = 1;
            }

            return result;
        }
    }
}
