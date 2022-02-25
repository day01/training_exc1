namespace Oponeo.Domain;

public interface IOfferRepository
{
    Offer GetById(int id);

    void CreateOffer(Offer offer);

    void DeleteOffer(int id);

    List<Offer> GetOffers();

    void SaveChanges();
}