namespace Movie.Application.Features.CQRS.Commands.SeriesCommands
{
    public class HardDeleteSeriesCommand
    {
        public int Id { get; set; }

        public HardDeleteSeriesCommand(int id) => Id = id;
    }
}