using aspnet_core_integration.Dtos.Invoice;
using FluentValidation;
using System.Globalization;

namespace aspnet_core_integration.Validators.Invoice
{
    public class InvoiceInfoDtoValidator : AbstractValidator<InvoiceInfoDto>
    {
        public InvoiceInfoDtoValidator()
        {

            RuleFor(x => x.EstablishmentAddress)
                .NotNull()
                .Must(x => !string.IsNullOrWhiteSpace(x))
                .WithMessage("Establishment address is required.");

            RuleFor(x => x.HasRequiredAccounting)
                .NotNull()
                .Must(x => x == "YES" || x == "NO")
                .WithMessage("HasRequiredAccounting must be 'SI' or 'NO'.");

            RuleFor(x => x.BuyerIdType)
                .NotNull()
                .Must(x => !string.IsNullOrWhiteSpace(x))
                .WithMessage("Buyer identification type is required.");

            RuleFor(x => x.BuyerIdNumber)
                .NotNull()
                .Must(x => !string.IsNullOrWhiteSpace(x))
                .WithMessage("Buyer identification number is required.");

            RuleFor(x => x.BuyerSocialReason)
                .NotNull()
                .Must(x => !string.IsNullOrWhiteSpace(x))
                .WithMessage("Buyer social reason is required.");

            RuleFor(x => x.BuyerAddress)
                .NotNull()
                .Must(x => !string.IsNullOrWhiteSpace(x))
                .WithMessage("Buyer address is required.");

            RuleFor(x => x.BuyerEmail)
             .EmailAddress()
             .WithMessage("Buyer email must be a valid email address.")
             .When(x => !string.IsNullOrWhiteSpace(x.BuyerEmail));

            RuleFor(x => x.EmissionDate)
            .Must(date =>
                DateTime.TryParseExact(
                    date,
                    "dd/MM/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out _))
            .WithMessage("Emission date must be in format dd/MM/yyyy.")
            .When(x => !string.IsNullOrWhiteSpace(x.EmissionDate));

            RuleFor(x => x.RemissionGuideNumber)
            .Matches(@"^\d{3}-\d{3}-\d{9}$")
            .WithMessage("Remission guide number must have format 001-001-000000002.")
            .When(x => !string.IsNullOrWhiteSpace(x.RemissionGuideNumber));

        }
    }
}
