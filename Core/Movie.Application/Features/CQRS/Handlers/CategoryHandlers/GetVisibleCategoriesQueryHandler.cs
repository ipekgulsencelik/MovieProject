using AutoMapper;
using Movie.Application.Features.CQRS.Results.CategoryResults;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;

namespace Movie.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetVisibleCategoriesQueryHandler
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public GetVisibleCategoriesQueryHandler(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetVisibleCategoriesQueryResult>> Handle()
        {
            var categories = await _repository.GetVisibleAsync();
            return _mapper.Map<List<GetVisibleCategoriesQueryResult>>(categories);
        }
    }
}