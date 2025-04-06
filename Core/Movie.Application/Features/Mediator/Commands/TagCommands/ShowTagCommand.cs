using MediatR;

namespace Movie.Application.Features.Mediator.Commands.TagCommands
{
    public class ShowTagCommand : IRequest
    {
        public int TagId { get; set; }

        public ShowTagCommand(int tagId)
        {
            TagId = tagId;
        }
    }
}