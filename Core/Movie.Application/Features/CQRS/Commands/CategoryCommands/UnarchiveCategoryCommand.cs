namespace Movie.Application.Features.CQRS.Commands.CategoryCommands
{
    public class UnarchiveCategoryCommand
    {
        public int Id { get; set; }
        public UnarchiveCategoryCommand(int id)
        {
            Id = id;
        }
    }
}