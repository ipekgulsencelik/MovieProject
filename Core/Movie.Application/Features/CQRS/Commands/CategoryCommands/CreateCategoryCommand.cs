namespace Movie.Application.Features.CQRS.Commands.CategoryCommands
{
    public class CreateCategoryCommand
    {
        public string? Name { get; set; } 
        public bool IsVisible { get; set; } = false;
        public bool IsActive { get; set; } = true;
    }
}