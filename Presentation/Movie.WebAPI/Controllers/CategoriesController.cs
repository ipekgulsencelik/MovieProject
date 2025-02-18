using Microsoft.AspNetCore.Mvc;
using Movie.Application.Features.CQRS.Commands.CategoryCommands;
using Movie.Application.Features.CQRS.Handlers.CategoryHandlers;

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

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            await _createCategoryCommandHandler.Handle(command);
            return Ok("Kategori Bilgisi Eklendi");
        }
    }
}