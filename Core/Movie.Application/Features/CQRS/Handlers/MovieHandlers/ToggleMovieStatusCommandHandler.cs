using Microsoft.EntityFrameworkCore;
using Movie.Application.Features.CQRS.Commands.MovieCommands;
using Movie.Persistence.Context;

namespace Movie.Application.Features.CQRS.Handlers.MovieHandlers
{
    public class ToggleMovieStatusCommandHandler
    {
        private readonly MovieContext _context;

        public ToggleMovieStatusCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task Handle(ToggleMovieStatusCommand command)
        {
            var film = await _context.Films.FindAsync(command.FilmID);

            if (film == null)
                throw new KeyNotFoundException($"Film with ID {command.FilmID} not found.");

            var newStatus = !film.IsActive;

            await _context.Films.Where(f => f.FilmID == command.FilmID).ExecuteUpdateAsync(setters => setters.SetProperty(f => f.IsActive, newStatus));
        }
    }
}