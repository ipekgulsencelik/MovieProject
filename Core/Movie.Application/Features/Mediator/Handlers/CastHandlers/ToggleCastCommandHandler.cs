using MediatR;
using Movie.Application.Features.Mediator.Commands.CastCommands;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;

namespace Movie.Application.Features.Mediator.Handlers.CastHandlers
{
    public class ToggleCastCommandHandler : IRequestHandler<ToggleCastStatusCommand>
    {
        private readonly IRepository<Cast> _repository;

        public ToggleCastCommandHandler(IRepository<Cast> repository)
        {
            _repository = repository;
        }

        public async Task Handle(ToggleCastStatusCommand request, CancellationToken cancellationToken)
        {
            await _repository.ToggleStatusAsync(request.CastId);
        }
    }
}