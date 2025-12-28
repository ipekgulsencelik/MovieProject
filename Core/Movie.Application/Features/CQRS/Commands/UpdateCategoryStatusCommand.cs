using Movie.Domain.Entities.Enum;

namespace Movie.Application.Features.CQRS.Commands
{
    public class UpdateCategoryStatusCommand
    {
        public int Id { get; set; }
        public CategoryStatus CategoryStatus { get; set; }

        public UpdateCategoryStatusCommand(int id, CategoryStatus categoryStatus)
        {
            Id = id;
            CategoryStatus = categoryStatus;
        }
    }
}
