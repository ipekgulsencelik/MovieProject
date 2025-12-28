using AutoMapper;
using Movie.Application.Features.CQRS.Queries.SeriesQueries;
using Movie.Application.Features.CQRS.Results.SeriesResults;
using Movie.Application.Interfaces;

namespace Movie.Application.Features.CQRS.Handlers.SeriesHandlers
{
    public class GetSeriesByIdQueryHandler
    {
        private readonly ISeriesRepository _seriesRepository;
        private readonly IMapper _mapper;

        public GetSeriesByIdQueryHandler(ISeriesRepository seriesRepository, IMapper mapper)
        {
            _seriesRepository = seriesRepository;
            _mapper = mapper;
        }

        public async Task<GetSeriesByIdQueryResult> Handle(GetSeriesByIdQuery query)
        {
            var series = await _seriesRepository.GetByIdWithCategories(query.SeriesId);
            if (series == null)
                throw new KeyNotFoundException("Dizi bulunamadı.");

            return _mapper.Map<GetSeriesByIdQueryResult>(series);
        }
    }
}