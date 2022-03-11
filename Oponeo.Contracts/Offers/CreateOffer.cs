using System.ComponentModel.DataAnnotations;
using Oponeo.Domain;

namespace Oponeo.Contracts.Offers;

public class CreateOffer
{
    [Required]
    public int Size { get; set; }

    [Required]
    public string? ProductName { get; set; }

    public List<ContractParameter> Parameters { get; set; }
}