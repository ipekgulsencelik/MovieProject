using Movie.Application.Features.CQRS.Commands.MovieCommands;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Movie.Application.Features.CQRS.Handlers.MovieHandlers
{
    public class CreateMovieCommandHandler
    {
        private readonly IRepository<Film> _movieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public CreateMovieCommandHandler(IRepository<Film> movieRepository, ICategoryRepository categoryRepository)
        {
            _movieRepository = movieRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<int> Handle(CreateMovieCommand command)
        {
            // Duplicate temizle
            var categoryIds = command.CategoryIds?.Where(x => x > 0).Distinct().ToList() ?? new List<int>();

            if (categoryIds.Count == 0)
                throw new ValidationException("En az bir kategori seçmelisiniz.");

            // ID doğrulama (repository)
            var allExist = await _categoryRepository.AreAllIdsExist(categoryIds);
            if (!allExist)
                throw new KeyNotFoundException("Seçilen kategorilerden bazıları bulunamadı.");

            // Kategorileri çek (repository)
            var categories = await _categoryRepository.GetByIds(categoryIds);

            // Film oluştur
            var film = new Film
            {
                Title = command.Title,
                CoverImageUrl = command.CoverImageUrl,
                Rating = command.Rating,
                Description = command.Description,
                Duration = command.Duration,
                ReleaseDate = command.ReleaseDate,
                MovieStatus = command.MovieStatus,

                // BaseEntity alanların:
                IsVisible = false,
                IsActive = true
            };

            // Many-to-many bağla
            foreach (var category in categories)
                film.Categories.Add(category);

            // Kaydet
            await _movieRepository.CreateAsync(film);

            return film.Id;
        }
    }
}