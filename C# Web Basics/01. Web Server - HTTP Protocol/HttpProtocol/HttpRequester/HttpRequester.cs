using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpRequester
{
    class HttpRequester
    {
        static async Task Main()
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("https://softuni.bg");
            string result = await response.Content.ReadAsStringAsync();
            Console.WriteLine(result);
        }
    }
}
