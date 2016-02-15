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
        HttpWebRequest Request;
        HttpWebResponse Response;
        Stream RequestStream = null;
        Stream ResponseStream = null;
        XmlDocument ResponseXmlDoc = null;
        XmlNodeList FileNameNodes = null;
        string serverURL = "https://sequencerecorder.csproject.org/webdav/";
        string serverUsername = "alex";
        string serverPassword = "FinalYearProject";
        string query = "";
        byte[] bytes = null;

        public bool TestConnection()
        {
            return true;
        }

        public void UploadRec(string recPath, string recName)
        {

            // These lines allow the program to bypass warnings regarding untrusted SSL certificates
            ServicePointManager
            .ServerCertificateValidationCallback +=
            (sender, cert, chain, sslPolicyErrors) => true;

            WebClient webClient = new WebClient();
            string destinationFilePath = serverURL + recName;
            webClient.Credentials = new NetworkCredential(serverUsername, serverPassword, "domain");
            webClient.UploadFile(destinationFilePath, "PUT", recPath);
            webClient.Dispose();

        }

        public Boolean DownloadRec()
        {
            return true;
        }

        public void GetRecList()
        {
            //try {
                ServicePointManager
                .ServerCertificateValidationCallback +=
                (sender, cert, chain, sslPolicyErrors) => true;

                /*
                WebClient client = new WebClient();
                client.Credentials = new NetworkCredential(serverUsername, serverPassword, "domain");
                string content = client.DownloadString(serverURL);
                Console.WriteLine(content);
                client.Dispose();*/

                // authentication


                // response.
                //HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                query = "<? xml version = '1.0' encoding = 'utf-8'?> "
                         + "<propfind xmlns:a='DAV:>"
                         + "<a:prop><a:filename/></a:prop>"
                         + "</propfind>";
                try
                {
                    query = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>   <propfind xmlns=\"DAV:\">     <propname/>   </propfind> ";
                    bytes = Encoding.UTF8.GetBytes((string)query);

                    Request = (System.Net.HttpWebRequest)HttpWebRequest.Create(serverURL);
                    Request.Method = "PROPFIND";
                    Request.ContentLength = bytes.Length;
                    Request.ContentType = "application/xml; charset=\"utf-8\"";

                    RequestStream = Request.GetRequestStream();
                    RequestStream.Write(bytes, 0, bytes.Length);
                    RequestStream.Close();

                    Response = (HttpWebResponse)Request.GetResponse();
                    ResponseStream = Response.GetResponseStream();

                    XmlReader XmlReader = new XmlTextReader(ResponseStream);

                    string output = "";

                    while (XmlReader.Read())
                    {
                        output += XmlReader.Name + ": " + XmlReader.Value.ToString() + "\n";

                        if (XmlReader.Value.Contains("http"))
                        {
                            Console.Write(XmlReader.Name + ": " + "Value: " + XmlReader.Value.ToString());
                        }
                    }

                    XmlReader.Close();
                    ResponseStream.Close();
                    Response.Close();

                    MessageBox.Show("Completed");

                }
                catch (Exception ex)
                {
                    // Catch any exceptions. Any error codes from the SEARCH
                    // method request on the server will be caught here, also.
                    MessageBox.Show(ex.Message);
                }


                /*
                CredentialCache MyCredentialCache = new System.Net.CredentialCache();
                MyCredentialCache.Add(new System.Uri(serverURL),
                   "NTLM",
                   new System.Net.NetworkCredential(serverUsername, serverPassword, "Domain")
                   );

                // Create the HttpWebRequest object.
                Request = (System.Net.HttpWebRequest)HttpWebRequest.Create(serverURL);

                // Add the network credentials to the request.
                Request.Credentials = MyCredentialCache;

                // Specify the method.
                Request.Method = "PROPFIND";

                // Encode the body using UTF-8.
                bytes = Encoding.UTF8.GetBytes((string)query);

                // Set the content header length.  This must be
                // done before writing data to the request stream.
                Request.ContentLength = bytes.Length;

                // Get a reference to the request stream.
                RequestStream = Request.GetRequestStream();

                // Write the request body to the request stream.
                RequestStream.Write(bytes, 0, bytes.Length);

                // Close the Stream object to release the connection
                // for further use.
                RequestStream.Close();

                // Set the content type header.
                Request.ContentType = "text/xml";

                // Send the PROPFIND method request and get the
                // response from the server.
                Response = (HttpWebResponse)Request.GetResponse();

                // Get the XML response stream.
                ResponseStream = Response.GetResponseStream();

                // Create the XmlDocument object from the XML response stream.
                ResponseXmlDoc = new XmlDocument();
                ResponseXmlDoc.Load(ResponseStream);

                // Build a list of the DAV:href XML nodes, corresponding to the folders
                // in the mailbox.  The DAV: namespace is typically assgigned the a:
                // prefix in the XML response body.
                FileNameNodes = ResponseXmlDoc.GetElementsByTagName("a:filename");

                if (FileNameNodes.Count > 0)
                {
                    // Display the item's display name.
                    Console.WriteLine("DAV:filename property...");
                    Console.WriteLine(FileNameNodes[0].InnerText);
                }
                else
                {
                    Console.WriteLine("DAV:filename property not found...");
                }

                // Clean up.
                ResponseStream.Close();
                Response.Close();
            }
            catch (Exception ex)
            {
                // Catch any exceptions. Any error codes from the PROPFIND
                // method request on the server will be caught here, also.
                Console.WriteLine(ex.Message);
            }*/
        }

        public void GetRecInfo()
        {
           
        }

        public void SearchRec()
        {

        }
    }
}
