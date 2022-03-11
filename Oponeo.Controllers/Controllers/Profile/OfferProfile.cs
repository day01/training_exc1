using Oponeo.Contracts.Offers;
using Oponeo.Domain;

namespace Oponeo.Controllers.Controllers.Profile;

public class OfferProfile : AutoMapper.Profile
{
    public OfferProfile()
    {
        CreateMap<CreateOffer, Offer>()
            .ForMember(x => x.Id, opt => opt.Ignore())
            .ForMember(x => x.CreatedDate, opt => opt.Ignore())
            .ForMember(x => x.Parameters, opt => opt.MapFrom(y => y.Parameters));

        CreateMap<Offer, OfferReadModel>()
            .ForMember(x => x.PresentationOpetion2InMeters,
                opt => opt.MapFrom(y => $"{y.Option2 * 1000} m"))
            .ForMember(
                x => x.Option2,
                opt => opt.MapFrom(y => (OfferStatus) Enum.Parse(typeof(OfferStatus), y.OptionOfferStatus)));

        CreateMap<Offer, OfferModel>();
        CreateMap<OfferModel, Offer>();
        
        CreateMap<Offer, OfferInsteadModel>()
            .ForMember(x=> x.Option2, opt=> opt.MapFrom(x=> x.Option2));
        CreateMap<OfferInsteadModel, Offer>();
        CreateMap<Offer, Offer>();

        CreateMap<ContractParameter, StringParameter>();
    }
}