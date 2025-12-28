using AutoMapper;
using Movie.Application.Features.CQRS.Results.SeriesResults;
using Movie.Application.Interfaces;

namespace Movie.Application.Features.CQRS.Handlers.SeriesHandlers
{
    public class GetArchivedSeriesQueryHandler
    {
        private readonly ISeriesRepository _repository;
        private readonly IMapper _mapper;

        public GetArchivedSeriesQueryHandler(ISeriesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetArchivedSeriesQueryResult>> Handle()
        {
            var list = await _repository.GetPending();
            return _mapper.Map<List<GetArchivedSeriesQueryResult>>(list);
        }
    }
}