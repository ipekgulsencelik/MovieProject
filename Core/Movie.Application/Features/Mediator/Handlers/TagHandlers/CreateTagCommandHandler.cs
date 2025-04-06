using AutoMapper;
using MediatR;
using Movie.Application.Features.Mediator.Commands.TagCommands;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;

namespace Movie.Application.Features.Mediator.Handlers.TagHandlers
{
    public class CreateTagCommandHandler : IRequestHandler<CreateTagCommand>
    {
        private readonly IRepository<Tag> _repository;
        private readonly IMapper _mapper;

        public CreateTagCommandHandler(IRepository<Tag> repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task Handle(CreateTagCommand request, CancellationToken cancellationToken)
        {
            var tag = _mapper.Map<Tag>(request);
            await _repository.CreateAsync(tag);
        }
    }
}