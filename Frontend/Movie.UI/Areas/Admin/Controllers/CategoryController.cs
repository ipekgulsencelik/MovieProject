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
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCategory(CreateCategoryDTO dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var response = await _client.PostAsJsonAsync("Categories", dto);

            if (!response.IsSuccessStatusCode)
            {
                var apiMsg = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError("", string.IsNullOrWhiteSpace(apiMsg)
                    ? "Kategori eklenirken hata oluştu."
                    : apiMsg);

                return View(dto);
            }

            // ✅ Daha açıklayıcı geri dönüş
            TempData["ToastType"] = "success";
            TempData["ToastMessage"] = "✅ Kategori oluşturuldu. Onay bekliyor.";

            return RedirectToAction("CategoryList");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ApproveCategory(int id)
        {
            if (id <= 0)
            {
                TempData["ToastType"] = "error";
                TempData["ToastMessage"] = "❌ Geçersiz kategori id.";
                return RedirectToAction("CategoryList");
            }

            var request = new HttpRequestMessage(HttpMethod.Patch, $"Categories/approve/{id}");
            var res = await _client.SendAsync(request);

            if (!res.IsSuccessStatusCode)
            {
                var apiMsg = await res.Content.ReadAsStringAsync();
                TempData["ToastType"] = "error";
                TempData["ToastMessage"] = string.IsNullOrWhiteSpace(apiMsg)
                    ? "❌ Kategori onaylanamadı."
                    : $"❌ {apiMsg}";
                return RedirectToAction("CategoryList");
            }

            TempData["ToastType"] = "success";
            TempData["ToastMessage"] = "✅ Kategori onaylandı.";
            return RedirectToAction("CategoryList");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ArchiveCategory(int id)
        {
            if (id <= 0)
            {
                TempData["ToastType"] = "error";
                TempData["ToastMessage"] = "❌ Geçersiz kategori id.";
                return RedirectToAction("CategoryList");
            }

            var request = new HttpRequestMessage(HttpMethod.Patch, $"Categories/archive/{id}");

            var res = await _client.SendAsync(request);

            if (!res.IsSuccessStatusCode)
            {
                var apiMsg = await res.Content.ReadAsStringAsync();
                TempData["ToastType"] = "error";
                TempData["ToastMessage"] = string.IsNullOrWhiteSpace(apiMsg)
                    ? "❌ Kategori arşivlenemedi."
                    : $"❌ {apiMsg}";
                return RedirectToAction("CategoryList");
            }

            TempData["ToastType"] = "success";
            TempData["ToastMessage"] = "🗄️ Kategori arşivlendi.";
            return RedirectToAction("CategoryList");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UnarchiveCategory(int id)
        {
            if (id <= 0)
            {
                TempData["ToastType"] = "error";
                TempData["ToastMessage"] = "❌ Geçersiz kategori id.";
                return RedirectToAction("CategoryList");
            }

            var request = new HttpRequestMessage(HttpMethod.Patch, $"Categories/unarchive/{id}");
            var res = await _client.SendAsync(request);

            if (!res.IsSuccessStatusCode)
            {
                var apiMsg = await res.Content.ReadAsStringAsync();
                TempData["ToastType"] = "error";
                TempData["ToastMessage"] = string.IsNullOrWhiteSpace(apiMsg)
                    ? "❌ Kategori geri alınamadı."
                    : $"❌ {apiMsg}";
                return RedirectToAction("CategoryList");
            }

            TempData["ToastType"] = "success";
            TempData["ToastMessage"] = "✅ Kategori tekrar aktif edildi.";
            return RedirectToAction("CategoryList");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SoftDeleteCategory(int id)
        {
            if (id <= 0)
            {
                TempData["ToastType"] = "error";
                TempData["ToastMessage"] = "❌ Geçersiz kategori id.";
                return RedirectToAction("CategoryList");
            }

            var res = await _client.DeleteAsync($"Categories/soft/{id}");

            if (!res.IsSuccessStatusCode)
            {
                var apiMsg = await res.Content.ReadAsStringAsync();
                TempData["ToastType"] = "error";
                TempData["ToastMessage"] = string.IsNullOrWhiteSpace(apiMsg)
                    ? "❌ Kategori silinemedi."
                    : $"❌ {apiMsg}";
                return RedirectToAction("CategoryList");
            }

            TempData["ToastType"] = "success";
            TempData["ToastMessage"] = "🗑️ Kategori çöp kutusuna taşındı.";
            return RedirectToAction("CategoryList");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> HardDeleteCategory(int id)
        {
            if (id <= 0)
            {
                TempData["ToastType"] = "error";
                TempData["ToastMessage"] = "❌ Geçersiz kategori id.";
                return RedirectToAction("CategoryList");
            }

            var res = await _client.DeleteAsync($"Categories/hard/{id}");

            if (!res.IsSuccessStatusCode)
            {
                var apiMsg = await res.Content.ReadAsStringAsync();
                TempData["ToastType"] = "error";
                TempData["ToastMessage"] = string.IsNullOrWhiteSpace(apiMsg)
                    ? "❌ Kategori kalıcı silinemedi."
                    : $"❌ {apiMsg}";
                return RedirectToAction("CategoryList");
            }

            TempData["ToastType"] = "success";
            TempData["ToastMessage"] = "🔥 Kategori kalıcı olarak silindi.";
            return RedirectToAction("CategoryList");
        }
    }
}