using AutoMapper;
using Movie.Application.Features.CQRS.Results.SeriesResults;
using Movie.Application.Interfaces;

namespace Movie.Application.Features.CQRS.Handlers.SeriesHandlers
{
    public class GetDeletedSeriesQueryHandler
    {
        private readonly ISeriesRepository _repository;
        private readonly IMapper _mapper;

        public GetDeletedSeriesQueryHandler(ISeriesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetDeletedSeriesQueryResult>> Handle()
        {
            // Deleted kayıtlar için global filter bypass edilmelidir
            var deletedSeries = await _repository.GetIncludingDeleted();

            return _mapper.Map<List<GetDeletedSeriesQueryResult>>(deletedSeries);
        }
    }
}