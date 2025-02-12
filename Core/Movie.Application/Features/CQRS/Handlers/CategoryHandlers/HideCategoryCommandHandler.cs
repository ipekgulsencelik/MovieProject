using Movie.Application.Features.CQRS.Commands.CategoryCommands;
using Movie.Application.Interfaces;

namespace Movie.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class HideCategoryCommandHandler
    {
        private readonly ICategoryRepository _repository;

        public HideCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(HideCategoryCommand command)
        {
            await _repository.HideCategoryAsync(command.CategoryID);
        }
    }
}