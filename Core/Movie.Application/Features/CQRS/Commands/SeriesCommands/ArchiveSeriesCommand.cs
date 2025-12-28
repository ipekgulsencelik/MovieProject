namespace Movie.Application.Features.CQRS.Commands.SeriesCommands
{
    public class ArchiveSeriesCommand
    {
        public int Id { get; set; }

        public ArchiveSeriesCommand(int id) 
        {
            Id = id;
        }
    }
}