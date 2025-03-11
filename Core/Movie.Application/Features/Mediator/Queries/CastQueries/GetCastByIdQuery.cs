using MediatR;
using Movie.Application.Features.Mediator.Results.CastResults;

namespace Movie.Application.Features.Mediator.Queries.CastQueries
{
    public class GetCastByIdQuery : IRequest<GetCastByIdQueryResult>
    {
        public int CastId { get; set; }

        public GetCastByIdQuery(int castId)
        {
            CastId = castId;
        }
    }
}