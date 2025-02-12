using Microsoft.EntityFrameworkCore;
using Movie.Application.Features.CQRS.Commands.MovieCommands;
using Movie.Persistence.Context;

namespace Movie.Application.Features.CQRS.Handlers.MovieHandlers
{
    public class HideMovieCommandHandler
    {
        private readonly MovieContext _context;

        public HideMovieCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(HideMovieCommand command)
        {
            var film = await _context.Films.FindAsync(command.FilmID);

            if (film == null)
                throw new KeyNotFoundException($"Film with ID {command.FilmID} not found.");

            if (film.IsActive == false)
                return false;

            var updatedRows = await _context.Films.Where(f => f.FilmID == command.FilmID && f.IsActive).ExecuteUpdateAsync(setters => setters.SetProperty(f => f.IsVisible, false));

            return updatedRows > 0;
        }
    }
}