using FluentValidation;
using Oponeo.Contracts.Offers;
using Oponeo.Domain;

namespace Oponeo.Controllers.Controllers.Validations;

public class OfferInsteadModelValidator : AbstractValidator<OfferInsteadModel>
{
    public OfferInsteadModelValidator()
    {
        CascadeMode = CascadeMode.Stop;
        RuleFor(x => x.Size).NotEmpty();
        RuleFor(x => x.Option2).Must(ValidateOption2).WithMessage("WRONG_VALUE");
    }

    private bool ValidateOption2(int option2)
    {
        if (Enum.IsDefined(typeof(OfferStatus), option2))
        {
            return true;
        }

        return false;
    }
}