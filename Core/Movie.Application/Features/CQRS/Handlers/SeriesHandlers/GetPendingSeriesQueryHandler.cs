using AutoMapper;
using Movie.Application.Features.CQRS.Results.SeriesResults;
using Movie.Application.Interfaces;

namespace Movie.Application.Features.CQRS.Handlers.SeriesHandlers
{
    public class GetPendingSeriesQueryHandler
    {
        private readonly ISeriesRepository _repository;
        private readonly IMapper _mapper;

        public GetPendingSeriesQueryHandler(ISeriesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetPendingSeriesQueryResult>> Handle()
        {
            var list = await _repository.GetPending();
            return _mapper.Map<List<GetPendingSeriesQueryResult>>(list);
        }
    }
}