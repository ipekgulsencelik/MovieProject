﻿using Movie.Application.Features.CQRS.Results.MovieResults;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;

namespace Movie.Application.Features.CQRS.Handlers.MovieHandlers
{
    public class GetActiveMoviesQueryHandler
    {
        private readonly IRepository<Film> _repository;

        public GetActiveMoviesQueryHandler(IRepository<Film> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetActiveMoviesQueryResult>> Handle()
        {
            var movies = await _repository.GetFilteredListAsync(f => f.IsActive);

            return movies.Select(x => new GetActiveMoviesQueryResult
            {
                FilmID = x.FilmID,
                Title = x.Title,
                CoverImageUrl = x.CoverImageUrl,
                Rating = x.Rating,
                Description = x.Description,
                Duration = x.Duration,
                ReleaseDate = x.ReleaseDate,
                IsActive = x.IsActive,
                IsVisible = x.IsVisible
            }).ToList();
        }
    }
}