using Movie.Application.Features.CQRS.Commands;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;
using Movie.Domain.Entities.Enum;

namespace Movie.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class SoftDeleteCategoryCommandHandler
    {
        private readonly IRepository<Category> _repository;

        public SoftDeleteCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task Handle(SoftDeleteCategoryCommand command)
        {
            var category = await _repository.GetByIdAsync(command.Id);

            // 🔒 İş kuralı: Arşivdeki kategori çöp kutusuna taşınamaz
            if (category.CategoryStatus == CategoryStatus.Archived)
                throw new InvalidOperationException(
                    "Arşivdeki bir kategori çöp kutusuna taşınamaz. Önce arşivden çıkarılmalıdır.");

            await _repository.DeleteAsync(command.Id);
        }
    }
}