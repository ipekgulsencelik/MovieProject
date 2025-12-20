using Microsoft.AspNetCore.Mvc;

namespace Movie.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class MovieController : Controller
    {
        public IActionResult MovieList()
        {
            return View();
        }
    }
}