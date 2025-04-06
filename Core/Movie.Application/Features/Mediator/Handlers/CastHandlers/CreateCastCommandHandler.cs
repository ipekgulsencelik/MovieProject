using AutoMapper;
using MediatR;
using Movie.Application.Features.Mediator.Commands.CastCommands;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;

namespace Movie.Application.Features.Mediator.Handlers.CastHandlers
{
    public class CreateCastCommandHandler : IRequestHandler<CreateCastCommand>
    {
        private readonly IRepository<Cast> _repository;
        private readonly IMapper _mapper;

        public CreateCastCommandHandler(IRepository<Cast> repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task Handle(CreateCastCommand request, CancellationToken cancellationToken)
        {
            var cast = _mapper.Map<Cast>(request);
            await _repository.CreateAsync(cast);
        }
    }
}