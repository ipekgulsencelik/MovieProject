using Movie.Application.Features.CQRS.Commands.SeriesCommands;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;
using Movie.Domain.Entities.Enum;

namespace Movie.Application.Features.CQRS.Handlers.SeriesHandlers
{
    public class ApproveSeriesCommandHandler
    {
        private readonly IRepository<Series> _repository;

        public ApproveSeriesCommandHandler(IRepository<Series> repository)
        {
            _repository = repository;
        }

        public async Task Handle(ApproveSeriesCommand command)
        {
            var series = await _repository.GetByIdAsync(command.Id);
            if (series == null)
                throw new KeyNotFoundException($"Dizi bulunamadı. (Id: {command.Id})");

            // 🔒 Deleted ise onay olmaz
            if (series.DataStatus == DataStatus.Deleted)
                throw new InvalidOperationException("Çöp kutusundaki (Deleted) bir dizi onaylanamaz. Önce Restore edin.");

            // 🔒 Archived ise onay olmaz (önce arşivden çıkar)
            if (series.SeriesStatus == SeriesStatus.Archived)
                throw new InvalidOperationException("Arşivdeki (Archived) bir dizi onaylanamaz. Önce arşivden çıkarın.");

            // 🔒 Kural: sadece Pending onaylanır
            if (series.SeriesStatus != SeriesStatus.Pending)
                throw new InvalidOperationException("Onay işlemi sadece beklemedeki (Pending) diziler için yapılabilir.");

            // ✅ Approve: Pending -> Ongoing
            series.PreviousStatus = series.SeriesStatus;
            series.SeriesStatus = SeriesStatus.Ongoing;

            // MMU: istersen direkt yayınla
            series.IsVisible = command.Publish;

            // BaseEntity
            series.IsActive = true;
            series.DataStatus = DataStatus.Updated;
            series.ModifiedDate = DateTime.UtcNow;

            await _repository.UpdateAsync(series);
        }
    }
}
