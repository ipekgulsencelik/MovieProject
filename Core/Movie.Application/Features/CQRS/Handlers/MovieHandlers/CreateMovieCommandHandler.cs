using Movie.Application.Features.CQRS.Commands.MovieCommands;
using Movie.Domain.Entities;
using Movie.Persistence.Context;

namespace Movie.Application.Features.CQRS.Handlers.MovieHandlers
{
    public class CreateMovieCommandHandler
    {
        private readonly MovieContext _context;

        public CreateMovieCommandHandler(MovieContext context)
        {
            _context = context;
        }
        
        public async Task Handle(CreateMovieCommand command)
        {
            var film = new Film
            {
                Title = command.Title,
                CoverImageUrl = command.CoverImageUrl,
                Rating = command.Rating,
                Description = command.Description,
                Duration = command.Duration,
                ReleaseDate = command.ReleaseDate,
                IsVisible = command.IsVisible,
                IsActive = command.IsActive
            };

            _context.Films.Add(film);
            await _context.SaveChangesAsync();
        }
    }
}