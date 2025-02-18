using AutoMapper;
using Movie.Application.Features.CQRS.Results.MovieResults;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;

namespace Movie.Application.Features.CQRS.Handlers.MovieHandlers
{
    public class GetMovieQueryHandler
    {
        private readonly IRepository<Film> _repository;
        private readonly IMapper _mapper;

        public GetMovieQueryHandler(IRepository<Film> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetMovieQueryResult>> Handle()
        {
            var movies = await _repository.GetListAsync();
            return _mapper.Map<List<GetMovieQueryResult>>(movies);
        }
    }
}