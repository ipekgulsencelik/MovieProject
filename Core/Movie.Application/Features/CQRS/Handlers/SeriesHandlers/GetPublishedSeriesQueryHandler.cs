using AutoMapper;
using Movie.Application.Features.CQRS.Results.SeriesResults;
using Movie.Application.Interfaces;

namespace Movie.Application.Features.CQRS.Handlers.SeriesHandlers
{
    public class GetPublishedSeriesQueryHandler
    {
        private readonly ISeriesRepository _repository;
        private readonly IMapper _mapper;

        public GetPublishedSeriesQueryHandler(ISeriesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetSeriesQueryResult>> Handle()
        {
            var list = await _repository.GetPublished();
            return _mapper.Map<List<GetSeriesQueryResult>>(list);
        }
    }
}