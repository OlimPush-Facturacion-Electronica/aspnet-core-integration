using aspnet_core_integration.Dtos.Common;
using aspnet_core_integration.Dtos.Invoice;
using aspnet_core_integration.Infrastructure.ExternalServices.Dtos;
using aspnet_core_integration.Infrastructure.ExternalServices.OlimPush;

namespace aspnet_core_integration.Services.Implements
{
    public class InvoiceService(ILogger<InvoiceService> logger, 
        IOlimPushApiService olimPushApiService,
        IConfiguration configuration
        ) : IInvoiceService
    {

        private readonly IOlimPushApiService _olimPushApiService = olimPushApiService;
        private readonly ILogger<InvoiceService> _logger = logger;
        private readonly IConfiguration _configuration = configuration;
        public async Task<GenericResDto<CreateInvoiceResDto>> Create(InvoicePayloadDto request)
        {
            _logger.LogInformation(
                "Starting invoice creation for document {DocumentNumber}",
                request.TaxAuthorityInfo.SequentialDocument
            );

            // Aquí puedes agregar validaciones extra si quieres
            // reglas de negocio, etc.


            // aqui puedes leer la informacion de la firma desde otro origin/ DB, config, etc.
            request.SignatureInfo ??= GetSignatureFromSettings();
            var response = await _olimPushApiService.CreateInvoiceAsync(
             request
         );

            _logger.LogInformation(
                "Invoice created successfully. response: {response}",
                response
            );

            // aqui puedes guardar en db el resultado, validar el estado de recepcion, autorizaicion, etc.
            return response;
        }

        public SignatureInfoDto GetSignatureFromSettings() {


            var certificateBase64 = _configuration["ElectronicSignature:CertificateBase64"];
            var certificatePassword = _configuration["ElectronicSignature:CertificatePassword"];

            return new SignatureInfoDto() {
                CertificateBase64= certificateBase64,
                PassCertificate = certificatePassword
            
            };
        }

    }
}
