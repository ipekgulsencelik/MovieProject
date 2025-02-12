using Microsoft.EntityFrameworkCore;
using Movie.Application.Features.CQRS.Results.MovieResults;
using Movie.Persistence.Context;

namespace Movie.Application.Features.CQRS.Handlers.MovieHandlers
{
    public class GetVisibleMoviesQueryHandler
    {
        private readonly MovieContext _context;

        public GetVisibleMoviesQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<List<GetVisibleMoviesQueryResult>> Handle()
        {
            var movies = await _context.Films.Where(f => f.IsActive && f.IsVisible).ToListAsync();

            return movies.Select(x => new GetVisibleMoviesQueryResult
            {
                FilmID = x.FilmID,
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