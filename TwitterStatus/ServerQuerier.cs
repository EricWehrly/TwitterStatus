using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace TwitterStatus
{
    class ServerQuerier
    {
        // TODO: drive this via configuration
        private const string uriPattern = "http://storage.googleapis.com/revsreinterview/hosts/{0}/status";

        public static async Task GetStatus(string hostname, Action<ServerStatus> responseMethod)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
                try
                {
                    string response = await client.GetStringAsync(String.Format(uriPattern, hostname));
                    ServerStatus responseObject = JsonConvert.DeserializeObject<ServerStatus>(response);
                    responseMethod(responseObject);
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Encountered an issue querying status of host " + hostname);
                    Console.WriteLine(exception.Message);
                    Console.WriteLine("Skipping entry for report.");
                }
            }
        }
    }
}
