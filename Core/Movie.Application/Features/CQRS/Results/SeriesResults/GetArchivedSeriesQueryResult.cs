namespace Movie.Application.Features.CQRS.Results.SeriesResults
{
    public class GetArchivedSeriesQueryResult
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public decimal Rating { get; set; }
        public DateTime FirstAirDate { get; set; }
        public int SeasonCount { get; set; }
        public int EpisodeCount { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
