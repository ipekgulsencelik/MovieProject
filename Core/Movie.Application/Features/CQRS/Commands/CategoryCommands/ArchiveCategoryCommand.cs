namespace Movie.Application.Features.CQRS.Commands.CategoryCommands
{
    public class ArchiveCategoryCommand
    {
        public int Id { get; set; }
        public ArchiveCategoryCommand(int id)
        {
            Id = id;
        }
    }
}