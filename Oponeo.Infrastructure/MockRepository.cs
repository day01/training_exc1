using Oponeo.Domain;

namespace Oponeo.Infrastructure;

public class MockRepository : IRepository
{
    public List<Offer> Offers { get; set; } = new();
    
    public void IncreaseSizeById(long id)
    {
        return;
    }

    public List<Offer> GetOffers()
    {
        return Offers;
    }

    public void AddOffer(Offer offer)
    {
        var maxPrimaryKey = Offers.Max(x => (long?) x.Id) ?? 0;
        offer.Id = maxPrimaryKey + 1;
        offer.CreatedDate = DateTime.Now;
            
        Offers.Add(offer);
    }
}