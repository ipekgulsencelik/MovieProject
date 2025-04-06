using MediatR;
using Movie.Application.Features.Mediator.Results.TagResults;

namespace Movie.Application.Features.Mediator.Queries.TagQueries
{
    public class GetVisibleTagQuery : IRequest<List<GetVisibleTagsQueryResult>>
    {
    }
}
