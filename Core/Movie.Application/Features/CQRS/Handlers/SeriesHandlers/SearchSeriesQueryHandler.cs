using AutoMapper;
using Movie.Application.Features.CQRS.Queries.SeriesQueries;
using Movie.Application.Features.CQRS.Results.SeriesResults;
using Movie.Application.Interfaces;

namespace Movie.Application.Features.CQRS.Handlers.SeriesHandlers
{
    public class SearchSeriesQueryHandler
    {
        private readonly ISeriesRepository _repository;
        private readonly IMapper _mapper;

        public SearchSeriesQueryHandler(ISeriesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<SearchSeriesQueryResult>> Handle(SearchSeriesQuery query)
        {
            var list = await _repository.SearchAsync(query.Q, query.Status, query.MinRating, query.MaxRating, query.FromFirstAirDate, query.ToFirstAirDate, query.Page, query.PageSize
            );

            return _mapper.Map<List<SearchSeriesQueryResult>>(list);
        }
    }
}