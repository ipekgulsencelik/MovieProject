using MediatR;
using Movie.Application.Features.Mediator.Results.CastResults;

namespace Movie.Application.Features.Mediator.Queries.CastQueries
{
    public class GetCastQuery : IRequest<List<GetCastQueryResult>>
    {
    }
}