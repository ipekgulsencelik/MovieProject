namespace Movie.Domain.Entities
{
    public class Tag
    {
        public int TagID { get; set; }
        public string Title { get; set; }
        public bool IsVisible { get; set; } = false;
        public bool IsActive { get; set; } = true;
    }
}