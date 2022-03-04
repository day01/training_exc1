namespace Oponeo.Domain;

public interface IRepository
{
    void IncreaseSizeById(long id);

    Task<List<Offer>> GetOffers();

    Task<List<Offer>> GetActiveOffers();

    Task AddOffer(Offer offer);

    Task<Offer?> GetOffer(long id);

    Task UpdateOffer(Offer offerToUpdate);
}