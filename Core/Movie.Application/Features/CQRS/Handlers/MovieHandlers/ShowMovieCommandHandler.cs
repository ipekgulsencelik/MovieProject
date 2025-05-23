﻿using Movie.Application.Features.CQRS.Commands.MovieCommands;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;

namespace Movie.Application.Features.CQRS.Handlers.MovieHandlers
{
    public class ShowMovieCommandHandler
    {
        private readonly IRepository<Film> _repository;

        public ShowMovieCommandHandler(IRepository<Film> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(ShowMovieCommand command)
        {
            var film = await _repository.GetByIdAsync(command.FilmId);

            if (film == null)
                throw new KeyNotFoundException($"Film with ID {command.FilmId} not found.");

            if (film.IsActive == false)
                return false;

            film.IsVisible = true;

            await _repository.UpdateAsync(film);

            return true;
        }
    }
}