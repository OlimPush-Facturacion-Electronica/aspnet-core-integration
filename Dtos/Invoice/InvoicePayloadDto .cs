using aspnet_core_integration.Dtos.Common;
using aspnet_core_integration.Dtos.Details;

namespace aspnet_core_integration.Dtos.Invoice
{
    public class InvoicePayloadDto : PayloadDocumentBaseDto
    {
        public InvoiceInfoDto InvoiceInfo { get; init; } = default!;
        public List<InvoiceDetailDto> Details { get; init; } = [];
        public List<PaymentMethodDto> PaymentMethods { get; init; } = [];
    }
}
