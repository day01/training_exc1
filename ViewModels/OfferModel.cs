using System;

namespace OponeoViewsAndAuth.Start.ViewModels;

public class OfferModel
{
    public int Id { get; set; }

    public int Size { get; set; }

    public string? ProductName { get; set; }

    public DateTime CreatedDate { get; set; }
}