using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Apis.YouTube.v3.Data;
using Newtonsoft.Json.Linq;

namespace API.Interfaces
{
    public interface IGoogleService
    {
        Task<JObject> SearchNews(string query);
    }
}