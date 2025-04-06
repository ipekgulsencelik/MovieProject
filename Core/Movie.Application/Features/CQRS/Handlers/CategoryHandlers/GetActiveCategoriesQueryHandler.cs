using AutoMapper;
using Movie.Application.Features.CQRS.Results.CategoryResults;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;

namespace Movie.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetActiveCategoriesQueryHandler
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public GetActiveCategoriesQueryHandler(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetActiveCategoriesQueryResult>> Handle()
        {
            var categories = await _repository.GetActiveAsync();
            return _mapper.Map<List<GetActiveCategoriesQueryResult>>(categories);
        }
    }
}