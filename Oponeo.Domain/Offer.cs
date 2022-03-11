using System.ComponentModel.DataAnnotations;

namespace Oponeo.Domain;

public class Offer : Entity
{
    public int Size { get; set; }

    public string? ProductName { get; set; }

    public OfferStatus Status { get; set; }

    public string OptionOfferStatus { get; set; }

    public int Option2 { get; set; }

    public List<Parameter> Parameters { get; set; }
}