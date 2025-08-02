using Microsoft.AspNetCore.Mvc;
using Movie.DTO.DTOs.MovieDTOs;
using Movie.DTO.DTOs.UserRegisterDTOs;
using Movie.UI.Helpers;

namespace Movie.UI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(CreateUserRegisterDTO createUserRegisterDTO)
        {
            if (!ModelState.IsValid)
            {
                // Model valid değilse formu tekrar göster
                return View(createUserRegisterDTO);
            }

            var response = await _client.PostAsJsonAsync("UserRegisters", createUserRegisterDTO);

            if (response.IsSuccessStatusCode)
            {
                // Başarılı ise giriş sayfasına yönlendir
                return RedirectToAction("SignIn", "Login");
            }
            else
            {
                // Başarısız ise hata mesajı göster veya hata sayfasına yönlendir
                ModelState.AddModelError("", "Kayıt sırasında bir hata oluştu. Lütfen tekrar deneyiniz.");
                return View(createUserRegisterDTO);
            }
        }
    }
}