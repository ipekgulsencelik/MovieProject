namespace Movie.Domain.Entities
{
    public class Review
    {
        public int ReviewID { get; set; }
        public string? Comment { get; set; }
        public decimal Rating { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; 
        public bool IsApproved { get; set; } = false; // Yorum onaylandı mı?

        public int FilmID { get; set; }
        public virtual Film Film { get; set; } = null!;
    }
}