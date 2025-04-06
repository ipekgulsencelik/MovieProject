using Movie.Application.Features.CQRS.Commands.CategoryCommands;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;

namespace Movie.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class ToggleCategoryStatusCommandHandler
    {
        private readonly IRepository<Category> _repository;

        public ToggleCategoryStatusCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task Handle(ToggleCategoryStatusCommand command)
        {
            await _repository.ToggleStatusAsync(command.CategoryID);
        }
    }
}