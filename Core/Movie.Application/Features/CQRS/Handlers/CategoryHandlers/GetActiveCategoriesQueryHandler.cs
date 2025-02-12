using AutoMapper;
using Movie.Application.Features.CQRS.Results.CategoryResults;
using Movie.Application.Interfaces;

namespace Movie.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetActiveCategoriesQueryHandler
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public GetActiveCategoriesQueryHandler(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetActiveCategoriesQueryResult>> Handle()
        {
            var categories = await _repository.GetActiveCategoriesAsync();
            return _mapper.Map<List<GetActiveCategoriesQueryResult>>(categories);
        }
    }
}