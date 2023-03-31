

using Newtonsoft.Json.Linq;

namespace API.Interfaces
{
    public interface IYahooService
    {
        Task<JObject> SearchFinanceArticlesAsync(string searchTerm);
    }
}