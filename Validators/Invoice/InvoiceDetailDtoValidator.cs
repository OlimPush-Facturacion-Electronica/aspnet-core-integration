using aspnet_core_integration.Dtos.Invoice;
using aspnet_core_integration.Validators.Common;
using FluentValidation;

namespace aspnet_core_integration.Validators.Invoice
{
    public class InvoiceDetailDtoValidator : DetailBaseDtoValidator<InvoiceDetailDto>
    {
        public InvoiceDetailDtoValidator()
        {
            RuleFor(x => x.MainCode)
                .NotEmpty()
                .WithMessage("MainCode is required.");

            RuleFor(x => x.UnitValue)
                .GreaterThan(0)
                .WithMessage("UnitValue must be greater than zero.");

            RuleFor(x => x.Discount)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Discount must be zero or greater.");

            RuleFor(x => x.TariffCodeIva)
                .NotEmpty()
                .WithMessage("TariffCodeIva is required.");
        }
    }

}
