using Movie.Application.Features.CQRS.Commands.CategoryCommands;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;
using Movie.Domain.Entities.Enum;

namespace Movie.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class RejectCategoryCommandHandler
    {
        private readonly IRepository<Category> _repository;

        public RejectCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RejectCategoryCommand command)
        {
            var category = await _repository.GetByIdAsync(command.Id);

            // ✅ Sadece Pending reddedilir
            if (category.CategoryStatus != CategoryStatus.Pending)
                throw new InvalidOperationException("Sadece Pending kategoriler reddedilebilir.");

            // ✅ Pending -> Passive
            category.CategoryStatus = CategoryStatus.Passive;

            // ✅ Yayından kaldır
            category.IsActive = false;
            category.IsVisible = false;

            // ✅ Pending'den çıkınca previous temiz
            category.PreviousStatus = null;

            await _repository.UpdateAsync(category);
        }
    }
}