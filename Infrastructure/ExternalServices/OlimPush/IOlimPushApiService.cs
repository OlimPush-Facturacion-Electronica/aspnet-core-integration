using aspnet_core_integration.Dtos.Invoice;
using aspnet_core_integration.Infrastructure.ExternalServices.Dtos;

namespace aspnet_core_integration.Infrastructure.ExternalServices.OlimPush
{
    public interface IOlimPushApiService
    {
        Task<GenericResDto<CreateInvoiceResDto>> CreateInvoiceAsync(
           InvoicePayloadDto request
       );
    }
}
