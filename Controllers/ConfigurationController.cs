using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace OponeoViewsAndAuth.Start.Controllers;

public class ConfigurationController : Controller
{
    // GET
    public IActionResult Index()
    {
        
        var result = new List<string> {"Product-1", "Product-2", "Product-3"};

        return View(result);
    }
}