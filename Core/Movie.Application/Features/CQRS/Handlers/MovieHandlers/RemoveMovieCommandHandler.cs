using Movie.Application.Features.CQRS.Commands.MovieCommands;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;

namespace Movie.Application.Features.CQRS.Handlers.MovieHandlers
{
    public class RemoveMovieCommandHandler
    {
        private readonly IRepository<Film> _repository;

        public RemoveMovieCommandHandler(IRepository<Film> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveMovieCommand command)
        {
            await _repository.DeleteAsync(command.FilmId);
        }
    }
}