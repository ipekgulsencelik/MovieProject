using AutoMapper;
using MediatR;
using Movie.Application.Features.Mediator.Queries.TagQueries;
using Movie.Application.Features.Mediator.Results.TagResults;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;

namespace Movie.Application.Features.Mediator.Handlers.TagHandlers
{
    public class GetActiveTagsQueryHandler : IRequestHandler<GetActiveTagQuery, List<GetActiveTagsQueryResult>>
    {
        private readonly IRepository<Tag> _repository;
        private readonly IMapper _mapper;

        public GetActiveTagsQueryHandler(IRepository<Tag> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetActiveTagsQueryResult>> Handle(GetActiveTagQuery request, CancellationToken cancellationToken)
        {
            var casts = await _repository.GetActiveAsync();
            return _mapper.Map<List<GetActiveTagsQueryResult>>(casts);
        }
    }
}