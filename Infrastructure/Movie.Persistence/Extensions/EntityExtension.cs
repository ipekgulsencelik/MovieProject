using Movie.Domain.Entities.Abstract;
using Movie.Domain.Entities.Enum;

namespace Movie.Persistence.Extensions
{
    public static class EntityExtension
    {
        public static bool CanBeShown(this BaseEntity entity) =>
            entity.DataStatus != DataStatus.Deleted && entity.IsActive && !entity.IsVisible;

        public static bool CanBeHidden(this BaseEntity entity) =>
            entity.DataStatus != DataStatus.Deleted && entity.IsActive && entity.IsVisible;
    }
}