using Movie.Domain.Entities.Abstract;

namespace Movie.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<Film> Films { get; set; } = new HashSet<Film>();
    }
}