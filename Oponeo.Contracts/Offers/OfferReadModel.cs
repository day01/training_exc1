using Oponeo.Domain;

namespace Oponeo.Contracts.Offers;

public class OfferReadModel : OfferModel
{
    public OfferStatus Status { get; set; }
}
