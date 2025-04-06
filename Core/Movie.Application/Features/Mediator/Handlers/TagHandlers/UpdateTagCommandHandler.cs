using AutoMapper;
using MediatR;
using Movie.Application.Features.Mediator.Commands.TagCommands;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;

namespace Movie.Application.Features.Mediator.Handlers.TagHandlers
{
    public class UpdateTagCommandHandler : IRequestHandler<UpdateTagCommand>
    {
        private readonly IRepository<Tag> _repository;
        private readonly IMapper _mapper;

        public UpdateTagCommandHandler(IRepository<Tag> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateTagCommand request, CancellationToken cancellationToken)
        {
            var tag = _mapper.Map<Tag>(request);
            await _repository.UpdateAsync(tag);
        }
    }
}