using Movie.Application.Features.CQRS.Commands.CategoryCommands;
using Movie.Application.Interfaces;

namespace Movie.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class ToggleCategoryStatusCommandHandler
    {
        private readonly ICategoryRepository _repository;

        public ToggleCategoryStatusCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(ToggleCategoryStatusCommand command)
        {
            await _repository.ToggleCategoryStatusAsync(command.CategoryID);
        }
    }
}