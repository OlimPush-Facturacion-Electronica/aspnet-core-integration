namespace aspnet_core_integration.Dtos.Details
{
    public record DetailAdditionalAttributeDto
    {
        public string Attribute { get; init; } = default!;
        public string Value { get; init; } = default!;
    }
}
