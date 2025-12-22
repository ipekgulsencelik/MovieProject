using Movie.Application.Features.CQRS.Commands.CategoryCommands;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;
using Movie.Domain.Entities.Enum;

namespace Movie.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class RemoveCategoryCommandHandler
    {
        private readonly IRepository<Category> _repository;

        public RemoveCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveCategoryCommand command)
        {
            var category = await _repository.GetByIdAsync(command.CategoryID);
            if (category == null) return;

            // ❗ Profesyonel kural
            if (category.CategoryStatus != CategoryStatus.Archived)
            {
                // ister throw, ister silent return
                throw new InvalidOperationException(
                    "Kategori kalıcı silinmeden önce arşivlenmelidir.");
            }

            await _repository.RemoveAsync(category);
        }
    }
}