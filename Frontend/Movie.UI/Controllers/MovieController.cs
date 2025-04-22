using Microsoft.AspNetCore.Mvc;
using Movie.DTO.DTOs.MovieDTOs;
using Movie.UI.Helpers;

namespace Movie.UI.Controllers
{
    public class MovieController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
            ViewBag.header = "Film Listesi";
            ViewBag.home = "Ana Sayfa";
            ViewBag.current = "Tüm Filmler";

            var values = await _client.GetFromJsonAsync<List<ResultMovieDTO>>("Movies/visible");
            return View(values);
        }
    }
}