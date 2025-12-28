using Movie.Application.Features.CQRS.Commands.SeriesCommands;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;
using Movie.Domain.Entities.Enum;

namespace Movie.Application.Features.CQRS.Handlers.SeriesHandlers
{
    public class ToggleSeriesVisibilityCommandHandler
    {
        private readonly IRepository<Series> _repository;

        public ToggleSeriesVisibilityCommandHandler(IRepository<Series> repository)
        {
            _repository = repository;
        }

        public async Task Handle(ToggleSeriesVisibilityCommand command)
        {
            var series = await _repository.GetByIdAsync(command.Id);
            if (series == null)
                throw new KeyNotFoundException($"Dizi bulunamadı. (Id: {command.Id})");

            // 🔒 Deleted ise publish/unpublish olmaz
            if (series.DataStatus == DataStatus.Deleted)
                throw new InvalidOperationException("Çöp kutusundaki (Deleted) bir dizinin görünürlüğü değiştirilemez. Önce Restore edin.");

            // 🔒 Archived ise görünür yapılamaz
            if (series.SeriesStatus == SeriesStatus.Archived)
                throw new InvalidOperationException(
                    "Arşivdeki (Archived) bir dizi görünür yapılamaz. Önce arşivden çıkarın.");

            // Toggle
            series.IsVisible = !series.IsVisible;

            // BaseEntity standart
            series.DataStatus = DataStatus.Updated;
            series.ModifiedDate = DateTime.UtcNow;

            await _repository.UpdateAsync(series);
        }
    }
}