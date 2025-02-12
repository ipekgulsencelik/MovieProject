using Movie.Application.Features.CQRS.Commands.CategoryCommands;
using Movie.Application.Interfaces;

namespace Movie.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class ShowCategoryCommandHandler
    {
        private readonly ICategoryRepository _repository;

        public ShowCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(ShowCategoryCommand command)
        {
            await _repository.ShowCategoryAsync(command.CategoryID);
        }
    }
}