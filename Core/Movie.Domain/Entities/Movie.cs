namespace Movie.Domain.Entities
{
    public class Movie
    {
        public int MovieID { get; set; }
        public string? Title { get; set; }
        public string? CoverImageUrl { get; set; }
        public decimal Rating { get; set; } 
        public string? Description { get; set; } 
        public int Duration { get; set; } 
        public DateTime ReleaseDate { get; set; }
        public int ReleaseYear => ReleaseDate.Year;
        public bool IsVisible { get; set; } = false;
        public bool Status { get; set; } = true;
    }
}