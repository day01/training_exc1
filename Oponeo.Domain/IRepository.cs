namespace Oponeo.Domain;

public interface IRepository
{
    void IncreaseSizeById(long id);

    List<Offer> GetOffers();

    void AddOffer(Offer offer);

    Offer? GetOffer(long id);

    void UpdateOffer(Offer offerToUpdate);
}