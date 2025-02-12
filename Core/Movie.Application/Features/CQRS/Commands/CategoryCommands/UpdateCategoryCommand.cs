namespace Movie.Application.Features.CQRS.Commands.CategoryCommands
{
    public class UpdateCategoryCommand
    {
        public int CategoryID { get; set; }
        public string? Name { get; set; }
        public bool IsVisible { get; set; }
        public bool IsActive { get; set; }
    }
}