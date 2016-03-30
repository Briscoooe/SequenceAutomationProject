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

        #region Variable declarations
        private static HttpWebRequest request;
        private static HttpWebResponse response;
        private static string responseStr;

        #endregion

        #region Variable initialisations
        // Instantiating the URL and domain variables with the values stored in the application settings
        private static string recordingUrl = Properties.Settings.Default.recordingUrl;
        private static string usersUrl = Properties.Settings.Default.usersUrl;
        private static string domain = Properties.Settings.Default.domain;
        #endregion

        #region Public methods
        /*
        * Method: testConnection()
        * Summary: Attempts to establish a TCP connection with the server to prove that it can be successfully reached
        * Returns: Returns true or false depending on the success or failure of the connection test
        */
        public static bool testConnection()
        {
            try
            {
                // Attempt to connect to the domain specified in the application settings
                // If the connection cannot be established, return false
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

        /*
        * Method: loginUser()
        * Summary: Attempts to log in the user by validating the passed in credentials against the values stored in the MySQL database
        * Parameter: username - The username of the user attempting to log in
        * Parameter: password - The password of the user attempting to log in
        * Returns: True or false depending on the success or failure of the login attempt
        */
        public static bool loginUser(string username, string password)
        {
            bool result;

            // Prepare the POST HTTP request to the "users" endpoint 
            prepareRequest(usersUrl, "text/json", "POST");

            // Encrypt the password before sending so as to match the value stored in the database
            password = encryptPassword(password);

            // Create the JSON object to be sent in the HTTP request, with the request type specified as "login"
            JObject userInfo = new JObject(new JProperty("requestType", "login"),
                            new JProperty("username", username),
                            new JProperty("password", password));

            // POST the JSON string to the server via the HTTP request which queries the database with the credentials passed to the function
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

                // Trim the unnecessary characters from the response string
                string tmp = string.Join("", responseStr.Split('"', '{', '}', '\n'));
                // Split the remaining contents at each "," and ":" and store the results as an array
                string[] tmp2 = tmp.Split(':', ',');
                
                // Store the necessary user credentials in the application settings
                Properties.Settings.Default.currentUser = tmp2[1];
                Properties.Settings.Default.currentUserFirstname = tmp2[3];
                Properties.Settings.Default.currentUserSurname = tmp2[5];

                // If the HTTP status code is "Accepted", return true. Otherwise return false
                if (response.StatusCode == HttpStatusCode.Accepted)
                    result = true;
                else
                    result = false;

                // Dispose the response variable
                response.Dispose();
            }
            catch (WebException we)
            {
                Console.WriteLine(we.Message);
                result = false;
            }

            return result;
        }


        /*
        * Method: register()
        * Summary: Attempts to register a user by validating the input and writing the values to the MySQL databse on the server
        * Parameter: userList - An array containing the registration details entered by the user
        * Returns: A string containing an error confirmation message based on the success or failure of the registration
        */
        public static string register(List<string> userList)
        {
            string responseStr = "ERROR";
            // If the passwords match
            if (userList[4] == userList[5])
            {
                // If the email is valid and not already in the MySQL database
                if (validateEmail(userList[2]) == 1)
                {
                    // If the username does not exist in the database
                    if (!validateUsername(userList[3]))
                    {
                        // Prepare a POST HTTP request to the "users" endpoint
                        prepareRequest(usersUrl, "text/json", "POST");

                        // Encrypt the password to be stored in the database
                        string password = encryptPassword(userList[4]);

                        // Create the JSON string to be sent with the HTTP request, with the request type specified as "register"
                        JObject userInfo = new JObject(new JProperty("requestType", "register"),
                                        new JProperty("firstname", userList[0]),
                                        new JProperty("surname", userList[1]),
                                        new JProperty("email", userList[2]),
                                        new JProperty("username", userList[3]),
                                        new JProperty("password", password));

                        // POST the JSON string to the server via the HTTP request, which inserts the data into the MySQL database
                        using (var writer = new StreamWriter(request.GetRequestStream()))
                        {
                            writer.Write(userInfo.ToString());
                            writer.Flush();
                            writer.Close();
                        }

                        try
                        {

                            response = (HttpWebResponse)request.GetResponse();

                            // If the HTTP status code is "Crated", return the success string
                            if (response.StatusCode == HttpStatusCode.Created)
                                responseStr = responseStr = "REGISTER_SUCCESSFUL";

                            // Dispose the response variable
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

        /*
        * Method: getRecordings()
        * Summary: Retrives the list of recordings stored on the server
        * Returns: A list of objects of type RecordingManager, used to populate the main list within the application
        */
        public static List<RecordingManager> getRecordings()
        {
            // Prepare the GET HTTP request to the "recordings" endpoint
            prepareRequest(recordingUrl, "", "GET");

            // Initialise the list to be returned by the function
            List<RecordingManager> dirContents = new List<RecordingManager>();

            try
            {
                // Send the request and store the response in the response variable
                response = (HttpWebResponse)request.GetResponse();
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    responseStr = reader.ReadToEnd();
                }

                // Declare the recording variable
                RecordingManager recording;

                // Trim the unnecessary characters from the response string 
                string tmp = string.Join("", responseStr.Split('"', '[', ']', ' ', '\n'));
                // Split the remaining contents at each "," and store the results as an array
                string[] tmp2 = tmp.Split(',');

                // Loop through the array elements and instantiate a recording variable for each element, add 
                // them to the dirContents variable, assuming the element is not "." or "..", which are the 
                // current and parent directory identifiers on the server 
                foreach (string t in tmp2)
                {
                    if (t != "." && t != "..")
                    {
                        string tmp3 = getRecInfo(t);
                        recording = new RecordingManager(tmp3);
                        dirContents.Add(recording);
                    }
                }

                response.Dispose();

            }
            // If there is an error, set the value of the dirContents variable to null
            catch (WebException we)
            {
                Console.WriteLine(we.Message);
                dirContents = null;
            }
            
            return dirContents;
        }

/*
* Method: 
* Summary: 
* Parameter: 
* Returns: 
*/
        /*
        * Method: getRecInfo()
        * Summary: Returns a JSON string containing information on the recording passed as a parameter
        * Parameter: recId - The ID of the recording to retreive information for
        * Returns: The whole JSON recording file stored on the server
        */
        public static string getRecInfo(string recId)
        {
            // If the ID contains the JSON extension, remove the extension
            if(recId.Substring(recId.Length - 5) == ".json")
            {
                recId = recId.Remove(recId.Length - 5);
            }
            
            // Prepare the HTTP GET request to the recordings/recId endpoint
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

        #endregion
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
