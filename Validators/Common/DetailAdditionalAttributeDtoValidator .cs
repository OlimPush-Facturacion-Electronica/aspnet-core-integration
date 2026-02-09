using aspnet_core_integration.Dtos.Details;
using FluentValidation;

namespace aspnet_core_integration.Validators.Common
{
    public class DetailAdditionalAttributeDtoValidator
         : AbstractValidator<DetailAdditionalAttributeDto>
    {
        public DetailAdditionalAttributeDtoValidator()
        {
            RuleFor(x => x.Attribute)
                .NotEmpty()
                .WithMessage("Attribute is required.");

            RuleFor(x => x.Value)
                .NotEmpty()
                .WithMessage("Value is required.");
        }
    }
}
