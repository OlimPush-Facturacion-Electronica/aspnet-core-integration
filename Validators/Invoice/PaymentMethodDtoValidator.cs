using aspnet_core_integration.Dtos.Invoice;
using FluentValidation;

namespace aspnet_core_integration.Validators.Invoice
{
    public class PaymentMethodDtoValidator : AbstractValidator<PaymentMethodDto>
    {
        public PaymentMethodDtoValidator()
        {
            RuleFor(x => x.Type)
         .NotEmpty()
         .WithMessage("Payment method type is required.");

            RuleFor(x => x.Total)
                .NotNull()
                .WithMessage("Payment method total is required.")
                .GreaterThan(0)
                .WithMessage("Payment method total must be greater than zero.");
        }
    }
}
