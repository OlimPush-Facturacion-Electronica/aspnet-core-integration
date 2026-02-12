using aspnet_core_integration.Dtos.Invoice;
using aspnet_core_integration.Infrastructure.ExternalServices.Dtos;
using aspnet_core_integration.Infrastructure.Http;

namespace aspnet_core_integration.Infrastructure.ExternalServices.OlimPush
{
    public class OlimPushApiService(IHttpClientService httpClient,
        ILogger<OlimPushApiService> logger) : IOlimPushApiService
    {
        private readonly IHttpClientService _httpClient = httpClient;
        private readonly ILogger<OlimPushApiService> _logger = logger;

        public async Task<GenericResDto<CreateInvoiceResDto>> CreateInvoiceAsync(
           InvoicePayloadDto request)
        {
            _logger.LogInformation("Sending invoice to OlimPush API");

            return await _httpClient.PostAsync<
                InvoicePayloadDto,
                GenericResDto<CreateInvoiceResDto>
            >("individual/invoice/create", request);
        }

    }
}
