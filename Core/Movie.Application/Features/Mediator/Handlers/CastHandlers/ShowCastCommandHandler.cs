using MediatR;
using Movie.Application.Features.Mediator.Commands.CastCommands;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;

namespace Movie.Application.Features.Mediator.Handlers.CastHandlers
{
    public class ShowCastCommandHandler : IRequestHandler<ShowCastCommand>
    {
        private readonly IRepository<Cast> _repository;

        public ShowCastCommandHandler(IRepository<Cast> repository)
        {
            _repository = repository;
        }

        public async Task Handle(ShowCastCommand request, CancellationToken cancellationToken)
        {
            await _repository.ShowAsync(request.CastId);
        }
    }
}