using Microsoft.AspNetCore.Mvc;

namespace Movie.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}