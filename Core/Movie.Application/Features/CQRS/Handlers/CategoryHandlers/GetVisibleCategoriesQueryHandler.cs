using AutoMapper;
using Movie.Application.Features.CQRS.Results.CategoryResults;
using Movie.Application.Interfaces;

namespace Movie.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetVisibleCategoriesQueryHandler
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public GetVisibleCategoriesQueryHandler(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetVisibleCategoriesQueryResult>> Handle()
        {
            var categories = await _repository.GetVisibleCategoriesAsync();
            return _mapper.Map<List<GetVisibleCategoriesQueryResult>>(categories);
        }
    }
}