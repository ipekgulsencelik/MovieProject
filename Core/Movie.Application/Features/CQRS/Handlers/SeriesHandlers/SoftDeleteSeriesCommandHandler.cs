using Movie.Application.Features.CQRS.Commands.SeriesCommands;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;
using Movie.Domain.Entities.Enum;

namespace Movie.Application.Features.CQRS.Handlers.SeriesHandlers
{
    public class SoftDeleteSeriesCommandHandler
    {
        private readonly IRepository<Series> _repository;

        public SoftDeleteSeriesCommandHandler(IRepository<Series> repository)
        {
            _repository = repository;
        }

        public async Task Handle(SoftDeleteSeriesCommand command)
        {
            var series = await _repository.GetByIdAsync(command.Id);

            // 🔒 İş kuralı: Arşivdeki dizi çöp kutusuna taşınamaz
            if (series.SeriesStatus == SeriesStatus.Archived)
                throw new InvalidOperationException("Arşivdeki bir dizi çöp kutusuna taşınamaz. Önce arşivden çıkarılmalıdır.");

            await _repository.DeleteAsync(command.Id);
        }
    }
}