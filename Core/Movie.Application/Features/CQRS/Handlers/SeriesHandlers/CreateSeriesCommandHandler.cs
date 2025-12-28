using Movie.Application.Features.CQRS.Commands.SeriesCommands;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;
using Movie.Domain.Entities.Enum;
using System.ComponentModel.DataAnnotations;

namespace Movie.Application.Features.CQRS.Handlers.SeriesHandlers
{
    public class CreateSeriesCommandHandler
    {
        private readonly IRepository<Series> _seriesRepository;
        private readonly ICategoryRepository _categoryRepository;

        public CreateSeriesCommandHandler(
            IRepository<Series> seriesRepository,
            ICategoryRepository categoryRepository)
        {
            _seriesRepository = seriesRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<int> Handle(CreateSeriesCommand command)
        {
            // Duplicate temizle
            var categoryIds = command.CategoryIds?
                .Where(x => x > 0)
                .Distinct()
                .ToList() ?? new List<int>();

            if (categoryIds.Count == 0)
                throw new ValidationException("En az bir kategori seçmelisiniz.");

            // ID doğrulama (repository)
            var allExist = await _categoryRepository.AreAllIdsExist(categoryIds);
            if (!allExist)
                throw new KeyNotFoundException("Seçilen kategorilerden bazıları bulunamadı.");

            // Kategorileri çek (repository)
            var categories = await _categoryRepository.GetByIds(categoryIds);

            // Dizi oluştur
            var series = new Series
            {
                Title = command.Title,
                CoverImageUrl = command.CoverImageUrl,
                Rating = command.Rating,
                Description = command.Description,
                FirstAirDate = command.FirstAirDate,
                AverageEpisodeDuration = command.AverageEpisodeDuration,
                SeasonCount = command.SeasonCount,
                EpisodeCount = command.EpisodeCount,
                SeriesStatus = command.SeriesStatus,
                PreviousStatus = null,

                // BaseEntity alanların:
                IsVisible = false,
                IsActive = true
            };

            // Many-to-many bağla
            foreach (var category in categories)
                series.Categories.Add(category);

            // Kaydet
            await _seriesRepository.CreateAsync(series);

            return series.Id;
        }
    }
}
