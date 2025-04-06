using Movie.Application.Features.CQRS.Commands.CategoryCommands;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;

namespace Movie.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class HideCategoryCommandHandler
    {
        private readonly IRepository<Category> _repository;

        public HideCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task Handle(HideCategoryCommand command)
        {
            await _repository.HideAsync(command.CategoryID);
        }
    }
}