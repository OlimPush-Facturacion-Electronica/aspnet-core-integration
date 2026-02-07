namespace aspnet_core_integration.Dtos.Invoice
{
    public record PaymentMethodDto
    {
        public string Type { get; init; } = default!;
        public decimal Total { get; init; }
        public string PaymentTerm { get; init; } = default!;
        public string TimeUnit { get; init; } = default!;
    }
}
