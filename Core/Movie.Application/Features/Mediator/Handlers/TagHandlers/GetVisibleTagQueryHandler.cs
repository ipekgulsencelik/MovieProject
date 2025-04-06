using AutoMapper;
using MediatR;
using Movie.Application.Features.Mediator.Queries.TagQueries;
using Movie.Application.Features.Mediator.Results.TagResults;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;

namespace Movie.Application.Features.Mediator.Handlers.TagHandlers
{
    public class GetVisibleTagQueryHandler : IRequestHandler<GetVisibleTagQuery, List<GetVisibleTagsQueryResult>>
    {
        private readonly IRepository<Tag> _repository;
        private readonly IMapper _mapper;

        public GetVisibleTagQueryHandler(IRepository<Tag> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetVisibleTagsQueryResult>> Handle(GetVisibleTagQuery request, CancellationToken cancellationToken)
        {
            var casts = await _repository.GetVisibleAsync();
            return _mapper.Map<List<GetVisibleTagsQueryResult>>(casts);
        }
    }
}