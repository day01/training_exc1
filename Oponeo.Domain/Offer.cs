namespace Oponeo.Domain;

public class Offer
{
    public long Id { get; set; }

    public int Size { get; set; }

    public string? ProductName { get; set; }

    public DateTime CreatedDate { get; set; }

    public OfferStatus Status { get; set; }
}