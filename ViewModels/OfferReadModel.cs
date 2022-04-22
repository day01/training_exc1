namespace OponeoViewsAndAuth.Start.ViewModels;

public class OfferReadModel : OfferModel
{
    public OfferStatus Status { get; set; }

    // int OptionOfferStatus
    public int Option2 { get; set; }

    public string PresentationOption2InMeters { get; set; }
}