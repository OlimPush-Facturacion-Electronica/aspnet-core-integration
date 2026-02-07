namespace aspnet_core_integration.Dtos.Details
{
    public abstract record DetailBaseDto
    {
        public string Description { get; init; } = default!;
        public decimal Amount { get; init; }
        public string MainCode { get; init; } = default!;
        public string? AuxiliaryCode { get; init; }
        public decimal UnitValue { get; init; }
        public decimal Discount { get; init; }
        public string TariffCodeIva { get; init; } = default!;
        public List<DetailAdditionalAttributeDto>? AdditionalAttributes { get; init; }
    }
}
