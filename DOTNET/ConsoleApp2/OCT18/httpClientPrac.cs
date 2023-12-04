using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleApp2.OCT18
{
    internal class httpClientPrac
    {
        // Firstly, Create an instance of HttpClient:

        //To use HttpClient, you need to create an instance of the class.
        //It's recommended to create a single HttpClient instance and reuse it for multiple requests,
        //as creating a new instance for each request can lead to resource exhaustion.
        //static HttpClient httpClient = new HttpClient();

        //public static void Main()
        public static async Task Main()
        {

            // Get request
            #region GetRequest

            HttpClient httpClient = new HttpClient();
            string url = "https://jsonplaceholder.typicode.com/posts";
            HttpResponseMessage response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                //Console.WriteLine(content);
            }
            else
            {
                Console.WriteLine($"Request failed with status code {response.StatusCode}");
            }
            //httpClient.Dispose();
            #endregion



            #region PostRequest
            // 1. url for the request
            string url2 = "https://jsonplaceholder.typicode.com/posts";

            // 2. Preparing data to be send
            var data = new { userId = 1, id = 101010, title = "My title", body = "My body" };

            // 3. Converting c# object into json object
            // Installed NewtonSoft package from Nuget package manager for coversion
            string jsonData = JsonConvert.SerializeObject(data);

            // 4.Configure the Request (optional)
            //var content2 = new StringContent(jsonData, Encoding.UTF8, "application/json");

            // Mandatory
            var finalContent = new StringContent(jsonData);

            // 5. Sending the request
            HttpResponseMessage response2 = await httpClient.PostAsync(url2, finalContent);

            // OR
            //var request = new HttpRequestMessage
            //{
            //    RequestUri = new Uri(url2),
            //    Method = HttpMethod.Post,
            //    Content = finalContent // Data to send
            //};
            //HttpResponseMessage response4 = await httpClient1.SendAsync(request);

            if (response2.IsSuccessStatusCode)
            {
                string responseContent = await response2.Content.ReadAsStringAsync();
                Console.WriteLine(responseContent);
            }
            else
            {
                Console.WriteLine($"Request failed with status code {response2.StatusCode}");
            }

            #endregion

        }

    }
}
