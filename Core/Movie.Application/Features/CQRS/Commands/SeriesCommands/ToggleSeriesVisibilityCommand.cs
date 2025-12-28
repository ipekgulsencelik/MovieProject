namespace Movie.Application.Features.CQRS.Commands.SeriesCommands
{
    public class ToggleSeriesVisibilityCommand
    {
        public int Id { get; set; }

        public ToggleSeriesVisibilityCommand(int id) => Id = id;
    }
}