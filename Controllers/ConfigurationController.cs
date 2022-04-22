using Microsoft.AspNetCore.Mvc;

namespace OponeoViewsAndAuth.Start.Controllers;

public class ConfigurationController : Controller
{
    public IActionResult Index()
    {
        var result = new [] {"test", "test2"};
        return View(result);
    }
}