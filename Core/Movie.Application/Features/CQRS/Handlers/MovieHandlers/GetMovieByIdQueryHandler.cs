using AutoMapper;
using Movie.Application.Features.CQRS.Queries.MovieQueries;
using Movie.Application.Features.CQRS.Results.MovieResults;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;

namespace Movie.Application.Features.CQRS.Handlers.MovieHandlers
{
    public class GetMovieByIdQueryHandler
    {
        private readonly IRepository<Film> _repository;
        private readonly IMapper _mapper;

        public GetMovieByIdQueryHandler(IRepository<Film> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetMovieByIdQueryResult> Handle(GetMovieByIdQuery query)
        {
            var movie = await _repository.GetByIdAsync(query.FilmId);
            return _mapper.Map<GetMovieByIdQueryResult>(movie);
        }
    }
}