using Movie.Application.Features.CQRS.Commands.SeriesCommands;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;
using Movie.Domain.Entities.Enum;

namespace Movie.Application.Features.CQRS.Handlers.SeriesHandlers
{
    public class UpdateSeriesStatusCommandHandler
    {
        private readonly IRepository<Series> _repository;

        public UpdateSeriesStatusCommandHandler(IRepository<Series> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateSeriesStatusCommand command)
        {
            var series = await _repository.GetByIdAsync(command.Id);
            if (series == null)
                throw new KeyNotFoundException($"Dizi bulunamadı. (Id: {command.Id})");

            // 🔒 Deleted ise status değişmez
            if (series.DataStatus == DataStatus.Deleted)
                throw new InvalidOperationException(
                    "Çöp kutusundaki (Deleted) bir dizinin durumu değiştirilemez. Önce Restore edin.");

            // 🔒 Archived ise status değişmez (önce arşivden çıkar / restore akışını kullan)
            if (series.SeriesStatus == SeriesStatus.Archived)
                throw new InvalidOperationException("Arşivdeki (Archived) bir dizinin durumu değiştirilemez. Önce arşivden çıkarın.");

            // ✅ Aynı statüyse idempotent
            if (series.SeriesStatus == command.NewStatus)
                return;

            // 🔥 Önceki durumu sakla
            series.PreviousStatus = series.SeriesStatus;

            // Status güncelle
            series.SeriesStatus = command.NewStatus;

            // BaseEntity standart
            series.DataStatus = DataStatus.Updated;
            series.ModifiedDate = DateTime.UtcNow;

            await _repository.UpdateAsync(series);
        }
    }
}