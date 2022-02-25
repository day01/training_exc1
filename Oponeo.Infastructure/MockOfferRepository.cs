using Oponeo.Domain;

namespace Oponeo.Infastructure;

public class MockOfferRepository : IOfferRepository
{
    public Offer GetById(int id)
    {
        return new() {Id = id};
    }

    public void CreateOffer(Offer offer)
    {
        
    }

    public void DeleteOffer(int id)
    {
    }

    public List<Offer> GetOffers()
    {
        return new List<Offer>
        {
            new Offer {Id = 1},
            new Offer {Id = 2},
            new Offer {Id = 3},
        };
    }

    public void SaveChanges()
    {
        
    }
}