using AutoMapper;
using Movie.Application.Features.CQRS.Commands.CategoryCommands;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;

namespace Movie.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class CreateCategoryCommandHandler
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateCategoryCommand command)
        {
            var category = _mapper.Map<Category>(command);
            await _repository.CreateAsync(category);
        }
    }
}