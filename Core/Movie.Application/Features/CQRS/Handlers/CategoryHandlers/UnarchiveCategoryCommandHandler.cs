using Movie.Application.Features.CQRS.Commands.CategoryCommands;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;
using Movie.Domain.Entities.Enum;

namespace Movie.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class UnarchiveCategoryCommandHandler
    {
        private readonly IRepository<Category> _repository;

        public UnarchiveCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UnarchiveCategoryCommand command)
        {
            var category = await _repository.GetByIdAsync(command.Id);
            if (category == null) return;

            // Profesyonel tercih: geri alınca Active
            category.CategoryStatus = CategoryStatus.Active;

            await _repository.UpdateAsync(category);
        }
    }
}