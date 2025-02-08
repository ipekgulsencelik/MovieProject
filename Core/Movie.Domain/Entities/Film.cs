namespace Movie.Domain.Entities
{
    public class Film
    {
        public int FilmID { get; set; }
        public string? Title { get; set; } = string.Empty;
        public string? CoverImageUrl { get; set; }
        public decimal Rating { get; set; } = 0m;
        public string? Description { get; set; } 
        public int Duration { get; set; } 
        public DateTime ReleaseDate { get; set; }
        public int ReleaseYear => ReleaseDate.Year;
        public bool IsVisible { get; set; } = false;
        public bool IsActive { get; set; } = true;

        public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}