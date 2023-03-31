using API.Interfaces;
using API.Models.Requests;
using AutoMapper;
using Google.Apis.YouTube.v3.Data;
using Microsoft.AspNetCore.Mvc;
using API.Models.DTOs;
using Newtonsoft.Json.Linq;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ArticleController : ControllerBase
{
    private readonly ILogger<ArticleController> _logger;
    private readonly IYTService _youTubeService;
    private readonly IYahooService _yahooService;
    private readonly IGoogleService _googleService;
    private readonly IMapper _mapper;

    public ArticleController(ILogger<ArticleController> logger, IYTService youTubeService, IYahooService yahooService, IGoogleService googleService, IMapper mapper)
    {
        _logger = logger;
        _youTubeService = youTubeService;
        _yahooService = yahooService;
        _googleService = googleService;
        _mapper = mapper;
    }

    [HttpPost("GetYouTubeVideos", Name = "GetYouTubeVideos")]
    public async Task<IActionResult> Post(SearchRequest searchRequest)
    {
        SearchListResponse articles = await _youTubeService.SearchVideosAsync(searchRequest.SearchTerm);
        return Ok(_mapper.Map<YouTubeDto>(articles));
    }

    [HttpPost("GetYahooFinanceArticles", Name = "GetYahooFinanceArticles")]
    public async Task<IActionResult> Post(YahooSearchRequest searchRequest)
    {
        JObject articles = await _yahooService.SearchFinanceArticlesAsync(searchRequest.SearchTerm);
        return Ok(_mapper.Map<YahooFinanceDto>(articles));
    }

        [HttpPost("GetGoogleArticles", Name = "GetGoogleArticles")]
    public async Task<IActionResult> Post(GoogleSearchRequest searchRequest)
    {
        JObject articles = await _googleService.SearchNews(searchRequest.SearchTerm);
        return Ok(_mapper.Map<GoogleDto>(articles));
    }
}
