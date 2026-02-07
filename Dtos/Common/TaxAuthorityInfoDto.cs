namespace aspnet_core_integration.Dtos.Common
{
    public record TaxAuthorityInfoDto
    {
        public string SocialReason { get; init; } = default!;
        public string CommercialName { get; init; } = default!;
        public string? KeyAccess { get; init; }
        public string Ruc { get; init; } = default!;
        public string EstablishmentCode { get; init; } = default!;
        public string PointCode { get; init; } = default!;
        public string SequentialDocument { get; init; } = default!;
        public string MainAddress { get; init; } = default!;
    }
}
