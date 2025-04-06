using MediatR;
using Movie.Application.Features.Mediator.Results.CastResults;

namespace Movie.Application.Features.Mediator.Queries.CastQueries
{
    public class GetVisibleCastQuery : IRequest<List<GetVisibleCastsQueryResult>>
    {
    }
}