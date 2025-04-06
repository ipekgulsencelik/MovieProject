using MediatR;
using Movie.Application.Features.Mediator.Commands.TagCommands;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;

namespace Movie.Application.Features.Mediator.Handlers.TagHandlers
{
    public class RemoveTagCommandHandler : IRequestHandler<RemoveTagCommand>
    {
        private readonly IRepository<Tag> _repository;

        public RemoveTagCommandHandler(IRepository<Tag> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveTagCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.TagId);
        }
    }
}