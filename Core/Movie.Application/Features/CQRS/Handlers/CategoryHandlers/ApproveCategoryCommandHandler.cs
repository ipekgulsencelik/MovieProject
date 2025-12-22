using Movie.Application.Features.CQRS.Commands.CategoryCommands;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;
using Movie.Domain.Entities.Enum;

namespace Movie.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class ApproveCategoryCommandHandler
    {
        private readonly IRepository<Category> _repository;

        public ApproveCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task Handle(ApproveCategoryCommand command)
        {
            var category = await _repository.GetByIdAsync(command.Id);

            // ✅ Pending -> Active
            category.CategoryStatus = CategoryStatus.Active;

            // istersen: aktifken görünür de olsun
            // category.IsActive = true; (BaseEntity’de varsa)
            // category.IsVisible = true;

            await _repository.UpdateAsync(category);
        }
    }
}