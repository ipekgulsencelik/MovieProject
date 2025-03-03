using Microsoft.AspNetCore.Mvc;
using Movie.Application.Features.CQRS.Commands.CategoryCommands;
using Movie.Application.Features.CQRS.Handlers.CategoryHandlers;
using Movie.Application.Features.CQRS.Queries.CategoryQueries;

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
        private readonly GetActiveCategoriesQueryHandler _getActiveCategoriesQueryHandler;
        private readonly GetVisibleCategoriesQueryHandler _getVisibleCategoriesQueryHandler;

        public CategoriesController(CreateCategoryCommandHandler createCategoryCommandHandler, GetCategoryByIdQueryHandler getCategoryByIdQueryHandler, GetCategoryQueryHandler getCategoryQueryHandler, UpdateCategoryCommandHandler updateCategoryCommandHandler, RemoveCategoryCommandHandler removeCategoryCommandHandler, ToggleCategoryStatusCommandHandler toggleCategoryStatusCommandHandler, HideCategoryCommandHandler hideCategoryCommandHandler, ShowCategoryCommandHandler showCategoryCommandHandler, GetVisibleCategoriesQueryHandler getVisibleCategoriesQueryHandler, GetActiveCategoriesQueryHandler getActiveCategoriesQueryHandler)
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

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _removeCategoryCommandHandler.Handle(new RemoveCategoryCommand(id));
            return Ok("Silme işlemi başarılı!");
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