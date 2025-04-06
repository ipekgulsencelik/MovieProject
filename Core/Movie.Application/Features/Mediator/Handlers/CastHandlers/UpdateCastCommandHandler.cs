using AutoMapper;
using MediatR;
using Movie.Application.Features.Mediator.Commands.CastCommands;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;

namespace Movie.Application.Features.Mediator.Handlers.CastHandlers
{
    public class UpdateCastCommandHandler : IRequestHandler<UpdateCastCommand>
    {
        private readonly IRepository<Cast> _repository;
        private readonly IMapper _mapper;

        public UpdateCastCommandHandler(IRepository<Cast> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateCastCommand request, CancellationToken cancellationToken)
        {
            var cast = _mapper.Map<Cast>(request);
            await _repository.UpdateAsync(cast);
        }
    }
}