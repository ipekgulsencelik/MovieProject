namespace Movie.Application.Features.CQRS.Commands.SeriesCommands
{
    public class ApproveSeriesCommand
    {
        public int Id { get; set; }
        public bool Publish { get; set; } // MMU: onayla + isterse yayına al

        public ApproveSeriesCommand(int id, bool publish = false)
        {
            Id = id;
            Publish = publish;
        }
    }
}
