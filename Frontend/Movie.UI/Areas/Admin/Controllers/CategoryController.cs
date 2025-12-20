using Microsoft.AspNetCore.Mvc;
using Movie.DTO.DTOs.CategoryDTOs;
using Movie.UI.Helpers;

namespace Movie.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class CategoryController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IActionResult> CategoryList()
        {
            var values = await _client.GetFromJsonAsync<List<ResultCategoryDTO>>("Categories");
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateCategory() => View();
    }
}