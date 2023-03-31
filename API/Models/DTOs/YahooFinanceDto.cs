using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Apis.YouTube.v3.Data;
using Newtonsoft.Json;

namespace API.Models.DTOs
{
    public class YahooFinanceDto
    {
        public IList<YahooArticle> News { get; set; }
        public int TotalResults { get; set; }
        public int ResultsPerPage { get; set; }
    }

    public class YahooArticle
    {
        [JsonProperty("uuid")]
        public string Uuid { get; set; }

         [JsonProperty("title")]
        public string Title { get; set; }

         [JsonProperty("link")]
        public string Link { get; set; }
        
         [JsonProperty("publisher")]
        public string Publisher {get; set; }
    }
}