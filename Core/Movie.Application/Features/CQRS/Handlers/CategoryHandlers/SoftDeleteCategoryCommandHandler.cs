using Movie.Application.Features.CQRS.Commands;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;

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
            // repo kendi içinde Deleted kontrolünü yapıyor
            await _repository.DeleteAsync(command.Id);
        }
    }
}