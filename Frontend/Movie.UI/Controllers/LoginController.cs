using Microsoft.AspNetCore.Mvc;

namespace Movie.UI.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
    }
}