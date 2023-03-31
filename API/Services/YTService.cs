using System.Threading.Tasks;
using API.Interfaces;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;

namespace API.Services
{
 public class YTService : IYTService
    {
        private readonly string _apiKey;
        private readonly YouTubeService _ytService;

        public YTService(string apiKey, string applicationName)
        {
            _apiKey = apiKey;
            _ytService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = _apiKey,
                ApplicationName = applicationName
            });
            
        }

        public async Task<SearchListResponse> SearchVideosAsync(string searchTerm, int maxResults = 5)
        {
            // use pageToken (or next page token returned from previous response to utilitze pagination) - example request below
        //     https://developers.google.com/apis-explorer/#p/youtube/v3/youtube.search.list?
                // part=snippet
                // &maxResults=10
                // &order=viewCount
                // &pageToken=CAoQAA
                // &q=skateboarding+dog
                // &type=video
                
            var searchRequest = _ytService.Search.List("snippet");
            searchRequest.Q = searchTerm;
            searchRequest.Type = "video";
            searchRequest.MaxResults = maxResults;
            searchRequest.PrettyPrint = true;

            var searchResponse = await searchRequest.ExecuteAsync();
            return searchResponse;
        }
    }
}