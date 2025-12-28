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

            // Sadece Archived olan geri alınsın
            if (category.CategoryStatus != CategoryStatus.Archived)
                return;

            // 🔥 PreviousStatus varsa ona dön, yoksa Active fallback
            var targetStatus = category.PreviousStatus ?? CategoryStatus.Active;

            // ❌ Pending'e dönmeyi engelle -> Active'e düş
            if (targetStatus == CategoryStatus.Pending)
                targetStatus = CategoryStatus.Active;

            category.CategoryStatus = targetStatus;
            category.PreviousStatus = null;

            // ✅ BaseEntity uyumu
            if (targetStatus == CategoryStatus.Active)
            {
                category.IsActive = true;
                category.IsVisible = true;
            }
            else // Passive (veya olası diğer durumlar)
            {
                category.IsActive = false;
                category.IsVisible = false;
            }

            await _repository.UpdateAsync(category);
        }
    }
}