namespace Movie.Application.Features.CQRS.Commands.CategoryCommands
{
    public class ShowCategoryCommand
    {
        public ShowCategoryCommand(int categoryID)
        {
            CategoryID = categoryID;
        }

        public int CategoryID { get; set; }
    }
}