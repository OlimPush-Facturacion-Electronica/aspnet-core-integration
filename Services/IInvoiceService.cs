using aspnet_core_integration.Dtos.Invoice;
using aspnet_core_integration.Infrastructure.ExternalServices.Dtos;

namespace aspnet_core_integration.Services
{
    public interface IInvoiceService
    {

        Task<GenericResDto<CreateInvoiceResDto>> Create(InvoicePayloadDto request);
    }
}
