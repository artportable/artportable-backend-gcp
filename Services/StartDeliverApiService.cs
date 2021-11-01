using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Artportable.API.DTOs;
using Artportable.API.Enums;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Artportable.API.Services
{
  public class StartDeliverApiService : IStartDeliverApiService
  {
    private HttpClient _httpClient;
    private IConfiguration _configuration;
    private IHostEnvironment _env;

    public StartDeliverApiService(HttpClient httpClient, IConfiguration configuration, IHostEnvironment environment)
    {
      _configuration = configuration;
      _env = environment;
      _httpClient = httpClient;
    }

    public HttpClient GetClient => _httpClient;

    public async Task TrackUsageEvent(StartDeliverUsageEventDTO dto)
    {
      var serialized = JsonSerializer.Serialize(dto);
      var urlEncodedDto = WebUtility.UrlEncode(serialized);
      var queryParams = $"?m={urlEncodedDto}";
      var response = await _httpClient.GetAsync(queryParams);
      if (!response.IsSuccessStatusCode)
      {
        Console.WriteLine("Failed to track event");
      }
    }
    public async Task TrackAppOpenedEvent(string userEmail)
    {
      // There is no test environment at startdeliver as of now. Dont track
      if (!_env.IsProduction())
      {
        return;
      }

      var dto = new StartDeliverUsageEventDTO()
      {
        Key = _configuration.GetValue<string>("StartDeliver:UsageEventKey"),
        UsageType = UsageEvent.OpenedApp.ToString(),
        Email = userEmail
      };

      var serialized = JsonSerializer.Serialize(dto);
      var urlEncodedDto = WebUtility.UrlEncode(serialized);
      var queryParams = $"?m={urlEncodedDto}";
      var response = await _httpClient.GetAsync(queryParams);
      if (!response.IsSuccessStatusCode)
      {
        Console.WriteLine("Failed to track event");
      }
    }
  }
}
