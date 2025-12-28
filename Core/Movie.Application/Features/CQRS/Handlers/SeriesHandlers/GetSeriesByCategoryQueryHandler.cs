using AutoMapper;
using Movie.Application.Features.CQRS.Queries.SeriesQueries;
using Movie.Application.Features.CQRS.Results.SeriesResults;
using Movie.Application.Interfaces;

namespace Movie.Application.Features.CQRS.Handlers.SeriesHandlers
{
    public class GetSeriesByCategoryQueryHandler
    {
        private readonly ISeriesRepository _repository;
        private readonly IMapper _mapper;

        public GetSeriesByCategoryQueryHandler(ISeriesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetSeriesByCategoryQueryResult>> Handle(GetSeriesByCategoryQuery query)
        {
            if (query.CategoryId <= 0)
                throw new ArgumentException("Geçersiz CategoryId.");

            var list = await _repository.GetSeriesByCategory(query.CategoryId, query.Page, query.PageSize);

            return _mapper.Map<List<GetSeriesByCategoryQueryResult>>(list);
        }
    }
}