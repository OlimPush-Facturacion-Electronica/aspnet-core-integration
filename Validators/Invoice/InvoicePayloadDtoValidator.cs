using aspnet_core_integration.Dtos.Invoice;
using aspnet_core_integration.Validators.Common;
using FluentValidation;

namespace aspnet_core_integration.Validators.Invoice
{
    public class InvoicePayloadDtoValidator : AbstractValidator<InvoicePayloadDto>
    {
        public InvoicePayloadDtoValidator()
        {
            RuleFor(x => x.TaxAuthorityInfo)
              .NotNull()
              .WithMessage("TaxAuthorityInfo must not be null.")
               .SetValidator(new TaxAuthorityInfoDtoValidator());

            RuleFor(x => x.InvoiceInfo)
            .NotNull()
            .WithMessage("InvoiceInfo must not be null.")
             .SetValidator(new InvoiceInfoDtoValidator()); ;

            RuleFor(x => x.PaymentMethods)
             .NotNull()
             .WithMessage("Payment methods must not be null.")
             .NotEmpty()
             .WithMessage("At least one payment method is required.");

            RuleFor(x => x.Details)
           .NotNull()
           .WithMessage("Details must not be null.")
           .NotEmpty()
           .WithMessage("At least one detail is required.");


            RuleForEach(x => x.Details)
                .SetValidator(new InvoiceDetailDtoValidator());


            RuleForEach(x => x.PaymentMethods)
                .SetValidator(new PaymentMethodDtoValidator());

            RuleForEach(x => x.AdditionalAttributes)
            .SetValidator(new DetailAdditionalAttributeDtoValidator())
            .When(x => x.AdditionalAttributes != null && x.AdditionalAttributes.Count != 0);

            RuleFor(x => x.SignatureInfo)
            .SetValidator(new SignatureInfoDtoValidator())
            .When(x => x.SignatureInfo != null);

        }
    }
}
