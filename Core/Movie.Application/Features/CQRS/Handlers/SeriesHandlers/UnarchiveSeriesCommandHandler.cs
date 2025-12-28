using Movie.Application.Features.CQRS.Commands.SeriesCommands;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;
using Movie.Domain.Entities.Enum;

namespace Movie.Application.Features.CQRS.Handlers.SeriesHandlers
{
    public class UnarchiveSeriesCommandHandler
    {
        private readonly IRepository<Series> _repository;

        public UnarchiveSeriesCommandHandler(IRepository<Series> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UnarchiveSeriesCommand command)
        {
            var series = await _repository.GetByIdAsync(command.Id);
            if (series == null)
                throw new KeyNotFoundException($"Dizi bulunamadı. (Id: {command.Id})");

            // 🔒 Deleted ise unarchive olmaz
            if (series.DataStatus == DataStatus.Deleted)
                throw new InvalidOperationException("Çöp kutusundaki (Deleted) bir dizi arşivden çıkarılamaz. Önce Restore edin.");

            // Zaten arşivde değilse idempotent
            if (series.SeriesStatus != SeriesStatus.Archived)
                return;

            // ✅ Archived'dan çık: PreviousStatus'a dön, yoksa Ongoing'e dön
            series.SeriesStatus = series.PreviousStatus ?? SeriesStatus.Ongoing;
            series.PreviousStatus = null;

            // BaseEntity standart
            series.DataStatus = DataStatus.Updated;
            series.ModifiedDate = DateTime.UtcNow;

            // Güvenli varsayılan: görünürlük kapalı kalsın
            series.IsVisible = false;

            await _repository.UpdateAsync(series);
        }
    }
}