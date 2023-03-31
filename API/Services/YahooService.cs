using API.Interfaces;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace API.Services
{
 public class YahooService : IYahooService
    {
        private readonly HttpClient _httpClient;

        public YahooService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<JObject> SearchFinanceArticlesAsync(string searchTerm)
        {
            var baseAddress = _httpClient.BaseAddress.AbsoluteUri;
            var url = $"?q={searchTerm}&region=US";
            
            using var response = await _httpClient.GetAsync(baseAddress + url);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<JObject>(responseBody);

            return result;
        }
    }
}