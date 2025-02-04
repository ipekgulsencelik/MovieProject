namespace Movie.Domain.Entities
{
    public class Review
    {
        public int ReviewID { get; set; }
        public string? Comment { get; set; }
        public decimal Rating { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Yorum tarihi
        public bool IsApproved { get; set; } = false; // Yorum onaylandı mı?
    }
}