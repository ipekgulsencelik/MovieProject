namespace Movie.Domain.Entities
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsVisible { get; set; } = false;
        public bool IsActive { get; set; } = true;

        public virtual ICollection<Film> Films { get; set; } = new List<Film>();
    }
}