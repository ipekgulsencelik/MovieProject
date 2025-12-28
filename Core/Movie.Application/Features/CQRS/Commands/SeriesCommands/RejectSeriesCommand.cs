namespace Movie.Application.Features.CQRS.Commands.SeriesCommands
{
    public class RejectSeriesCommand
    {
        public int Id { get; set; }
        public string? Reason { get; set; } // MMU: gerekçe opsiyonel 

        public RejectSeriesCommand(int id, string? reason = null)
        {
            Id = id;
            Reason = reason;
        }
    }
}