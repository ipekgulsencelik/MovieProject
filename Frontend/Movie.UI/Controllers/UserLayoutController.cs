using Microsoft.AspNetCore.Mvc;

namespace Movie.UI.Controllers
{
    public class UserLayoutController : Controller
    {
        public IActionResult Layout()
        {
            return View();
        }
    }
}