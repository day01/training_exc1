using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Oponeo.Contracts.Offers;
using Oponeo.Domain;

namespace Oponeo.Controllers.Controllers;

[ApiController]
[Route("offers")]
public class OffersController : ControllerBase
{
    private readonly IRepository _repository;
    private readonly IMapper _mapper;

    public OffersController(IRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    // GET: /offers/active
    [HttpGet(template:"active")]
    public ActionResult<List<OfferReadModel>> GetActiveOffers()
    {
        throw new NotImplementedException();
    }    
    
    // GET: /offers
    [HttpGet]
    public ActionResult<List<OfferReadModel>> GetOffers()
    {
        var offers = _repository.GetOffers();
        var result = _mapper.Map<List<OfferReadModel>>(offers);

        return Ok(result);
    }
    
    // GET: /offers/{id}
    [HttpGet("{id}", Name = nameof(GetOfferById))]
    public ActionResult<List<OfferReadModel>> GetOfferById(long id)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    // POST: /offers
    public ActionResult CreateOffer([FromBody] CreateOffer offerModel)
    {
        _ = offerModel ?? throw new ArgumentException();
        var offer = _mapper.Map<Offer>(offerModel);
        
        _repository.AddOffer(offer);

        return CreatedAtRoute(nameof(GetOfferById), new {id = offer.Id}, offer);
    }
}