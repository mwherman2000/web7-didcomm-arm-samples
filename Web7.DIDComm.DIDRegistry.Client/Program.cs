using System;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using Web7.DIDComm.DIDRegistry.Gateway;

// requestMessage.Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");

namespace Web7.DIDComm.DIDRegistry.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            const int agent = 99;

            const string scheme = "http";
            const string host = "localhost";
            const int port = 8080 + agent;
            const string protocol = "SendMessage";
            const string path = protocol + "/";

            string url = new UriBuilder(scheme, host, port, path).ToString();
            Console.WriteLine("Url: '" + url + "'");

            string messageText = DateTime.UtcNow.ToString("u");

            using (var httpClient = new HttpClient())
            {
                using (var requestMessage = new HttpRequestMessage(new HttpMethod("POST"), url))
                {
                    SendMessageRequest message = new SendMessageRequest(messageText);
                    string jsonRequest = message.ToString();
                    Console.WriteLine("jsonRequest: '" + jsonRequest + "'");

                    requestMessage.Headers.TryAddWithoutValidation("Accept", "application/json");
                    requestMessage.Content = new StringContent(jsonRequest);
                    var task = httpClient.SendAsync(requestMessage);
                    task.Wait();
                    var result = task.Result;

                    string jsonResponse = result.Content.ReadAsStringAsync().Result;
                    Console.WriteLine("jsonResponse: '" + jsonResponse + "'");
                    Console.WriteLine("StatusCode: " + result.StatusCode.ToString() 
                        + " (" + ((int)result.StatusCode).ToString() + ")");
                }

                Console.WriteLine("Press Enter to exit Client...");
                Console.ReadLine();
            }
        }
    }
}
