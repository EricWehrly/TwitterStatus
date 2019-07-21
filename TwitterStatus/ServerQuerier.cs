using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace TwitterStatus
{
    class ServerQuerier
    {
        public static async Task GetStatus(string hostname, Action<ServerStatus> responseMethod)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string response = await client.GetStringAsync(
                    "http://storage.googleapis.com/revsreinterview/hosts/" + hostname + "/status");
                ServerStatus responseObject = JsonConvert.DeserializeObject<ServerStatus>(response);
                responseMethod(responseObject);
            }
        }
    }
}
