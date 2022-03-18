using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OponeoViewsAndAuth.Start.ViewModels;

namespace OponeoViewsAndAuth.Start.Controllers;

public class OfferController : Controller
{
    // GET
    public IActionResult Index()
    {
        var model = new List<OfferReadModel>
        {
            new OfferReadModel
            {
                CreatedDate = DateTime.Now,
                Id = 1,
                Option2 = 2,
                PresentationOption2InMeters = "1 km",
                ProductName = "Name of product",
                Size = 100,
                Status = OfferStatus.Active,
            },
            new OfferReadModel
            {
                CreatedDate = DateTime.Now,
                Id = 2,
                Option2 = 3,
                PresentationOption2InMeters = "1 km",
                ProductName = "Name of product",
                Size = 300,
                Status = OfferStatus.Historical,
            },
            new OfferReadModel
            {
                CreatedDate = DateTime.Now,
                Id = 3,
                Option2 = 4,
                PresentationOption2InMeters = "1 km",
                ProductName = "Name of product",
                Size = 200,
                Status = OfferStatus.Active,
            }
        };
        return View(model);
    }

    [HttpGet("/offer/{id}")]
    [Authorize]
    public IActionResult Edit(long id)
    {
        return View("Edit");
    }
    
    [HttpPost("/offer/{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Edit(long id, [FromForm] EditOffer model)
    {
        return RedirectToAction("Index");
    }
}