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
                client.SendTimeout = 2000;
                client.Connect(domain, 80);
                if (!client.Connected)
                {
                    return false;
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine(e.Message);
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

                JToken responseToken = JObject.Parse(responseStr);

                // Store the necessary user credentials in the application settings
                Properties.Settings.Default.currentUser = Convert.ToString(responseToken["userId"]);
                Properties.Settings.Default.currentUserFirstname = Convert.ToString(responseToken["firstname"]);
                Properties.Settings.Default.currentUserSurname = Convert.ToString(responseToken["surname"]);

                // If the HTTP status code is "Accepted", return true. Otherwise return false
                if (response.StatusCode == HttpStatusCode.Accepted)
                    result = true;
                else
                    result = false;

                // Dispose the response variable
                response.Close();
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
                            response.Close();
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
                string responseStripped = string.Join("", responseStr.Split('"', '[', ']', ' ', '\n'));
                // Split the remaining contents at each "," and store the results as an array
                string[] responseSplit = responseStripped.Split(',');

                // Loop through the array elements and instantiate a recording variable for each element, add 
                // them to the dirContents variable, assuming the element is not "." or "..", which are the 
                // current and parent directory identifiers on the server 
                foreach (string recname in responseSplit)
                {
                    if (recname != "." && recname != "..")
                    {
                        string tempRec = getRecInfo(recname);
                        recording = new RecordingManager(tempRec);
                        dirContents.Add(recording);
                    }
                }

                response.Close();

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
                // Send the request and retrieve the response string
                // In this case, the response string is a full recording in the JSON format
                response = (HttpWebResponse)request.GetResponse();
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    responseStr = reader.ReadToEnd();
                }

                response.Close();
            }

            catch (WebException we)
            {
                Console.WriteLine(we.Message);
                throw;
            }

            return responseStr;
        }

        /*
         * Method: uploadRecording()
         * Summary: Uploads a JSON recording string to the server
         * Parameter: recJson - A recording string in the JSON format
         * Returns: True or false depending on the success of the upload attempt
         */
        public static bool uploadRecording(string recJson)
        {
            // Prepare the HTTP Post request to the users endpoint
            prepareRequest(recordingUrl, "text/json", "POST");
            bool result = false;
            try
            {
                // Validate the JSON string to ensure it is in the correct format
                if(RecordingManager.validateJson(recJson))
                {
                    // Write the JSON string with the HTTP request
                    using (var writer = new StreamWriter(request.GetRequestStream()))
                    {
                        Console.WriteLine(recJson);
                        writer.Write(recJson);
                        writer.Flush();
                        writer.Close();
                    }

                    try
                    {
                        // Retrieve the response from the server
                        response = (HttpWebResponse)request.GetResponse();

                        // If the response code is "Created" assign the value "true" to the result variable
                        // Otherwise, set it to false
                        if (response.StatusCode == HttpStatusCode.Created)
                            result = true;
                        response.Close();

                    }
                   
                    catch (WebException we)
                    {
                        Console.WriteLine(we.Message);
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

        /*
         * Method: deleteRecording()
         * Summary: Attempts to delete a recording from the server
         * Parameter: recJson - A recording string in the JSON format
         * Returns: True or false depending on the success of the delete operation
         */
        public static bool deleteRecording(string recJson)
        {
            // Prepare the DELETE HTTP request to the recordings endpoint
            prepareRequest(recordingUrl, "text/json", "DELETE");
            
            //RecordingManager recording = new RecordingManager(recJson);
            bool result = false;

            try
            {
                // Extract the ID from the recJson string
                string recId = RecordingManager.getRecId(recJson);

                // Create the JSON object to be written to the server
                JObject recInfo = new JObject(
                    new JProperty("recId", recId),
                    new JProperty("UserId", Properties.Settings.Default.currentUser));

                // Write the JSON string to the server
                using (var writer = new StreamWriter(request.GetRequestStream()))
                {
                    writer.Write(recInfo.ToString());
                    writer.Flush();
                    writer.Close();
                }

                try
                {
                    // Retrieve the response 
                    response = (HttpWebResponse)request.GetResponse();

                    // If the response code is "OK", return true
                    if (response.StatusCode == HttpStatusCode.OK)
                        result = true;
                    response.Close();
                }
                catch (WebException we)
                {
                    Console.WriteLine(we.Message);
                    return false;
                }
            }

            catch (WebException we)
            {
                Console.WriteLine(we.Message);
                result = false;
            }

            return result;
        }

        #endregion

        #region Private methods
        /*
         * Method: encryptPassword()
         * Summary: Encrypts the plaintext password entered by the user
         * Parameter: plaintextPassword - The plain text password entered by the user into the text box in the interface
         * Returns: The password string in its encrypted form
         */
        private static string encryptPassword(string plaintextPassword)
        {
            // Get the bytes of the password
            var bytes = new UTF8Encoding().GetBytes(plaintextPassword);
            byte[] hashBytes;
            
            // Using the SHA512 algorithm, compute the hash of each byte and store each result in the hashBytes array
            using (var algorithm = new SHA512Managed())
            {
                hashBytes = algorithm.ComputeHash(bytes);
            }
            
            // Convert the hashBytes array to a string
            string encryptedPassword = Convert.ToBase64String(hashBytes);
            
            // Remove any forward and backward slashes from the encrypted string
            // This had to be done as there were issues regarding the use of the escape character '\' when
            // sending the encrypted password to the server as a string
            encryptedPassword = string.Join("", encryptedPassword.Split('\\', '/'));

            return encryptedPassword;
        }

        /*
         * Method: prepareRequest
         * Summary: Prepares an HTTP request to one of the specified endpoints as one of the HTTP methods
         * Parameter: url - The URL that the request should be sent to, either users/ recordings/
         * Parameter: content - The JSON content, if any
         * Parameter: method - The HTTP method, either GET, POST, PUT or DELETE
         * Returns: True if successful
         */
        private static bool prepareRequest(string url, string content, string method)
        {
            // Initiailise the request to the URL and set the method
            request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = method;
            
            // If content has been specified, set the request content type as the one passed in
            if (content != "")
            {
                request.ContentType = content;
            }

            // Accept all certificates. This had to be done to bypass the security restrictions regarding the self-signed certificate on the server
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
            ServicePointManager.ServerCertificateValidationCallback = delegate (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
            return true;
        }

        /*
        * Method: validateUsername()
        * Summary: Validates a username by checking whether or not it exists on the server
        * Parameter: username - The username to be validated
        * Returns: True or false depending on whether or not the username exists
        */
        private static bool validateUsername(string username)
        {
            // Prepare the GET HTTP request to the users endpoint, appending the username to be validated
            prepareRequest(usersUrl + "/" + username, "text/json", "GET");

            bool result = false;
            try
            {
                // Send the request and retrieve the response
                response = (HttpWebResponse)request.GetResponse();

                // If the response status code is "OK", return true
                if (response.StatusCode == HttpStatusCode.OK)
                    result = true;
                response.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return result;
        }

        /*
         * Method: validateEmail()
         * Summary: Validates an email address by checking if it is in a valid format and not already registered to the application
         * Parameter: email - The email address to be validated
         * Returns: An integer acting as a status code for the operation
         */
        private static int validateEmail(string email)
        {
            // Prepare the GET HTTP request to the users endpoint, appending /email/(email)
            prepareRequest(usersUrl + "/email/" + email, "text/json", "GET");
            int result = 2;
            try
            {
                // Attempt to 
                var addr = new System.Net.Mail.MailAddress(email);
                response = (HttpWebResponse)request.GetResponse();

                // If the status code returned is "OK" the email exists
                if (response.StatusCode == HttpStatusCode.OK)
                    result = 0;

                response.Close();
            }

            // If the address is in an incorrect format
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                result = 2;
            }

            // If the address does not exist on the server
            catch (WebException e)
            {
                Console.WriteLine(e.Message);
                result = 1;
            }

            return result;
        }

        #endregion
    }
}
