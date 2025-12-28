namespace Movie.Application.Features.CQRS.Commands.SeriesCommands
{
    public class SoftDeleteSeriesCommand
    {
        public int Id { get; set; }

        public SoftDeleteSeriesCommand(int id) => Id = id;
    }
}