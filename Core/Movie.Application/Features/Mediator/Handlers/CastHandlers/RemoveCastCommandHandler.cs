using MediatR;
using Movie.Application.Features.Mediator.Commands.CastCommands;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;

namespace Movie.Application.Features.Mediator.Handlers.CastHandlers
{
    public class RemoveCastCommandHandler : IRequestHandler<RemoveCastCommand>
    {
        private readonly IRepository<Cast> _repository;

        public RemoveCastCommandHandler(IRepository<Cast> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveCastCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.CastId);
        }
    }
}