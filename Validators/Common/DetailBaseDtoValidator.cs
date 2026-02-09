using aspnet_core_integration.Dtos.Details;
using FluentValidation;

namespace aspnet_core_integration.Validators.Common
{
    public abstract class DetailBaseDtoValidator<T> : AbstractValidator<T>

        where T : DetailBaseDto
    {
        protected DetailBaseDtoValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Description is required.");

            RuleFor(x => x.Amount)
                .GreaterThan(0)
                .WithMessage("Amount must be greater than zero.");

            RuleForEach(x => x.AdditionalAttributes)
                .SetValidator(new DetailAdditionalAttributeDtoValidator())
                .When(x => x.AdditionalAttributes != null && x.AdditionalAttributes.Count > 0);
        }
    }

}
