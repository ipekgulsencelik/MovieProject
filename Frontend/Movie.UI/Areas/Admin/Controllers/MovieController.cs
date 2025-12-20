using Microsoft.AspNetCore.Mvc;
using Movie.DTO.DTOs.MovieDTOs;
using Movie.UI.Helpers;

namespace Movie.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class MovieController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IActionResult> MovieList()
        {
            var values = await _client.GetFromJsonAsync<List<ResultMovieDTO>>("Movies");
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> MovieDetail(int id)
        {
            var value = await _client.GetFromJsonAsync<ResultMovieDTO>($"Movies/{id}");
            return View(value);
        }

        [HttpGet]
        public IActionResult CreateMovie()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateMovie(int id)
        {
            var value = await _client.GetFromJsonAsync<UpdateMovieDTO>($"Movies/{id}");
            return View(value);
        }
    }
}