using Movie.Application.Features.CQRS.Commands.SeriesCommands;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;
using Movie.Domain.Entities.Enum;

namespace Movie.Application.Features.CQRS.Handlers.SeriesHandlers
{
    public class ArchiveSeriesCommandHandler
    {
        private readonly IRepository<Series> _repository;

        public ArchiveSeriesCommandHandler(IRepository<Series> repository)
        {
            _repository = repository;
        }

        public async Task Handle(ArchiveSeriesCommand command)
        {
            var series = await _repository.GetByIdAsync(command.Id);
            if (series == null)
                throw new KeyNotFoundException($"Dizi bulunamadı. (Id: {command.Id})");

            // 🔒 Kural: Deleted durumundaki kayıt arşivlenmez (önce restore edilmeli)
            if (series.DataStatus == DataStatus.Deleted)
                throw new InvalidOperationException("Çöp kutusundaki (Deleted) bir dizi arşivlenemez. Önce geri yükleyin (Restore).");

            // Zaten arşivdeyse: idempotent
            if (series.SeriesStatus == SeriesStatus.Archived)
                return;

            // 🔥 Önceki durumu sakla
            series.PreviousStatus ??= series.SeriesStatus;

            // Arşivle
            series.SeriesStatus = SeriesStatus.Archived;

            // BaseEntity standart güncelleme
            series.DataStatus = DataStatus.Updated;
            series.ModifiedDate = DateTime.UtcNow;

            await _repository.UpdateAsync(series);
        }
    }
}