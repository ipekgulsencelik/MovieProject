using AutoMapper;
using Movie.Application.Features.CQRS.Results.SeriesResults;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;

namespace Movie.Application.Features.CQRS.Handlers.SeriesHandlers
{
    public class GetSeriesQueryHandler
    {
        private readonly IRepository<Series> _repository;
        private readonly IMapper _mapper;

        public GetSeriesQueryHandler(IRepository<Series> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetSeriesQueryResult>> Handle()
        {
            var seriesList = await _repository.GetListAsync();
            return _mapper.Map<List<GetSeriesQueryResult>>(seriesList);
        }
    }
}