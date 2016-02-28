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

        string urlString = "http://finalyearproject.cloudapp.net/app/index.php/artists";

        public ConnectionManager()
        {

        }

        public bool Upload(string jsonString)
        {

            using (FileStream fs = File.Open(@"C:\Users\Brian\NotepadHello.json", FileMode.CreateNew))
            using (StreamWriter sw = new StreamWriter(fs))
            using (JsonWriter jw = new JsonTextWriter(sw))
            {
                jw.Formatting = Formatting.Indented;

                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(jw, jsonString);
            }
                /*
                request = (HttpWebRequest)WebRequest.Create(urlString);
                request.Method = "POST";
                request.ContentType = "application/json; charsetLutf-8";

                using (var writer = new StreamWriter(request.GetRequestStream()))
                {
                    writer.Write(jsonString);
                    writer.Flush();
                    writer.Close();
                }

                response = (HttpWebResponse)request.GetResponse();
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    responseStr = reader.ReadToEnd();
                }

                Console.WriteLine(responseStr);*/
                return true;
        }
    }
}
