using aspnet_core_integration.Dtos.Details;

namespace aspnet_core_integration.Dtos.Invoice
{
    public record InvoiceDetailDto : DetailBaseDto
    {
        public string MainCode { get; init; } = default!;
        public string? AuxiliaryCode { get; init; }
        public decimal UnitValue { get; init; }
        public decimal Discount { get; init; }
        public string TariffCodeIva { get; init; } = default!;
    }
}
