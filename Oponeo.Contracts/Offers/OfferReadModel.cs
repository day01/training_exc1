namespace Oponeo.Contracts.Offers;

public class OfferReadModel
{
    public int Id { get; set; }

    public int Size { get; set; }

    public string? ProductName { get; set; }

    public DateTime CreatedDate { get; set; }
}