namespace Movie.Application.Features.CQRS.Commands.CategoryCommands
{
    public class RejectCategoryCommand
    {
        public int Id { get; set; }

        public RejectCategoryCommand(int id)
        {
            Id = id;
        }
    }
}