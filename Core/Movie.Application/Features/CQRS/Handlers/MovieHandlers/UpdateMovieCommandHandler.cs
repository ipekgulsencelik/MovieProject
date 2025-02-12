using Movie.Application.Features.CQRS.Commands.MovieCommands;
using Movie.Persistence.Context;

namespace Movie.Application.Features.CQRS.Handlers.MovieHandlers
{
    public class UpdateMovieCommandHandler
    {
        private readonly MovieContext _context;

        public UpdateMovieCommandHandler(MovieContext context)
        {
            _context = context;
        }
        
        public async Task Handler(UpdateMovieCommand command)
        {
            var value = await _context.Films.FindAsync(command.FilmID);

            if (value == null)
            {
                throw new KeyNotFoundException($"Movie with ID {command.FilmID} not found.");
            }

            value.Title = command.Title;
            value.CoverImageUrl = command.CoverImageUrl;
            value.Rating = command.Rating;
            value.Description = command.Description;
            value.Duration = command.Duration;
            value.ReleaseDate = command.ReleaseDate;
            value.IsActive = command.IsActive;
            value.IsVisible = command.IsVisible;

            await _context.SaveChangesAsync();
        }
    }
}