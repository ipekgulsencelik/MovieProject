using Azure.Core;
using Movie.Application.Features.CQRS.Commands.MovieCommands;
using Movie.Domain.Entities;
using Movie.Persistence.Context;

namespace Movie.Application.Features.CQRS.Handlers.MovieHandlers
{
    public class RemoveMovieCommandHandler
    {
        private readonly MovieContext _context;

        public RemoveMovieCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task Handle(RemoveMovieCommand command)
        {
            var film = await _context.Films.FindAsync(command.FilmID);

            if (film == null)
                throw new KeyNotFoundException($"Film with ID {command.FilmID} not found.");

            _context.Films.Remove(film);
            await _context.SaveChangesAsync();
        }
    }
}