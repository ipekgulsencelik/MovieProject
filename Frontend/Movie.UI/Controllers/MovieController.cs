using Microsoft.AspNetCore.Mvc;

namespace Movie.UI.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.header = "Film Listesi";
            ViewBag.home = "Ana Sayfa";
            ViewBag.current = "Tüm Filmler";

            return View();
        }
    }
}