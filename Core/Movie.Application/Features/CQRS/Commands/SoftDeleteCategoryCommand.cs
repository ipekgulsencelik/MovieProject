namespace Movie.Application.Features.CQRS.Commands
{
    public class SoftDeleteCategoryCommand
    {
        public int Id { get; set; }
        public SoftDeleteCategoryCommand(int id) => Id = id;
    }
}