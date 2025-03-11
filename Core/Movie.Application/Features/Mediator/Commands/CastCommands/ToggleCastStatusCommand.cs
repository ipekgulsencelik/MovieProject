using MediatR;

namespace Movie.Application.Features.Mediator.Commands.CastCommands
{
    public class ToggleCastStatusCommand : IRequest
    {
        public int CastId { get; set; }

        public ToggleCastStatusCommand(int castId)
        {
            CastId = castId;
        }
    }
}