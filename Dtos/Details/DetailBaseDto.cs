namespace aspnet_core_integration.Dtos.Details
{
    public abstract record DetailBaseDto
    {
        public string Description { get; init; } = default!;
        public decimal Amount { get; init; }
        public List<DetailAdditionalAttributeDto>? AdditionalAttributes { get; init; }
    }
}
