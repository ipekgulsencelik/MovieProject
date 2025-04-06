using AutoMapper;
using MediatR;
using Movie.Application.Features.Mediator.Queries.TagQueries;
using Movie.Application.Features.Mediator.Results.TagResults;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;

namespace Movie.Application.Features.Mediator.Handlers.TagHandlers
{
    public class GetTagQueryHandler : IRequestHandler<GetTagQuery, List<GetTagQueryResult>>
    {
        private readonly IRepository<Tag> _repository;
        private readonly IMapper _mapper;

        public GetTagQueryHandler(IRepository<Tag> repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<GetTagQueryResult>> Handle(GetTagQuery request, CancellationToken cancellationToken)
        {
            var tags = await _repository.GetListAsync();
            return _mapper.Map<List<GetTagQueryResult>>(tags);
        }
    }
}