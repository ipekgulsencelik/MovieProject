using Microsoft.AspNetCore.Mvc;
using Movie.DTO.DTOs.UserRegisterDTOs;

namespace Movie.UI.Controllers
{
    public class RegisterController : Controller
    {
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(CreateUserRegisterDTO createUserRegisterDTO)
        {
            return RedirectToAction("SignIn", "Login");
        }
    }
}