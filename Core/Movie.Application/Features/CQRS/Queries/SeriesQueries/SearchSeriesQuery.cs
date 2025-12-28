using Movie.Domain.Entities.Enum;

namespace Movie.Application.Features.CQRS.Queries.SeriesQueries
{
    public class SearchSeriesQuery
    {
        public string? Q { get; set; }              // title arama
        public SeriesStatus? Status { get; set; }   // opsiyonel

        public decimal? MinRating { get; set; }
        public decimal? MaxRating { get; set; }

        public DateTime? FromFirstAirDate { get; set; }
        public DateTime? ToFirstAirDate { get; set; }

        // paging (opsiyonel)
        public int Page { get; set; } = 1;          // 1-based
        public int PageSize { get; set; } = 20;     // default
    }
}