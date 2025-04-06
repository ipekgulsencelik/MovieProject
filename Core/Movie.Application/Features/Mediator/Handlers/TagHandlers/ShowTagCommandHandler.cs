using MediatR;
using Movie.Application.Features.Mediator.Commands.TagCommands;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;

namespace Movie.Application.Features.Mediator.Handlers.TagHandlers
{
    public class ShowTagCommandHandler : IRequestHandler<ShowTagCommand>
    {
        private readonly IRepository<Tag> _repository;

        public ShowTagCommandHandler(IRepository<Tag> repository)
        {
            _repository = repository;
        }

        public async Task Handle(ShowTagCommand request, CancellationToken cancellationToken)
        {
            await _repository.ShowAsync(request.TagId);
        }
    }
}