using MediatR;

namespace Movie.Application.Features.Mediator.Commands.CastCommands
{
    public class ShowCastCommand : IRequest
    {
        public int CastId { get; set; }

        public ShowCastCommand(int castId)
        {
            CastId = castId;
        }
    }
}