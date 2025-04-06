using MediatR;
using Movie.Application.Features.Mediator.Results.TagResults;

namespace Movie.Application.Features.Mediator.Queries.TagQueries
{
    public class GetTagQuery : IRequest<List<GetTagQueryResult>>
    {
    }
}