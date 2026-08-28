using Microsoft.AspNetCore.Mvc;

namespace SaraTort.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // Pechniylar o'rniga Pirojniylar
        public IActionResult Pirojniylar()
        {
            return View();
        }

        public IActionResult Bar()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}