using ControlTowerDashboard.Interfaces;
using ControlTowerDashboard.Models.Settings;
using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;

namespace ControlTowerDashboard.Services;

public class HttpService : IHttpService
{
    private readonly APIServer _Settings;
    private readonly HttpClient _httpClient;
    private readonly ILogger<HttpService> _logger;

    public HttpService(
        IOptions<APIServer> server,
        ILogger<HttpService> logger)
    {
        _Settings = server.Value;
        _httpClient = new HttpClient { BaseAddress = new Uri(_Settings.UrlBase) };
        _logger = logger;
    }

    public async Task<T?> GetAsync<T>(string endpoint)
    {
        try
        {
            var response = await _httpClient.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();
            var responseData = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(responseData);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in HttpService.GetAsync");
        }
        return default;
    }

    public async Task<TResponse?> PostAsync<TRequest, TResponse>(string endpoint, TRequest data)
    {
        try
        {
            var json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(endpoint, content);
            response.EnsureSuccessStatusCode();
            var responseData = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<TResponse>(responseData);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in HttpService.PostAsync");
        }
        return default;

    }
}
