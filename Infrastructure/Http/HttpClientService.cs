using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using Microsoft.Extensions.Options;
using aspnet_core_integration.Infrastructure.Configuration;

namespace aspnet_core_integration.Infrastructure.Http
{
    public class HttpClientService: IHttpClientService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<HttpClientService> _logger;

        public HttpClientService(ILogger<HttpClientService> logger,
              HttpClient httpClient) {

            _logger = logger;
            _httpClient = httpClient;

        }
        public async Task<TResponse> PostAsync<TRequest, TResponse>(
           string url,
           TRequest body)
        {
            _logger.LogInformation("POST request to {Url}", url);

            var response = await _httpClient.PostAsJsonAsync(url, body);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<TResponse>();

        }

        public async Task<TResponse> GetAsync<TResponse>(
            string url,
            string accessToken)
        {
            _logger.LogInformation("GET request to {Url}", url);

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("olimpush-token", accessToken);

            var response = await _httpClient.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError(
                    "Error response from {Url}: {StatusCode} - {Body}",
                    url,
                    response.StatusCode,
                    content
                );

                throw new ApplicationException(
                    $"HTTP error {response.StatusCode}: {content}"
                );
            }

            JsonSerializerOptions options = new()
            {
                PropertyNameCaseInsensitive = true
            };
            return JsonSerializer.Deserialize<TResponse>(
                content,
                options)!;
        }

    }
}
