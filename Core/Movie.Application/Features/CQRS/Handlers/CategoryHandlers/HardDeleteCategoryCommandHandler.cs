using Movie.Application.Features.CQRS.Commands.CategoryCommands;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;
using Movie.Domain.Entities.Enum;

namespace Movie.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class HardDeleteCategoryCommandHandler
    {
        private readonly IRepository<Category> _repository;

        public HardDeleteCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task Handle(HardDeleteCategoryCommand command)
        {
            var category = await _repository.GetByIdIncludingDeletedAsync(command.Id);
            if (category == null)
                throw new KeyNotFoundException($"Category with ID {command.Id} was not found.");

            // 🔒 Profesyonel kural: Kalıcı silme sadece Deleted veya Archived iken
            if (category.DataStatus != DataStatus.Deleted && category.CategoryStatus != CategoryStatus.Archived)
                throw new InvalidOperationException("Kalıcı silmeden önce kategori silinmiş (Deleted) ya da arşivlenmiş (Archived) olmalı.");

            await _repository.RemoveAsync(category);
        }
    }
}