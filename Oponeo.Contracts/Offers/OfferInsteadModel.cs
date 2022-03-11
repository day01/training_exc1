namespace Oponeo.Contracts.Offers;

public class OfferInsteadModel
{
    public int Size { get; set; }

    public string? ProductName { get; set; }

    public int Option2 { get; set; }

    public List<ContractParameter> Parameters { get; set; }
}