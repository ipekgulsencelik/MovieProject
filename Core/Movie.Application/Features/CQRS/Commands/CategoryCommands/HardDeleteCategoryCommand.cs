namespace Movie.Application.Features.CQRS.Commands.CategoryCommands
{
    public class HardDeleteCategoryCommand
    {
        public int Id { get; set; }
        public HardDeleteCategoryCommand(int id) => Id = id;
    }
}
