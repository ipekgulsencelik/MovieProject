using MediatR;

namespace Movie.Application.Features.Mediator.Commands.CastCommands
{
    public class HideCastCommand : IRequest
    {
        public int CastId { get; set; }

        public HideCastCommand(int castId)
        {
            CastId = castId;
        }
    }
}