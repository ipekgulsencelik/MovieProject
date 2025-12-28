using Movie.Application.Features.CQRS.Commands.SeriesCommands;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;
using Movie.Domain.Entities.Enum;

namespace Movie.Application.Features.CQRS.Handlers.SeriesHandlers
{
    public class HardDeleteSeriesCommandHandler
    {
        private readonly IRepository<Series> _repository;

        public HardDeleteSeriesCommandHandler(IRepository<Series> repository)
        {
            _repository = repository;
        }

        public async Task Handle(HardDeleteSeriesCommand command)
        {
            var series = await _repository.GetByIdIncludingDeletedAsync(command.Id);
            if (series == null)
                throw new KeyNotFoundException($"Dizi bulunamadı. (Id: {command.Id})");

            // 🔒 Kural: Kalıcı silme sadece Deleted veya Archived iken
            var canHardDelete =
                series.DataStatus == DataStatus.Deleted ||
                series.SeriesStatus == SeriesStatus.Archived;

            if (!canHardDelete)
                throw new InvalidOperationException("Kalıcı silmeden önce dizi çöp kutusuna taşınmış (Deleted) ya da arşivlenmiş (Archived) olmalıdır.");

            await _repository.RemoveAsync(series);
        }
    }
}