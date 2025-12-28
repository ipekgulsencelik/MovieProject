using Movie.Domain.Entities.Enum;

namespace Movie.Application.Features.CQRS.Results.SeriesResults
{
    public class GetSeriesQueryResult
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;
        public string? CoverImageUrl { get; set; }

        public decimal Rating { get; set; }

        public DateTime FirstAirDate { get; set; }
        public int FirstAirYear => FirstAirDate.Year;

        public SeriesStatus SeriesStatus { get; set; }

        // BaseEntity flags
        public bool IsActive { get; set; }
        public bool IsVisible { get; set; }

        public List<string> CategoryNames { get; set; } = new();
    }
}