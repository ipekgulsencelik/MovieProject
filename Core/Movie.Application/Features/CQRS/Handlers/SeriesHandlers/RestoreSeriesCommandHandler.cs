using Movie.Application.Features.CQRS.Commands.SeriesCommands;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;
using Movie.Domain.Entities.Enum;

namespace Movie.Application.Features.CQRS.Handlers.SeriesHandlers
{
    public class RestoreSeriesCommandHandler
    {
        private readonly IRepository<Series> _repository;

        public RestoreSeriesCommandHandler(IRepository<Series> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RestoreSeriesCommand command)
        {
            // ✅ Deleted dahil getir (restore senaryosu için şart)
            var series = await _repository.GetByIdIncludingDeletedAsync(command.Id);
            if (series == null)
                throw new KeyNotFoundException($"Dizi bulunamadı. (Id: {command.Id})");

            // 🔒 Kural: Deleted değilse restore işlemine gerek yok
            if (series.DataStatus != DataStatus.Deleted)
                throw new InvalidOperationException("Geri yükleme (Restore) işlemi sadece çöp kutusundaki (Deleted) kayıtlar için yapılabilir.");

            // ✅ Soft delete'i geri al
            series.DataStatus = DataStatus.Updated;
            series.DeletedDate = null;
            series.ModifiedDate = DateTime.UtcNow;

            series.IsActive = true;

            // 🔥 Status geri dönüş kuralı:
            // - Eğer daha önce arşivlenmişse PreviousStatus'tan dön
            // - Yoksa default Ongoing'e dön
            if (series.SeriesStatus == SeriesStatus.Archived)
            {
                series.SeriesStatus = series.PreviousStatus ?? SeriesStatus.Ongoing;
                series.PreviousStatus = null;
            }

            // Görünürlük: restore sonrası default kapalı kalsın (güvenli)
            series.IsVisible = false;

            await _repository.UpdateAsync(series);
        }
    }
}