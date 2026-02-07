namespace aspnet_core_integration.Dtos.Common
{
    public record SignatureInfoDto
    {
        public string CertificateBase64 { get; init; } = default!;
        public string PassCertificate { get; init; } = default!;
    }
}
