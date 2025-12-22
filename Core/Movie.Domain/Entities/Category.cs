using Movie.Domain.Entities.Abstract;
using Movie.Domain.Entities.Enum;

namespace Movie.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int DisplayOrder { get; set; } = 0;
        public CategoryStatus CategoryStatus { get; set; } = CategoryStatus.Pending;

        public virtual ICollection<Film> Films { get; set; } = new HashSet<Film>();
    }
}