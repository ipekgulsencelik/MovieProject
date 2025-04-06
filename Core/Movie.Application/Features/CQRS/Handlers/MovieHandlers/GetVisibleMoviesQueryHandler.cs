using Movie.Application.Features.CQRS.Results.MovieResults;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;

namespace Movie.Application.Features.CQRS.Handlers.MovieHandlers
{
    public class GetVisibleMoviesQueryHandler
    {
        private readonly IRepository<Film> _repository;

        public GetVisibleMoviesQueryHandler(IRepository<Film> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetVisibleMoviesQueryResult>> Handle()
        {
            var movies = await _repository.GetListByFilterAsync(f => f.IsActive && f.IsVisible);

            return movies.Select(x => new GetVisibleMoviesQueryResult
            {
                FilmID = x.Id,
                Title = x.Title,
                CoverImageUrl = x.CoverImageUrl,
                Rating = x.Rating,
                Description = x.Description,
                Duration = x.Duration,
                ReleaseDate = x.ReleaseDate,
                IsActive = x.IsActive,
                IsVisible = x.IsVisible
            }).ToList();
        }
    }
}