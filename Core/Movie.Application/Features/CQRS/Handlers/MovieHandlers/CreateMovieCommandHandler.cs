using Movie.Application.Features.CQRS.Commands.MovieCommands;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;

namespace Movie.Application.Features.CQRS.Handlers.MovieHandlers
{
    public class CreateMovieCommandHandler
    {
        private readonly IRepository<Film> _repository;

        public CreateMovieCommandHandler(IRepository<Film> repository)
        {
            _repository = repository;
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

            await _repository.CreateAsync(film);
        }
    }
}