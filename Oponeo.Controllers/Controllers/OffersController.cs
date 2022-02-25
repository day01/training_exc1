using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Oponeo.Contract;
using Oponeo.Domain;

namespace Oponeo.Controllers.Controllers;

[ApiController]
[Route("[controller]")]
public class OffersController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IOfferRepository _offerRepository;

    public OffersController(IMapper mapper, IOfferRepository offerRepository)
    {
        _mapper = mapper;
        _offerRepository = offerRepository;
    }

    [HttpGet("{id}", Name = nameof(GetOfferById))]
    public ActionResult<OfferModel> GetOfferById(int id)
    {
        var offer = _offerRepository.GetById(id);
        return Ok(offer);
    }

    [HttpPost]
    public ActionResult CreateOffer([FromBody] OfferModel offerModel)
    {
        var offer = _mapper.Map<Offer>(offerModel);
        var result = _mapper.Map<OfferModel>(offer);
        return CreatedAtRoute(nameof(GetOfferById), new {Id = 1}, result);
    }

    [HttpPatch("{id}")]
    public ActionResult PartialUpdateOffer(int id, JsonPatchDocument<OfferModel> patchDocument)
    {
        var offer = new Offer() {Id = id};
        var model = _mapper.Map<OfferModel>(offer);

        patchDocument.ApplyTo(model);

        _mapper.Map(model, offer);

        return NoContent();
    }
}