namespace Movie.Application.Features.CQRS.Commands.SeriesCommands
{
    public class UnarchiveSeriesCommand
    {
        public int Id { get; set; }

        public UnarchiveSeriesCommand(int id) => Id = id;
    }
}