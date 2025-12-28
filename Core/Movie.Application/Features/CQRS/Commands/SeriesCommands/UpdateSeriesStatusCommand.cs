using Movie.Domain.Entities.Enum;

namespace Movie.Application.Features.CQRS.Commands.SeriesCommands
{
    public class UpdateSeriesStatusCommand
    {
        public int Id { get; set; }
        public SeriesStatus NewStatus { get; set; }

        public UpdateSeriesStatusCommand(int id, SeriesStatus newStatus)
        {
            Id = id;
            NewStatus = newStatus;
        }
    }
}