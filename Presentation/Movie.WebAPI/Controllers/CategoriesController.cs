using Microsoft.AspNetCore.Mvc;
using Movie.Application.Features.CQRS.Commands;
using Movie.Application.Features.CQRS.Commands.CategoryCommands;
using Movie.Application.Features.CQRS.Handlers.CategoryHandlers;
using Movie.Application.Features.CQRS.Queries.CategoryQueries;
using Movie.DTO.DTOs.CategoryDTOs;

namespace Movie.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CreateCategoryCommandHandler _createCategoryCommandHandler;
        private readonly GetCategoryByIdQueryHandler _getCategoryByIdQueryHandler;
        private readonly GetCategoryQueryHandler _getCategoryQueryHandler;
        private readonly UpdateCategoryCommandHandler _updateCategoryCommandHandler;

        private readonly ToggleCategoryStatusCommandHandler _toggleCategoryStatusCommandHandler;
        private readonly ShowCategoryCommandHandler _showCategoryCommandHandler;
        private readonly HideCategoryCommandHandler _hideCategoryCommandHandler;

        private readonly RemoveCategoryCommandHandler _removeCategoryCommandHandler;

        private readonly ArchiveCategoryCommandHandler _archiveCategoryCommandHandler;
        private readonly UnarchiveCategoryCommandHandler _unarchiveCategoryCommandHandler;
        private readonly SoftDeleteCategoryCommandHandler _softDeleteCategoryCommandHandler;
        private readonly HardDeleteCategoryCommandHandler _hardDeleteCategoryCommandHandler;

        private readonly GetActiveCategoriesQueryHandler _getActiveCategoriesQueryHandler;
        private readonly GetVisibleCategoriesQueryHandler _getVisibleCategoriesQueryHandler;
        private readonly ApproveCategoryCommandHandler _approveCategoryCommandHandler;

        private readonly UpdateCategoryStatusCommandHandler _updateCategoryStatusCommandHandler;
        private readonly RejectCategoryCommandHandler _rejectCategoryCommandHandler;

        public CategoriesController(CreateCategoryCommandHandler createCategoryCommandHandler, GetCategoryByIdQueryHandler getCategoryByIdQueryHandler, GetCategoryQueryHandler getCategoryQueryHandler, UpdateCategoryCommandHandler updateCategoryCommandHandler, RemoveCategoryCommandHandler removeCategoryCommandHandler, ToggleCategoryStatusCommandHandler toggleCategoryStatusCommandHandler, HideCategoryCommandHandler hideCategoryCommandHandler, ShowCategoryCommandHandler showCategoryCommandHandler, GetVisibleCategoriesQueryHandler getVisibleCategoriesQueryHandler, GetActiveCategoriesQueryHandler getActiveCategoriesQueryHandler,
            ArchiveCategoryCommandHandler archiveCategoryCommandHandler,
            UnarchiveCategoryCommandHandler unarchiveCategoryCommandHandler,
            SoftDeleteCategoryCommandHandler softDeleteCategoryCommandHandler,
            HardDeleteCategoryCommandHandler hardDeleteCategoryCommandHandler, ApproveCategoryCommandHandler approveCategoryCommandHandler,
            UpdateCategoryStatusCommandHandler updateCategoryStatusCommandHandler,
            RejectCategoryCommandHandler rejectCategoryCommandHandler)
        {
            _createCategoryCommandHandler = createCategoryCommandHandler;
            _getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
            _getCategoryQueryHandler = getCategoryQueryHandler;
            _updateCategoryCommandHandler = updateCategoryCommandHandler;

            _removeCategoryCommandHandler = removeCategoryCommandHandler;
            _showCategoryCommandHandler = showCategoryCommandHandler;
            _hideCategoryCommandHandler = hideCategoryCommandHandler;
            _toggleCategoryStatusCommandHandler = toggleCategoryStatusCommandHandler;

            _getActiveCategoriesQueryHandler = getActiveCategoriesQueryHandler;
            _getVisibleCategoriesQueryHandler = getVisibleCategoriesQueryHandler;

            _archiveCategoryCommandHandler = archiveCategoryCommandHandler;
            _unarchiveCategoryCommandHandler = unarchiveCategoryCommandHandler;
            _softDeleteCategoryCommandHandler = softDeleteCategoryCommandHandler;
            _hardDeleteCategoryCommandHandler = hardDeleteCategoryCommandHandler;
            _approveCategoryCommandHandler = approveCategoryCommandHandler;

            _updateCategoryStatusCommandHandler = updateCategoryStatusCommandHandler;
            _rejectCategoryCommandHandler = rejectCategoryCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoryList()
        {
            var categories = await _getCategoryQueryHandler.Handle();
            return Ok(categories);
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetActiveCategoryList()
        {
            var categories = await _getActiveCategoriesQueryHandler.Handle();
            return Ok(categories);
        }

        [HttpGet("visible")]
        public async Task<IActionResult> GetVisibleCategoryList()
        {
            var categories = await _getVisibleCategoriesQueryHandler.Handle();
            return Ok(categories);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            await _createCategoryCommandHandler.Handle(command);
            return Ok("Kategori Bilgisi Eklendi");
        }

        [HttpPatch("approve/{id}")]
        public async Task<IActionResult> ApproveCategory(int id)
        {
            await _approveCategoryCommandHandler.Handle(new ApproveCategoryCommand(id));
            return Ok("Kategori onaylandı.");
        }

        [HttpPatch("archive/{id}")]
        public async Task<IActionResult> Archive(int id)
        {
            await _archiveCategoryCommandHandler.Handle(new ArchiveCategoryCommand(id));
            return Ok("Kategori arşivlendi.");
        }

        [HttpPatch("unarchive/{id}")]
        public async Task<IActionResult> Unarchive(int id)
        {
            await _unarchiveCategoryCommandHandler.Handle(new UnarchiveCategoryCommand(id));
            return Ok("Kategori arşivden çıkarıldı.");
        }

        [HttpDelete("soft/{id}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            await _softDeleteCategoryCommandHandler.Handle(new SoftDeleteCategoryCommand(id));
            return Ok("Kategori çöp kutusuna taşındı (soft delete).");
        }

        [HttpDelete("hard/{id}")]
        public async Task<IActionResult> HardDelete(int id)
        {
            await _hardDeleteCategoryCommandHandler.Handle(new HardDeleteCategoryCommand(id));
            return Ok("Kategori kalıcı olarak silindi.");
        }

        [HttpPatch("reject/{id}")]
        public async Task<IActionResult> RejectCategory(int id)
        {
            await _rejectCategoryCommandHandler.Handle(new RejectCategoryCommand(id));
            return Ok("Kategori reddedildi (Pasif).");
        }

        [HttpPost("update-status")]
        public async Task<IActionResult> UpdateStatus([FromBody] UpdateCategoryStatusDTO dto)
        {
            if (dto == null)
                return BadRequest("Geçersiz istek.");

            if (dto.Id <= 0)
                return BadRequest("Geçersiz kategori id.");

            await _updateCategoryStatusCommandHandler.Handle(
                new UpdateCategoryStatusCommand(dto.Id, dto.CategoryStatus)
            );

            return Ok("Kategori durumu güncellendi.");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _removeCategoryCommandHandler.Handle(new RemoveCategoryCommand(id));
            return Ok("Kalıcı silme başarılı!");
        }

        [HttpPatch("show/{id}")]
        public async Task<IActionResult> ShowCategory(int id)
        {
            await _showCategoryCommandHandler.Handle(new ShowCategoryCommand(id));
            return Ok("Category is visible");
        }

        [HttpPatch("hide/{id}")]
        public async Task<IActionResult> HideCategory(int id)
        {
            await _hideCategoryCommandHandler.Handle(new HideCategoryCommand(id));
            return Ok("Category is hidden");
        }

        [HttpPatch("toggle-status/{id}")]
        public async Task<IActionResult> ToggleCategoryStatus(int id)
        {
            await _toggleCategoryStatusCommandHandler.Handle(new ToggleCategoryStatusCommand(id));
            return Ok("Category status updated");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
            await _updateCategoryCommandHandler.Handle(command);
            return Ok("Güncelleme işlemi başarılı!");
        }

        [HttpGet("GetCategory")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var value = await _getCategoryByIdQueryHandler.Handle(new GetCategoryByIdQuery(id));
            return Ok(value);
        }
    }
}