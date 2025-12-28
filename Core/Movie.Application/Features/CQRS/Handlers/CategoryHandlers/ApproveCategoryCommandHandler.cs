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

            // ✅ Sadece Pending onaylanır
            if (category.CategoryStatus != CategoryStatus.Pending)
                throw new InvalidOperationException("Sadece Onay Bekleyen (Pending) kategoriler onaylanabilir.");

            // ✅ Pending -> Active
            category.CategoryStatus = CategoryStatus.Active;

            // ✅ Onaylanan kategori yayına alınır
            category.IsActive = true;
            category.IsVisible = true;

            // ✅ Pending’den çıkınca previous temiz kalsın
            category.PreviousStatus = null;

            await _repository.UpdateAsync(category);
        }
    }
}