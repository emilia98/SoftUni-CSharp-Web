using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpRequester_Save
{
    class HttpRequester
    {
        static async Task Main()
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("https://softuni.bg");
            string result = await response.Content.ReadAsStringAsync();
            await File.WriteAllTextAsync("index.html", result);
        }
    }
}
