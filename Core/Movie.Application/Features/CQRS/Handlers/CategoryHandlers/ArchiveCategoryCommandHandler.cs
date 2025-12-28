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

            // Zaten arşivliyse işlem yapma
            if (category.CategoryStatus == CategoryStatus.Archived)
                return;

            // 🔥 Önceki durumu sakla
            category.PreviousStatus ??= category.CategoryStatus;

            // 🔥 Arşivle
            category.CategoryStatus = CategoryStatus.Archived;

            // 🔒 Yayından kaldır
            category.IsActive = false;
            category.IsVisible = false;

            await _repository.UpdateAsync(category);
        }
    }
}