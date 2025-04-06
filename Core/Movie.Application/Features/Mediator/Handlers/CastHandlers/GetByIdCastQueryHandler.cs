using AutoMapper;
using MediatR;
using Movie.Application.Features.Mediator.Queries.CastQueries;
using Movie.Application.Features.Mediator.Results.CastResults;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;

namespace Movie.Application.Features.Mediator.Handlers.CastHandlers
{
    public class GetByIdCastQueryHandler : IRequestHandler<GetCastByIdQuery, GetCastByIdQueryResult>
    {
        private readonly IRepository<Cast> _repository;
        private readonly IMapper _mapper;

        public GetByIdCastQueryHandler(IRepository<Cast> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetCastByIdQueryResult> Handle(GetCastByIdQuery request, CancellationToken cancellationToken)
        {
            var cast = await _repository.GetByIdAsync(request.CastId);
            return _mapper.Map<GetCastByIdQueryResult>(cast);
        }
    }
}