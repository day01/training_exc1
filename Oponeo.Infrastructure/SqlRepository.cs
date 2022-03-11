using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Oponeo.Domain;

namespace Oponeo.Infrastructure;

public class SqlRepository: IRepository, IIocScoped
{
    private readonly OponeoContext _oponeoContext;
    private readonly IMapper _mapper;

    public SqlRepository(OponeoContext oponeoContext, IMapper mapper)
    {
        _oponeoContext = oponeoContext;
        _mapper = mapper;
    }
    public void IncreaseSizeById(long id)
    {
        // no used
    }

    public Task<List<Offer>> GetOffers()
    {
        return _oponeoContext
            .Offers
            .Include(x=> x.Parameters)
            .ToListAsync();
    }

    public Task<List<Offer>> GetActiveOffers()
    {
        return _oponeoContext
            .Offers
            .Include(x => x.Parameters)
            .Where(x => x.Status == OfferStatus.Active)
            .ToListAsync();
    }

    public async Task AddOffer(Offer offer)
    {
         await _oponeoContext.AddAsync(offer);
         await _oponeoContext.SaveChangesAsync();
    }

    public Task<Offer?> GetOffer(long id)
    {
        return _oponeoContext.Offers.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task UpdateOffer(Offer offerToUpdate)
    {
        var offer = _oponeoContext.Offers.First(x => x.Id == offerToUpdate.Id);
        _mapper.Map(offerToUpdate, offer);

        await _oponeoContext.SaveChangesAsync();
    }
}