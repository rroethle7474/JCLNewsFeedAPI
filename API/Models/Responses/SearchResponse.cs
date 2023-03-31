using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Apis.YouTube.v3.Data;

namespace API.Models.Responses
{
    public class SearchResponse
    {
        public int TotalResults { get; set; }
        public SearchListResponse SearchResults { get; set; }
    }
}