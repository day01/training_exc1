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

    public List<Offer> Offers { get; set; } = new()
    {
        new()
        {
            Id = 1000,
            CreatedDate = DateTime.Now,
            DeletedDate = null,
            OptionOfferStatus = "Active",
            Option2 = 2,
            Status = OfferStatus.Active,
            ProductName = "Example",
            Size = 100,
        }
    };

    public void IncreaseSizeById(long id)
    {
        return;
    }

    public Task<List<Offer>> GetOffers()
    {
        return Task.FromResult(Offers);
    }

    public Task<List<Offer>> GetActiveOffers()
    {
        var result = Offers
            .Where(x => x.Status == OfferStatus.Active)
            .ToList();

        return Task.FromResult(result);
    }

    public Task AddOffer(Offer offer)
    {
        var maxPrimaryKey = Offers.Max(x => (long?) x.Id) ?? 0;
        offer.Id = maxPrimaryKey + 1;
        offer.CreatedDate = DateTime.Now;
        offer.Status = OfferStatus.Active;

        Offers.Add(offer);

        return Task.CompletedTask;
    }
    public Task<Offer?> GetOffer(long id)
    {
        return Task.FromResult(Offers.FirstOrDefault(x => x.Id == id));
    }

    public Task UpdateOffer(Offer offerToUpdate)
    {
        var offer = Offers.First(x => x.Id == offerToUpdate.Id);
        _mapper.Map(offerToUpdate, offer);

        return Task.CompletedTask;
    }
}