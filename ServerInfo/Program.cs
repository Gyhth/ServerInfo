using System;
using System.IO;
using System.Net;
using System.Net.Http;

namespace ServerInfo
{
    class Program
    {

        private static readonly HttpClient client = new HttpClient();
        static void Main(string[] args)
        {

            String path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\ServerInfo.txt";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            Writefile fileWriter = new Writefile();
            fileWriter.Output = new FileStream(path, FileMode.CreateNew);
            var request = (HttpWebRequest)WebRequest.Create("https://reddit.com");
            HttpWebResponse response;
            String responseString;
            try
            {
                request.Method = "HEAD";
                response = (HttpWebResponse)request.GetResponse();
                responseString = response.Headers.ToString();
                fileWriter.writeToFile("HEAD");
                fileWriter.writeToFile("--------------------------------------");
                fileWriter.writeToFile(responseString);
                fileWriter.close();
            }
            catch (Exception ex)
            {

            }
        }
        
    }
}
