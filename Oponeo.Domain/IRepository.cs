namespace Oponeo.Domain;

public interface IRepository
{
    void IncreaseSizeById(long id);

    List<Offer> GetOffers();

    void AddOffer(Offer offer);
}