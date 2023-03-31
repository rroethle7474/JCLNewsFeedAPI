using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Apis.YouTube.v3.Data;
using Newtonsoft.Json;

namespace API.Models.DTOs
{
    public class GoogleDto
    {
        public IList<GoogleArticle> News { get; set; }
        public int TotalResults { get; set; }
        public int ResultsPerPage { get; set; }
    }

    public class GoogleArticle
    {
        public string Id { get; set; } = "1";
        public string Title { get; set; }
        public string Link { get; set; }
        public string Snippet {get; set; }
    }
}