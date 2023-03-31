using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Apis.YouTube.v3.Data;

namespace API.Interfaces
{
    public interface IYTService
    {
        Task<SearchListResponse> SearchVideosAsync(string searchTerm, int maxResults = 5);
    }
}