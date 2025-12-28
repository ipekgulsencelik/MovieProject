using Microsoft.AspNetCore.Mvc;
using Movie.DTO.DTOs.CategoryDTOs;
using Movie.DTO.DTOs.MovieDTOs;
using Movie.UI.Helpers;

namespace Movie.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class MovieController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        [HttpGet]
        public async Task<IActionResult> MovieList()
        {
            try
            {
                var values = await _client.GetFromJsonAsync<List<ResultMovieDTO>>("Movies");
                return View(values ?? new List<ResultMovieDTO>());
            }
            catch (HttpRequestException)
            {
                TempData["ErrorMessage"] = "Filmler yüklenirken bir hata oluştu.";
                return View(new List<ResultMovieDTO>());
            }
        }

        [HttpGet]
        public async Task<IActionResult> MovieDetail(int id)
        {
            try
            {
                var value = await _client.GetFromJsonAsync<ResultMovieDTO>($"Movies/{id}");

                if (value is null)
                {
                    TempData["ErrorMessage"] = "Film bulunamadı.";
                    return RedirectToAction(nameof(MovieList));
                }

                return View(value);
            }
            catch (HttpRequestException)
            {
                TempData["ErrorMessage"] = "Film detayı yüklenirken bir hata oluştu.";
                return RedirectToAction(nameof(MovieList));
            }
        }

        [HttpGet]
        public async Task<IActionResult> CreateMovie()
        {
            await FillCategories();
            return View(new CreateMovieDTO());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMovie(CreateMovieDTO dto)
        {
            if (!ModelState.IsValid)
            {
                await FillCategories();
                return View(dto);
            }

            try
            {
                var response = await _client.PostAsJsonAsync("Movies", dto);

                if (!response.IsSuccessStatusCode)
                {
                    await FillCategories();

                    // API bir hata mesajı dönüyorsa okumaya çalış
                    var apiError = await SafeReadStringAsync(response);

                    TempData["ErrorMessage"] = string.IsNullOrWhiteSpace(apiError)
                        ? "Film eklenemedi. Lütfen tekrar deneyin."
                        : apiError;

                    return View(dto);
                }

                TempData["SuccessMessage"] = "Film başarıyla eklendi ✅";
                return RedirectToAction(nameof(MovieList));
            }
            catch (HttpRequestException)
            {
                await FillCategories();
                TempData["ErrorMessage"] = "Sunucuya ulaşılamadı. Lütfen tekrar deneyin.";
                return View(dto);
            }
        }

        [HttpGet]
        public async Task<IActionResult> UpdateMovie(int id)
        {
            try
            {
                await FillCategories();

                var value = await _client.GetFromJsonAsync<UpdateMovieDTO>($"Movies/{id}");
                if (value is null)
                {
                    TempData["ErrorMessage"] = "Güncellenecek film bulunamadı.";
                    return RedirectToAction(nameof(MovieList));
                }

                return View(value);
            }
            catch (HttpRequestException)
            {
                TempData["ErrorMessage"] = "Film bilgisi yüklenirken bir hata oluştu.";
                return RedirectToAction(nameof(MovieList));
            }
        }

        private async Task FillCategories()
        {
            try
            {
                var categories = await _client.GetFromJsonAsync<List<ResultCategoryDTO>>("Categories");
                ViewBag.Categories = categories ?? new List<ResultCategoryDTO>();
            }
            catch (HttpRequestException)
            {
                ViewBag.Categories = new List<ResultCategoryDTO>();
                TempData["ErrorMessage"] = "Kategoriler yüklenemedi.";
            }
        }

        private static async Task<string?> SafeReadStringAsync(HttpResponseMessage response)
        {
            try { return await response.Content.ReadAsStringAsync(); }
            catch { return null; }
        }
    }
}