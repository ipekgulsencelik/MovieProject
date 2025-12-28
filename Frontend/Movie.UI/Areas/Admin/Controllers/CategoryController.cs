using Microsoft.AspNetCore.Mvc;
using Movie.Domain.Entities.Enum;
using Movie.DTO.DTOs.CategoryDTOs;
using Movie.UI.Helpers;

namespace Movie.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class CategoryController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            try
            {
                var values = await _client.GetFromJsonAsync<List<ResultCategoryDTO>>("Categories");
                return View(values ?? new List<ResultCategoryDTO>());
            }
            catch
            {
                TempData["ToastType"] = "error";
                TempData["ToastMessage"] = "❌ Kategoriler yüklenirken hata oluştu.";
                return View(new List<ResultCategoryDTO>());
            }
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

        public record UpdateCategoryStatusRequest(int Id, CategoryStatus CategoryStatus);

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStatus([FromBody] UpdateCategoryStatusRequest request)
        {
            if (request == null)
                return BadRequest("Geçersiz istek.");

            if (request.Id <= 0)
                return BadRequest("Geçersiz kategori id.");

            // Pending manuel seçilemesin (Pending sadece Approve/Reject ile değişsin)
            if (request.CategoryStatus == CategoryStatus.Pending)
                return BadRequest("Pending durumu manuel seçilemez.");

            // WebAPI: POST api/Categories/update-status
            var res = await _client.PostAsJsonAsync("Categories/update-status", request);

            if (!res.IsSuccessStatusCode)
            {
                var apiMsg = await res.Content.ReadAsStringAsync();
                return BadRequest(string.IsNullOrWhiteSpace(apiMsg) ? "Durum güncellenemedi." : apiMsg);
            }

            return Ok();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ApproveCategory(int id)
        {
            return await PatchAndRedirect(
                id,
                $"Categories/approve/{id}",
                successMsg: "✅ Kategori onaylandı.",
                errorMsg: "❌ Kategori onaylanamadı."
            );
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RejectCategory(int id)
        {
            return await PatchAndRedirect(
                id,
                $"Categories/reject/{id}",
                successMsg: "✅ Kategori reddedildi (Pasif).",
                errorMsg: "❌ Kategori reddedilemedi."
            );
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ArchiveCategory(int id)
        {
            return await PatchAndRedirect(
                id,
                $"Categories/archive/{id}",
                successMsg: "🗄️ Kategori arşivlendi.",
                errorMsg: "❌ Kategori arşivlenemedi."
            );
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UnarchiveCategory(int id)
        {
            return await PatchAndRedirect(
                id,
                $"Categories/unarchive/{id}",
                successMsg: "✅ Kategori tekrar aktif edildi.",
                errorMsg: "❌ Kategori geri alınamadı."
            );
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SoftDeleteCategory(int id)
        {
            return await DeleteAndRedirect(
                id,
                $"Categories/soft/{id}",
                successMsg: "🗑️ Kategori çöp kutusuna taşındı.",
                errorMsg: "❌ Kategori silinemedi."
            );
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> HardDeleteCategory(int id)
        {
            return await DeleteAndRedirect(
                id,
                $"Categories/hard/{id}",
                successMsg: "🔥 Kategori kalıcı olarak silindi.",
                errorMsg: "❌ Kategori kalıcı silinemedi."
            );
        }

        private async Task<IActionResult> PatchAndRedirect(int id, string apiPath, string successMsg, string errorMsg)
        {
            if (id <= 0)
            {
                TempData["ToastType"] = "error";
                TempData["ToastMessage"] = "❌ Geçersiz kategori id.";
                return RedirectToAction(nameof(CategoryList));
            }

            var request = new HttpRequestMessage(HttpMethod.Patch, apiPath);
            var res = await _client.SendAsync(request);

            if (!res.IsSuccessStatusCode)
            {
                var apiMsg = await res.Content.ReadAsStringAsync();
                TempData["ToastType"] = "error";
                TempData["ToastMessage"] = string.IsNullOrWhiteSpace(apiMsg) ? errorMsg : $"❌ {apiMsg}";
                return RedirectToAction(nameof(CategoryList));
            }

            TempData["ToastType"] = "success";
            TempData["ToastMessage"] = successMsg;
            return RedirectToAction(nameof(CategoryList));
        }

        private async Task<IActionResult> DeleteAndRedirect(int id, string apiPath, string successMsg, string errorMsg)
        {
            if (id <= 0)
            {
                TempData["ToastType"] = "error";
                TempData["ToastMessage"] = "❌ Geçersiz kategori id.";
                return RedirectToAction(nameof(CategoryList));
            }

            var res = await _client.DeleteAsync(apiPath);

            if (!res.IsSuccessStatusCode)
            {
                var apiMsg = await res.Content.ReadAsStringAsync();
                TempData["ToastType"] = "error";
                TempData["ToastMessage"] = string.IsNullOrWhiteSpace(apiMsg) ? errorMsg : $"❌ {apiMsg}";
                return RedirectToAction(nameof(CategoryList));
            }

            TempData["ToastType"] = "success";
            TempData["ToastMessage"] = successMsg;
            return RedirectToAction(nameof(CategoryList));
        }
    }
}