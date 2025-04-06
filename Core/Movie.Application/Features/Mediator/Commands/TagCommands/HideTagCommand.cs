using MediatR;

namespace Movie.Application.Features.Mediator.Commands.TagCommands
{
    public class HideTagCommand : IRequest
    {
        public int TagId { get; set; }

        public HideTagCommand(int tagId)
        {
            TagId = tagId;
        }
    }
}