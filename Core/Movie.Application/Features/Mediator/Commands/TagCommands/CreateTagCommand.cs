using MediatR;

namespace Movie.Application.Features.Mediator.Commands.TagCommands
{
    public class CreateTagCommand : IRequest
    {
        public string Title { get; set; }
    }
}