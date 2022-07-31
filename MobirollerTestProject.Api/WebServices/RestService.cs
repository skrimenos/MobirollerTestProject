using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MobirollerTestProject.Api.WebServices
{
    public class RestService
    {
        public static async Task<string> GetValuesAsync(string url)
        {
            var client = new HttpClient()
            {
                BaseAddress = new Uri(url),
                Timeout = TimeSpan.FromMinutes(5)
            };

            var response = await client.GetAsync(client.BaseAddress);

            var responseString = await response.Content.ReadAsStringAsync();

            return responseString;
        }
    }
}
