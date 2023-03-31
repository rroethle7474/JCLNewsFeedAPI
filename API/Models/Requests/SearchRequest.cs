using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Requests
{
    public class SearchRequest
    {
        public string SearchTerm { get; set; }
        public int ResultsPerPage { get; set; } = 5;
        public int PageNumber { get; set; } = 1;
        public DateTime StartDate { get; set; } = DateTime.MinValue;
        public DateTime EndDate { get; set; } = DateTime.MaxValue;
    }
}