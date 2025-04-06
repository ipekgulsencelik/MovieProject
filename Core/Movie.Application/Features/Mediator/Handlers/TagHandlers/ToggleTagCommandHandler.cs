using MediatR;
using Movie.Application.Features.Mediator.Commands.TagCommands;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;

namespace Movie.Application.Features.Mediator.Handlers.TagHandlers
{
    public class ToggleTagCommandHandler : IRequestHandler<ToggleTagStatusCommand>
    {
        private readonly IRepository<Tag> _repository;

        public ToggleTagCommandHandler(IRepository<Tag> repository)
        {
            _repository = repository;
        }

        public async Task Handle(ToggleTagStatusCommand request, CancellationToken cancellationToken)
        {
            await _repository.ToggleStatusAsync(request.TagId);
        }
    }
}