using Movie.Application.Features.CQRS.Commands.CategoryCommands;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;

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
            await _repository.DeleteAsync(command.CategoryID);
        }
    }
}