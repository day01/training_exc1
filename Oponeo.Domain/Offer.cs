namespace Oponeo.Domain;

public class Offer
{
    public long Id { get; set; }

    public int Size { get; set; }

    public string? ProductName { get; set; }

    public DateTime CreatedDate { get; set; }

    public OfferStatus Status { get; set; }

    public string OptionOfferStatus { get; set; }

    public int Option2 { get; set; }

    public DateTime? DeletedDate { get; set; }

    public List<StringParameter> Parameters { get; set; }
}