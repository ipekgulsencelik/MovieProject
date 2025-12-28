using Movie.Domain.Entities.Enum;

namespace Movie.Application.Features.CQRS.Results.SeriesResults
{
    public class GetSeriesByIdQueryResult
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;
        public string? CoverImageUrl { get; set; }

        public decimal Rating { get; set; }
        public string? Description { get; set; }

        public DateTime FirstAirDate { get; set; }
        public int FirstAirYear => FirstAirDate.Year;

        public int? AverageEpisodeDuration { get; set; }
        public int SeasonCount { get; set; }
        public int EpisodeCount { get; set; }

        public SeriesStatus SeriesStatus { get; set; }

        // BaseEntity flags
        public bool IsActive { get; set; }
        public bool IsVisible { get; set; }

        // Categories
        public List<int> CategoryIds { get; set; } = new();
        public List<string> CategoryNames { get; set; } = new();
    }
}