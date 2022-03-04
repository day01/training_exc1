using AutoMapper;
using Oponeo.Domain;

namespace Oponeo.Infrastructure;

public class MockRepository : IRepository
{
    private readonly IMapper _mapper;

    public MockRepository(IMapper mapper)
    {
        _mapper = mapper;
    }
    public List<Offer> Offers { get; set; } = new();
    
    public void IncreaseSizeById(long id)
    {
        return;
    }

    public List<Offer> GetOffers()
    {
        return Offers;
    }

    public List<Offer> GetActiveOffers()
    {
        return Offers
            .Where(x => x.Status == OfferStatus.Active)
            .ToList();
    }

    public void AddOffer(Offer offer)
    {
        var maxPrimaryKey = Offers.Max(x => (long?) x.Id) ?? 0;
        offer.Id = maxPrimaryKey + 1;
        offer.CreatedDate = DateTime.Now;
        offer.Status = OfferStatus.Active;
            
        Offers.Add(offer);
    }

    public Offer? GetOffer(long id)
    {
        return Offers.FirstOrDefault(x => x.Id == id);
    }

    public void UpdateOffer(Offer offerToUpdate)
    {
        var offer = Offers.First(x => x.Id == offerToUpdate.Id);
        _mapper.Map(offerToUpdate, offer);
    }
}