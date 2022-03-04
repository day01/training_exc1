using Oponeo.Contracts.Offers;
using Oponeo.Domain;

namespace Oponeo.Controllers.Controllers.Profile;

public class OfferProfile : AutoMapper.Profile
{
    public OfferProfile()
    {
        CreateMap<CreateOffer, Offer>()
            .ForMember(x => x.Id, opt => opt.Ignore())
            .ForMember(x => x.CreatedDate, opt => opt.Ignore());

        CreateMap<Offer, OfferReadModel>()
            .ForMember(x => x.PresentationOpetion2InMeters,
                opt => opt.MapFrom(y => $"{y.Option2 * 1000} m"));

        CreateMap<Offer, OfferModel>();
        CreateMap<OfferModel, Offer>();
        CreateMap<Offer, Offer>();
    }
}