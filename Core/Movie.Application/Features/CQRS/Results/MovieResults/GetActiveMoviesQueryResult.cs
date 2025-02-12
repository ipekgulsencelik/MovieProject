namespace Movie.Application.Features.CQRS.Results.MovieResults
{
    public class GetActiveMoviesQueryResult
    {
        public int FilmID { get; set; }
        public string? Title { get; set; }
        public string? CoverImageUrl { get; set; }
        public decimal Rating { get; set; }
        public string? Description { get; set; }
        public int Duration { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool IsVisible { get; set; }
        public bool IsActive { get; set; }
    }
}