using API.Interfaces;
using API.MIddleware;
using API.Models;
using API.Services;

var builder = WebApplication.CreateBuilder(args);
var apiSettings = new APIs();

builder.Configuration.GetSection("APIs").Bind(apiSettings);

// automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add client services for Http Requests to Retrieve Articles
builder.Services.AddSingleton<IYTService>(new YTService(apiSettings?.YouTube?.ApiKey, apiSettings?.YouTube?.ApplicationName));
builder.Services.AddHttpClient<IYahooService, YahooService>(client =>
{
    client.DefaultRequestHeaders.Add("x-rapidapi-key", apiSettings?.Yahoo?.ApiKey);
    client.DefaultRequestHeaders.Add("x-rapidapi-host", apiSettings?.Yahoo?.ApplicationHost);
    client.BaseAddress = new Uri(apiSettings?.Yahoo?.Url);
});
builder.Services.AddHttpClient<IGoogleService, GoogleService>(client =>
{
    client.BaseAddress = new Uri("https://www.googleapis.com/customsearch/v1?key=" + apiSettings?.Google?.ApiKey + "&cx=" + apiSettings?.Google?.SearchEngineId);
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.Run();
