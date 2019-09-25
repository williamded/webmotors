using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WebMotors.Service.RestClient
{
    public static class ApiRestClient
    {
        public static HttpClient ApiClient { get; set; } 
        public static void InitializeClient()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public static string GetJson(string url)
        {
            var response = ApiClient.GetStringAsync(new Uri(url));

            return response.Result;

        }
    }
}
