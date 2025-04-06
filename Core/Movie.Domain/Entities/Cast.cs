using Movie.Domain.Entities.Abstract;

namespace Movie.Domain.Entities
{
    public class Cast : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string? Overview { get; set; }
        public string? Biography { get; set; }
    }
}