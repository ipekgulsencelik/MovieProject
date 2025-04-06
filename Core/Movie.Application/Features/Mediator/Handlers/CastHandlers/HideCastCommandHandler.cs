using MediatR;
using Movie.Application.Features.Mediator.Commands.CastCommands;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;

namespace Movie.Application.Features.Mediator.Handlers.CastHandlers
{
    public class HideCastCommandHandler : IRequestHandler<HideCastCommand>
    {
        private readonly IRepository<Cast> _repository;

        public HideCastCommandHandler(IRepository<Cast> repository)
        {
            _repository = repository;
        }

        public async Task Handle(HideCastCommand request, CancellationToken cancellationToken)
        {
            await _repository.HideAsync(request.CastId);
        }
    }
}