using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SequenceAutomation
{
    public class ConnectionManager
    {
        HttpWebRequest request;
        HttpWebResponse response;
        string responseStr;

        string urlString = "http://finalyearproject.cloudapp.net/easyAutomator/app/index.php/recordings";

        public ConnectionManager()
        {

        }

        public bool Upload(string jsonString)
        {
            request = (HttpWebRequest)WebRequest.Create(urlString);
            request.ContentType = "text/json";
            request.Method = "POST";

            using (var writer = new StreamWriter(request.GetRequestStream()))
            {
                //jsonString = JsonConvert.SerializeObject(jsonString);
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
