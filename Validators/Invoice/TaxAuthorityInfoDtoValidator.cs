using aspnet_core_integration.Dtos.Common;
using FluentValidation;

namespace aspnet_core_integration.Validators.Invoice
{
    public class TaxAuthorityInfoDtoValidator : AbstractValidator<TaxAuthorityInfoDto>
    {
        public TaxAuthorityInfoDtoValidator()
        {
            // Always required fields
            RuleFor(x => x.SocialReason)
                .NotEmpty()
                .WithMessage("Social reason is required.");

            RuleFor(x => x.CommercialName)
                .NotEmpty()
                .WithMessage("Commercial name is required.");

            RuleFor(x => x.MainAddress)
                .NotEmpty()
                .WithMessage("Main address is required.");

            // KeyAccess: optional, but if present must be 49 numeric digits
            RuleFor(x => x.KeyAccess)
                .Matches(@"^\d{49}$")
                .WithMessage("Key access must contain exactly 49 numeric digits.")
                .When(x => !string.IsNullOrWhiteSpace(x.KeyAccess));

            // When KeyAccess is NOT provided, these fields are required
            When(x => string.IsNullOrWhiteSpace(x.KeyAccess), () =>
            {
                RuleFor(x => x.Ruc)
                    .NotEmpty()
                    .WithMessage("RUC is required when key access is not provided.")
                    .Matches(@"^\d{13}$")
                    .WithMessage("RUC must contain exactly 13 numeric digits.");

                RuleFor(x => x.EstablishmentCode)
                    .NotEmpty()
                    .WithMessage("Establishment code is required when key access is not provided.")
                    .Matches(@"^\d{3}$")
                    .WithMessage("Establishment code must contain exactly 3 numeric digits.")
                    .Must(code => code != "000")
                    .WithMessage("Establishment code cannot be '000'.");

                RuleFor(x => x.PointCode)
                    .NotEmpty()
                    .WithMessage("Point code is required when key access is not provided.")
                    .Matches(@"^\d{3}$")
                    .WithMessage("Point code must contain exactly 3 numeric digits.")
                    .Must(code => code != "000")
                    .WithMessage("Point code cannot be '000'.");

                RuleFor(x => x.SequentialDocument)
                     .NotEmpty()
                     .WithMessage("Sequential document is required when key access is not provided.")
                     .Matches(@"^\d{9}$")
                     .WithMessage("Sequential document must contain exactly 9 numeric digits.")
                     .Must(value => value != "000000000")
                     .WithMessage("Sequential document cannot be all zeros.");

            });

        }
    }
}
