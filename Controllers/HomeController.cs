using Microsoft.AspNetCore.Mvc;

namespace OponeoViewsAndAuth.Start.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View("Index");
        }
    }
}
