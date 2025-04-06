using AutoMapper;
using MediatR;
using Movie.Application.Features.Mediator.Queries.TagQueries;
using Movie.Application.Features.Mediator.Results.TagResults;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;

namespace Movie.Application.Features.Mediator.Handlers.TagHandlers
{
    public class GetByIdTagQueryHandler : IRequestHandler<GetTagByIdQuery, GetTagByIdQueryResult>
    {
        private readonly IRepository<Tag> _repository;
        private readonly IMapper _mapper;

        public GetByIdTagQueryHandler(IRepository<Tag> repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<GetTagByIdQueryResult> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
        {
            var tag = await _repository.GetByIdAsync(request.TagId);
            return _mapper.Map<GetTagByIdQueryResult>(tag);
        }
    }
}