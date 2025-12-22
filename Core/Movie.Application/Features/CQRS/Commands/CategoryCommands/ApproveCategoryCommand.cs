namespace Movie.Application.Features.CQRS.Commands.CategoryCommands
{
    public class ApproveCategoryCommand
    {
        public int Id { get; set; }
        public ApproveCategoryCommand(int id) => Id = id;
    }
}