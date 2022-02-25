using AutoMapper;
using Oponeo.Contract;
using Oponeo.Domain;

namespace Oponeo.Controllers.Controllers.Profiles;

public class OfferProfile : Profile
{
    public OfferProfile()
    {
        CreateMap<Offer, OfferModel>();
        CreateMap<OfferModel, Offer>()
            .ForMember(x => x.Id, opt => opt.Ignore());
    }
}