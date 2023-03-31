using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Apis.YouTube.v3.Data;

namespace API.Models.DTOs
{
    public class YouTubeDto
    {
        public IList<SearchResult> Videos { get; set; }
        public int TotalResults { get; set; }
        public int ResultsPerPage { get; set; }
    }
}