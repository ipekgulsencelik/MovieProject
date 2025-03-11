using MediatR;

namespace Movie.Application.Features.Mediator.Commands.CastCommands
{
    public class RemoveCastCommand : IRequest
    {
        public int CastId { get; set; }

        public RemoveCastCommand(int castId)
        {
            CastId = castId;
        }
    }
}