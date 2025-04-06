using MediatR;

namespace Movie.Application.Features.Mediator.Commands.CastCommands
{
    public class UpdateCastCommand : IRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string ImageUrl { get; set; }
        public string? Overview { get; set; }
        public string? Biography { get; set; }
        public bool IsVisible { get; set; }
        public bool IsActive { get; set; } 
    }
}