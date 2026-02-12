using aspnet_core_integration.Dtos.Details;

namespace aspnet_core_integration.Dtos.Common
{
    public abstract class PayloadDocumentBaseDto
    {
        public TaxAuthorityInfoDto TaxAuthorityInfo { get; init; } = default!;
        public List<DetailAdditionalAttributeDto>? AdditionalAttributes { get; init; }
        public SignatureInfoDto? SignatureInfo { get; set; }
    }
}
