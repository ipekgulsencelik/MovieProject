using AutoMapper;
using MediatR;
using Movie.Application.Features.Mediator.Queries.CastQueries;
using Movie.Application.Features.Mediator.Results.CastResults;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;

namespace Movie.Application.Features.Mediator.Handlers.CastHandlers
{
    public class GetVisibleCastQueryHandler : IRequestHandler<GetVisibleCastQuery, List<GetVisibleCastsQueryResult>>
    {
        private readonly IRepository<Cast> _repository;
        private readonly IMapper _mapper;

        public GetVisibleCastQueryHandler(IRepository<Cast> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetVisibleCastsQueryResult>> Handle(GetVisibleCastQuery request, CancellationToken cancellationToken)
        {
            var casts = await _repository.GetVisibleAsync();
            return _mapper.Map<List<GetVisibleCastsQueryResult>>(casts);
        }
    }
}