using aspnet_core_integration.Dtos.Invoice;
using aspnet_core_integration.Infrastructure.ExternalServices.OlimPush;

namespace aspnet_core_integration.Services.Implements
{
    public class InvoiceService(ILogger<InvoiceService> logger, IOlimPushApiService olimPushApiService) : IInvoiceService
    {

        private readonly IOlimPushApiService _olimPushApiService = olimPushApiService;
        private readonly ILogger<InvoiceService> _logger = logger;
        public async Task<string> Create(InvoicePayloadDto request)
        {
            _logger.LogInformation(
                "Starting invoice creation for document {DocumentNumber}",
                request.TaxAuthorityInfo.SequentialDocument
            );

            // Aquí puedes agregar validaciones extra si quieres
            // reglas de negocio, etc.

            var response = await _olimPushApiService.CreateInvoiceAsync(
             request
         );

            _logger.LogInformation(
                "Invoice created successfully. response: {response}",
                response
            );

           return response.ToString();
        }
    }
}
