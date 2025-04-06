using AutoMapper;
using MediatR;
using Movie.Application.Features.Mediator.Queries.CastQueries;
using Movie.Application.Features.Mediator.Results.CastResults;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;

namespace Movie.Application.Features.Mediator.Handlers.CastHandlers
{
    public class GetActiveCastQueryHandler : IRequestHandler<GetActiveCastQuery, List<GetActiveCastsQueryResult>>
    {
        private readonly IRepository<Cast> _repository;
        private readonly IMapper _mapper;

        public GetActiveCastQueryHandler(IRepository<Cast> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetActiveCastsQueryResult>> Handle(GetActiveCastQuery request, CancellationToken cancellationToken)
        {
            var casts = await _repository.GetActiveAsync();
            return _mapper.Map<List<GetActiveCastsQueryResult>>(casts);
        }
    }
}