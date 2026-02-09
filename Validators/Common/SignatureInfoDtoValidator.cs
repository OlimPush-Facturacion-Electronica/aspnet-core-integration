using aspnet_core_integration.Dtos.Common;
using FluentValidation;

namespace aspnet_core_integration.Validators.Common
{
    public class SignatureInfoDtoValidator
      : AbstractValidator<SignatureInfoDto>
    {
        public SignatureInfoDtoValidator()
        {
            RuleFor(x => x.CertificateBase64)
                .NotEmpty()
                .WithMessage("CertificateBase64 is required.");

            RuleFor(x => x.PassCertificate)
                .NotEmpty()
                .WithMessage("PassCertificate is required.");
        }
    }
}
