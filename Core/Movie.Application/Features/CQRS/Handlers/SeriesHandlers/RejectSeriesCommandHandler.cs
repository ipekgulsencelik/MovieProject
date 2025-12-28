using Movie.Application.Features.CQRS.Commands.SeriesCommands;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;
using Movie.Domain.Entities.Enum;

namespace Movie.Application.Features.CQRS.Handlers.SeriesHandlers
{
    public class RejectSeriesCommandHandler
    {
        private readonly IRepository<Series> _repository;

        public RejectSeriesCommandHandler(IRepository<Series> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RejectSeriesCommand command)
        {
            var series = await _repository.GetByIdAsync(command.Id);
            if (series == null)
                throw new KeyNotFoundException($"Dizi bulunamadı. (Id: {command.Id})");

            // 🔒 Deleted ise reject olmaz (zaten çöp kutusu)
            if (series.DataStatus == DataStatus.Deleted)
                throw new InvalidOperationException("Çöp kutusundaki (Deleted) bir dizi reddedilemez. Önce Restore edin.");

            // 🔒 Archived ise reject olmaz
            if (series.SeriesStatus == SeriesStatus.Archived)
                throw new InvalidOperationException("Arşivdeki (Archived) bir dizi reddedilemez. Önce arşivden çıkarın.");

            // 🔒 Kural: sadece Pending reddedilir
            if (series.SeriesStatus != SeriesStatus.Pending)
                throw new InvalidOperationException("Reddetme işlemi sadece beklemedeki (Pending) diziler için yapılabilir.");

            // ✅ Reject: Pending -> Rejected
            series.PreviousStatus = series.SeriesStatus;
            series.SeriesStatus = SeriesStatus.Rejected;

            // Reddedilen içerik asla görünür olmasın
            series.IsVisible = false;

            // BaseEntity
            series.DataStatus = DataStatus.Updated;
            series.ModifiedDate = DateTime.UtcNow;

            await _repository.UpdateAsync(series);
        }
    }
}