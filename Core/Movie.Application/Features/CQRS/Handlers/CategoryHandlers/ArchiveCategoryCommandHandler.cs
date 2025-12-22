using Movie.Application.Features.CQRS.Commands.CategoryCommands;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;
using Movie.Domain.Entities.Enum;

namespace Movie.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class ArchiveCategoryCommandHandler
    {
        private readonly IRepository<Category> _repository;

        public ArchiveCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task Handle(ArchiveCategoryCommand command)
        {
            var category = await _repository.GetByIdAsync(command.Id);
            if (category == null) return;

            // ✅ Soft delete
            category.CategoryStatus = CategoryStatus.Archived;

            await _repository.UpdateAsync(category);
        }
    }
}