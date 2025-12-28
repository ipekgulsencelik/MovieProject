using Movie.Application.Features.CQRS.Commands.SeriesCommands;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;
using Movie.Domain.Entities.Enum;
using System.ComponentModel.DataAnnotations;

namespace Movie.Application.Features.CQRS.Handlers.SeriesHandlers
{
    public class UpdateSeriesCommandHandler
    {
        private readonly IRepository<Series> _seriesRepository;
        private readonly ICategoryRepository _categoryRepository;

        public UpdateSeriesCommandHandler(IRepository<Series> seriesRepository, ICategoryRepository categoryRepository)
        {
            _seriesRepository = seriesRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task Handle(UpdateSeriesCommand command)
        {
            // 1) Series getir
            var series = await _seriesRepository.GetByIdAsync(command.Id);
            if (series == null)
                throw new KeyNotFoundException($"Dizi bulunamadı. (Id: {command.Id})");

            // 2) İş kuralları
            if (series.DataStatus == DataStatus.Deleted)
                throw new InvalidOperationException("Çöp kutusundaki (Deleted) bir dizi güncellenemez. Önce Restore edin.");

            if (series.SeriesStatus == SeriesStatus.Archived)
                throw new InvalidOperationException("Arşivdeki (Archived) bir dizi güncellenemez. Önce arşivden çıkarın.");

            // 3) CategoryIds temizle + doğrula
            var categoryIds = command.CategoryIds?
                .Where(x => x > 0)
                .Distinct()
                .ToList() ?? new List<int>();

            if (categoryIds.Count == 0)
                throw new ValidationException("En az bir kategori seçmelisiniz.");

            var allExist = await _categoryRepository.AreAllIdsExist(categoryIds);
            if (!allExist)
                throw new KeyNotFoundException("Seçilen kategorilerden bazıları bulunamadı.");

            var categories = await _categoryRepository.GetByIds(categoryIds);

            // 4) Alanları güncelle
            series.Title = command.Title;
            series.CoverImageUrl = command.CoverImageUrl;
            series.Rating = command.Rating;
            series.Description = command.Description;
            series.FirstAirDate = command.FirstAirDate;
            series.AverageEpisodeDuration = command.AverageEpisodeDuration;
            series.SeasonCount = command.SeasonCount;
            series.EpisodeCount = command.EpisodeCount;

            // BaseEntity standart
            series.DataStatus = DataStatus.Updated;
            series.ModifiedDate = DateTime.UtcNow;

            // 5) Many-to-many sync (Categories)
            // - Eski bağlantıları temizle
            series.Categories.Clear();

            // - Yeni bağlantıları ekle
            foreach (var category in categories)
                series.Categories.Add(category);

            // 6) Kaydet
            await _seriesRepository.UpdateAsync(series);

        }
    }
}