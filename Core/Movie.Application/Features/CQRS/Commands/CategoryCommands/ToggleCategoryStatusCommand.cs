namespace Movie.Application.Features.CQRS.Commands.CategoryCommands
{
    public class ToggleCategoryStatusCommand
    {
        public ToggleCategoryStatusCommand(int categoryID)
        {
            CategoryID = categoryID;
        }

        public int CategoryID { get; set; }
    }
}