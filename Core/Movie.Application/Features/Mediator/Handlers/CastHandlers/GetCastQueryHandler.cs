using AutoMapper;
using MediatR;
using Movie.Application.Features.Mediator.Queries.CastQueries;
using Movie.Application.Features.Mediator.Results.CastResults;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;

namespace Movie.Application.Features.Mediator.Handlers.CastHandlers
{
    public class GetCastQueryHandler : IRequestHandler<GetCastQuery, List<GetCastQueryResult>>
    {
        private readonly IRepository<Cast> _repository;
        private readonly IMapper _mapper;

        public GetCastQueryHandler(IRepository<Cast> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetCastQueryResult>> Handle(GetCastQuery request, CancellationToken cancellationToken)
        {
            var casts = await _repository.GetListAsync();
            return _mapper.Map<List<GetCastQueryResult>>(casts);
        }
    }
}