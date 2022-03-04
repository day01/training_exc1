using Oponeo.Domain;

namespace Oponeo.Contracts.Offers;

public class OfferReadModel : OfferModel
{
    public OfferStatus Status { get; set; }

    // int OptionOfferStatus
    public int Option2 { get; set; }

    public string PresentationOpetion2InMeters { get; set; }
}
