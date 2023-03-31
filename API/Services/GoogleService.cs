using API.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace API.Services
{
 public class GoogleService : IGoogleService
    {
        private readonly HttpClient _httpClient;

        public GoogleService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<JObject> SearchNews(string query)
        {
            string requestUrl = $"&q={query}&num=10&start=11";
            requestUrl = _httpClient.BaseAddress.AbsoluteUri + requestUrl;
            HttpResponseMessage response = await _httpClient.GetAsync(requestUrl);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<JObject>(content);
                return result;
            }
            else
            {
                throw new Exception($"Error: {response.StatusCode}");
            }
        }
    }
}