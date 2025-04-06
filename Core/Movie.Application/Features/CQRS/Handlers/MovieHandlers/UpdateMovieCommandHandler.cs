using Movie.Application.Features.CQRS.Commands.MovieCommands;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;

namespace Movie.Application.Features.CQRS.Handlers.MovieHandlers
{
    public class UpdateMovieCommandHandler
    {
        private readonly IRepository<Film> _repository;

        public UpdateMovieCommandHandler(IRepository<Film> repository)
        {
            _repository = repository;
        }
        
        public async Task Handle(UpdateMovieCommand command)
        {
            var film = await _repository.GetByIdAsync(command.Id);

            if (film == null)
            {
                throw new KeyNotFoundException($"Movie with ID {command.Id} not found.");
            }

            film.Title = command.Title;
            film.CoverImageUrl = command.CoverImageUrl;
            film.Rating = command.Rating;
            film.Description = command.Description;
            film.Duration = command.Duration;
            film.ReleaseDate = command.ReleaseDate;
            film.IsActive = command.IsActive;
            film.IsVisible = command.IsVisible;

            await _repository.UpdateAsync(film);
        }
    }
}