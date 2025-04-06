using MediatR;
using Movie.Application.Features.Mediator.Commands.TagCommands;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;

namespace Movie.Application.Features.Mediator.Handlers.TagHandlers
{
    public class HideTagCommandHandler : IRequestHandler<HideTagCommand>
    {
        private readonly IRepository<Tag> _repository;

        public HideTagCommandHandler(IRepository<Tag> repository)
        {
            _repository = repository;
        }

        public async Task Handle(HideTagCommand request, CancellationToken cancellationToken)
        {
            await _repository.HideAsync(request.TagId);
        }
    }
}