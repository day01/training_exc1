using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
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
    private readonly IOponeoAddingService _oponeoAddingService;

    public OffersController(
        IRepository repository,
        IMapper mapper,
        IOponeoAddingService oponeoAddingService)
    {
        _repository = repository;
        _mapper = mapper;
        _oponeoAddingService = oponeoAddingService;
    }
    
    // GET: /offers/active
    [HttpGet(template:"active")]
    public ActionResult<List<OfferReadModel>> GetActiveOffers()
    {
        var offers = _repository.GetActiveOffers();
        var result = _mapper.Map<List<OfferReadModel>>(offers);

        return Ok(result);
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
    [ProducesResponseType(StatusCodes.Status201Created)]
    // POST: /offers
    public ActionResult CreateOffer([FromBody] CreateOffer offerModel)
    {
        _ = offerModel ?? throw new ArgumentException();
        var offer = _mapper.Map<Offer>(offerModel);
        
        _repository.AddOffer(offer);

        return CreatedAtRoute(nameof(GetOfferById), new {id = offer.Id}, offer);
    }

    [HttpPatch("{id}")]
    public ActionResult PatchOffer(long id, JsonPatchDocument<OfferModel> patchDocumentOfferModel)
    {
        var offer = _repository.GetOffer(id);

        var offerModel = _mapper.Map<OfferModel>(offer);
        
        patchDocumentOfferModel.ApplyTo(offerModel);

        var offerToUpdate = _mapper.Map<Offer>(offerModel);

        _repository.UpdateOffer(offerToUpdate);
        
        return NoContent();
    }
}