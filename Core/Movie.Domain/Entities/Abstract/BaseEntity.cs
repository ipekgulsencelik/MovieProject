using Movie.Domain.Entities.Enum;

namespace Movie.Domain.Entities.Abstract
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DataStatus DataStatus { get; set; } = DataStatus.Created;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool IsVisible { get; set; } = false;
        public bool IsActive { get; set; } = true;

        public bool IsUsable => DataStatus != DataStatus.Deleted && IsActive;
    }
}