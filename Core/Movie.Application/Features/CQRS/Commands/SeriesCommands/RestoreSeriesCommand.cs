namespace Movie.Application.Features.CQRS.Commands.SeriesCommands
{
    public class RestoreSeriesCommand
    {
        public int Id { get; set; }

        public RestoreSeriesCommand(int id)
        {
            Id = id;
        }
    }
}