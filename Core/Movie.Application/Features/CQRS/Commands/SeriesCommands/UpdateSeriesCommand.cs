using Movie.Domain.Entities.Enum;

namespace Movie.Application.Features.CQRS.Commands.SeriesCommands
{
    public class UpdateSeriesCommand
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? CoverImageUrl { get; set; }
        public decimal Rating { get; set; } = 0m;
        public string? Description { get; set; }
        public DateTime FirstAirDate { get; set; }
        public int? AverageEpisodeDuration { get; set; }
        public int SeasonCount { get; set; }
        public int EpisodeCount { get; set; }
        public SeriesStatus SeriesStatus { get; set; } = SeriesStatus.Ongoing;
        public bool IsVisible { get; set; }
        public List<int> CategoryIds { get; init; } = new();
    }
}