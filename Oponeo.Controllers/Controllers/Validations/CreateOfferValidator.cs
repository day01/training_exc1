using FluentValidation;
using Oponeo.Contracts.Offers;

namespace Oponeo.Controllers.Controllers.Validations;

public class CreateOfferValidator : AbstractValidator<CreateOffer>
{
    public CreateOfferValidator()
    {
        CascadeMode = CascadeMode.Stop;
        RuleFor(x => x.Size)
            .GreaterThan(0)
            .WithMessage("ERROR_SIZE_GREATER_THEN_0")
            .LessThan(100)
            .WithMessage("ERROR_SIZE_LESS_THEN_100");

        RuleFor(x => x.Parameters)
            .NotEmpty()
            .NotNull()
            .Must(ValidateParameters)
            .WithMessage("ERR_AVAILABLE_CODES");
    }

    private bool ValidateParameters(List<ContractParameter> parameters)
    {
        if (parameters == null)
        {
            return false;
        }
        
        if (parameters.Any())
        {
            return false;
        }

        var availableNames = new[] {"ABC", "string"};

        return parameters.All(x => availableNames.Contains(x.Name));
    }
}