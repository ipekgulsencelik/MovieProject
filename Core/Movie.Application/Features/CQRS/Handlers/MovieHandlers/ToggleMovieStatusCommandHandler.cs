using Movie.Application.Features.CQRS.Commands.MovieCommands;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;

namespace Movie.Application.Features.CQRS.Handlers.MovieHandlers
{
    public class ToggleMovieStatusCommandHandler
    {
        private readonly IRepository<Film> _repository;

        public ToggleMovieStatusCommandHandler(IRepository<Film> repository)
        {
            _repository = repository;
        }

        public async Task Handle(ToggleMovieStatusCommand command)
        {
            var film = await _repository.GetByIdAsync(command.FilmID);

            if (film == null)
                throw new KeyNotFoundException($"Film with ID {command.FilmID} not found.");

            film.IsActive = !film.IsActive;

            _repository.UpdateAsync(film);
        }
    }
}