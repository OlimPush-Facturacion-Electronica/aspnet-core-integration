using aspnet_core_integration.Dtos.Common;
using aspnet_core_integration.Dtos.Details;

namespace aspnet_core_integration.Dtos.Invoice
{
    public record InvoicePayloadDto : PayloadBaseDto
    {
        public InvoiceInfoDto InvoiceInfo { get; init; } = default!;
        public List<DetailBaseDto> Details { get; init; } = [];
        public List<PaymentMethodDto> PaymentMethods { get; init; } = [];
    }
}
