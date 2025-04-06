using MediatR;

namespace Movie.Application.Features.Mediator.Commands.TagCommands
{
    public class ToggleTagStatusCommand : IRequest
    {
        public int TagId { get; set; }

        public ToggleTagStatusCommand(int tagId)
        {
            TagId = tagId;
        }
    }
}