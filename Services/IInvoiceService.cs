using aspnet_core_integration.Dtos.Invoice;

namespace aspnet_core_integration.Services
{
    public interface IInvoiceService
    {

        Task<string> Create(InvoicePayloadDto request);
    }
}
