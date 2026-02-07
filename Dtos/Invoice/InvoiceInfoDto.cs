namespace aspnet_core_integration.Dtos.Invoice
{
    public record InvoiceInfoDto
    {
        public string EmissionDate { get; init; } = default!;
        public string EstablishmentAddress { get; init; } = default!;
        public string HasRequiredAccounting { get; init; } = default!;
        public string? RemissionGuideNumber { get; init; }
        public string BuyerIdType { get; init; } = default!;
        public string BuyerIdNumber { get; init; } = default!;
        public string BuyerSocialReason { get; init; } = default!;
        public string BuyerAddress { get; init; } = default!;
        public string BuyerEmail { get; init; } = default!;
    }
}
