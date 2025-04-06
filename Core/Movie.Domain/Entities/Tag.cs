using Movie.Domain.Entities.Abstract;

namespace Movie.Domain.Entities
{
    public class Tag : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
    }
}