using Movie.Application.Features.CQRS.Commands.CategoryCommands;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;

namespace Movie.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class ShowCategoryCommandHandler
    {
        private readonly IRepository<Category> _repository;

        public ShowCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task Handle(ShowCategoryCommand command)
        {
            await _repository.ShowAsync(command.CategoryID);
        }
    }
}