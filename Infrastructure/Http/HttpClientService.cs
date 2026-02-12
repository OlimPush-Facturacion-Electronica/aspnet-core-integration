using System.Net.Http.Headers;
using System.Text.Json;
using aspnet_core_integration.Dtos.Common;
using System.Net.Sockets;
using System.Net;
using aspnet_core_integration.Infrastructure.Configuration;
using Microsoft.Extensions.Options;

namespace aspnet_core_integration.Infrastructure.Http
{
    public class HttpClientService(ILogger<HttpClientService> logger,
          HttpClient httpClient,
          IOptions<OlimPushSettings> options) : IHttpClientService
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly ILogger<HttpClientService> _logger = logger;
        private readonly IOptions<OlimPushSettings> _options = options;

        public async Task<TResponse> PostAsync<TRequest, TResponse>(
         string url,
         TRequest body
            )
        {

            var requestWrapper = new ApiRequestDto<TRequest>
            {
                Payload = body,
                IpRequest = GetLocalIpAddress(),
                UsrRequest = "miUsuarioOlimPushAdmin",
                Origin = _options.Value.Origin, // nombre de tu aplicacion
                TransactionIde = Guid.NewGuid().ToString()
            };

            _logger.LogInformation(
                "TransactionId: {TransactionId} - Sending request to {Url}",
                requestWrapper.TransactionIde,
                url);

            var response = await _httpClient.PostAsJsonAsync(url, requestWrapper);

            var responseContent = await response.Content.ReadAsStringAsync();

            _logger.LogInformation(
                "Response from {Url}. StatusCode: {StatusCode}. Body: {ResponseBody}",
                url,
                (int)response.StatusCode,
                responseContent);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError(
                    "Error calling {Url}. StatusCode: {StatusCode}. Response: {ResponseBody}",
                    url,
                    (int)response.StatusCode,
                    responseContent);

                response.EnsureSuccessStatusCode();
            }

            return JsonSerializer.Deserialize<TResponse>(
                responseContent,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                })!;
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

        private static string GetLocalIpAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());

            var ip = host.AddressList
                .FirstOrDefault(x => x.AddressFamily == AddressFamily.InterNetwork);

            return ip?.ToString() ?? "unknown";
        }


    }
}
