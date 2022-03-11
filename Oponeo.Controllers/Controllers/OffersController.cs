using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Caching.Memory;
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
    private readonly IMemoryCache _memoryCache;

    public OffersController(
        IRepository repository,
        IMapper mapper,
        IOponeoAddingService oponeoAddingService,
        IMemoryCache memoryCache)
    {
        _repository = repository;
        _mapper = mapper;
        _oponeoAddingService = oponeoAddingService;
        _memoryCache = memoryCache;
    }
    
    // GET: /offers/active
    [HttpGet(template:"active")]
    public async Task<ActionResult<List<OfferReadModel>>> GetActiveOffers()
    {
        const string activeOffersKey = "CACHE_KEY:ACTIVE_OFFERS";
        var exists = _memoryCache.TryGetValue(activeOffersKey, out var cachedOffers);
        if (exists)
        {
            return Ok(cachedOffers);
        }

        var offers = await _repository.GetActiveOffers();
        var result = _mapper.Map<List<OfferReadModel>>(offers);

        const int offerCacheTimeInHours = 1;
        _memoryCache.Set(activeOffersKey, result, TimeSpan.FromHours(offerCacheTimeInHours));

        return Ok(result);
    }    
    
    // GET: /offers
    [HttpGet]
    public async Task<ActionResult<List<OfferReadModel>>> GetOffers()
    {
        var offers =  await _repository.GetOffers();
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
    public async Task<ActionResult> CreateOffer([FromBody] CreateOffer offerModel)
    {
        _ = offerModel ?? throw new ArgumentException();
        
        var offer = _mapper.Map<Offer>(offerModel);
        
        await _repository.AddOffer(offer);

        return CreatedAtRoute(nameof(GetOfferById), new {id = offer.Id}, offer);
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult> PatchOffer(long id, JsonPatchDocument<OfferModel> patchDocumentOfferModel)
    {
        var offer = _repository.GetOffer(id);

        var offerModel = _mapper.Map<OfferModel>(offer);
        
        patchDocumentOfferModel.ApplyTo(offerModel);

        var offerToUpdate = _mapper.Map<Offer>(offerModel);

        await _repository.UpdateOffer(offerToUpdate);
        
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> PutOffer(long id, [FromBody] OfferInsteadModel offerToUpdate)
    {
        var offer = await _repository.GetOffer(id);
        if (offer == null)
        {
            return BadRequest("Id doesnt exist");
        }

        _mapper.Map(offerToUpdate, offer);
        await _repository.UpdateOffer(offer);
        
        return NoContent();
    }

    [HttpPost(template: "reserve/{id}")]
    public async Task<ActionResult> ReserveOffer([FromRoute] int id)
    {
        var offer = await _repository.GetOffer(id);
        if (offer is null)
        {
            return NotFound(id);
        }
        
        const string reserveOffersKey = "CACHE_KEY:ACTIVE_OFFERS:";
        if (_memoryCache.TryGetValue(reserveOffersKey + id, out var reserveId))
        {
            return BadRequest("Object is reserved");
        }

        _memoryCache.Set(reserveOffersKey + id, id, TimeSpan.FromSeconds(10));

        return Ok();
    }
}