using Movie.Application.Features.CQRS.Commands;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;
using Movie.Domain.Entities.Enum;

namespace Movie.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class UpdateCategoryStatusCommandHandler
    {
        private readonly IRepository<Category> _repository;

        public UpdateCategoryStatusCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCategoryStatusCommand command)
        {
            var category = await _repository.GetByIdAsync(command.Id);

            // ✅ Pending manuel seçilemesin (Pending sadece approve/reject ile değişsin)
            if (command.CategoryStatus == CategoryStatus.Pending)
                throw new InvalidOperationException("Pending durumu manuel seçilemez.");

            // ✅ Eğer zaten aynı durumdaysa boşuna yazma
            if (category.CategoryStatus == command.CategoryStatus)
                return;

            // 🔥 PreviousStatus kuralı:
            // - Arşive alınırken önceki durumu sakla
            // - Arşivden çıkarken previous varsa ona dön (Pending'e dönme yok)
            if (command.CategoryStatus == CategoryStatus.Archived)
            {
                category.PreviousStatus ??= category.CategoryStatus;

                category.CategoryStatus = CategoryStatus.Archived;
                category.IsActive = false;
                category.IsVisible = false;

                await _repository.UpdateAsync(category);
                return;
            }

            // ✅ Archived'dan çıkış: previous varsa ona dön, yoksa Active
            if (category.CategoryStatus == CategoryStatus.Archived)
            {
                var target = category.PreviousStatus ?? CategoryStatus.Active;

                // Pending'e dönüş istemiyoruz -> Active fallback
                if (target == CategoryStatus.Pending)
                    target = CategoryStatus.Active;

                category.CategoryStatus = target;
                category.PreviousStatus = null;

                if (target == CategoryStatus.Active)
                {
                    category.IsActive = true;
                    category.IsVisible = true;
                }
                else // Passive
                {
                    category.IsActive = false;
                    category.IsVisible = false;
                }

                await _repository.UpdateAsync(category);
                return;
            }

            // ✅ Normal geçişler (Active <-> Passive)
            category.CategoryStatus = command.CategoryStatus;
            category.PreviousStatus = null;

            if (command.CategoryStatus == CategoryStatus.Active)
            {
                category.IsActive = true;
                category.IsVisible = true;
            }
            else if (command.CategoryStatus == CategoryStatus.Passive)
            {
                category.IsActive = false;
                category.IsVisible = false;
            }

            await _repository.UpdateAsync(category);
        }
    }
}