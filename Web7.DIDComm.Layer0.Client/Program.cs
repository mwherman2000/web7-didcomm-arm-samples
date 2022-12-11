using System;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using Web7.DIDComm.Layer0.Agent;

// requestMessage.Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");

namespace Web7.DIDComm.Layer0.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            const int agent = 0;

            const string scheme = "http";
            const string host = "localhost";
            const int port = 8080 + agent;
            const string protocol = "SendMessage";
            const string path = protocol + "/";

            string url = new UriBuilder(scheme, host, port, path).ToString();
            Console.WriteLine("Url: '" + url + "'");

            string messageText = DateTime.UtcNow.ToString("u");

            SendMessageRequest messageRequest = new SendMessageRequest(messageText);
            string jsonMessageRequest = messageRequest.ToString();
            Console.WriteLine("jsonMessageRequest: '" + jsonMessageRequest + "'");

            string jsonSendMessageResponse = "";

            using (var httpClient = new HttpClient())
            {
                using (var requestMessage = new HttpRequestMessage(new HttpMethod("POST"), url))
                {
                    requestMessage.Headers.TryAddWithoutValidation("Accept", "application/json");
                    requestMessage.Content = new StringContent(jsonMessageRequest);
                    var task = httpClient.SendAsync(requestMessage);
                    task.Wait();
                    var result = task.Result;

                    Console.WriteLine("StatusCode: " + result.StatusCode.ToString()
                                                     + " (" + ((int)result.StatusCode).ToString() + ")");

                    jsonSendMessageResponse = result.Content.ReadAsStringAsync().Result;
                }
            }

            Console.WriteLine("jsonSendMessageResponse: '" + jsonSendMessageResponse + "'");

            Console.WriteLine("Press Enter to exit Client...");
            Console.ReadLine();
        }
    }
}
