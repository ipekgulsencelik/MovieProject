namespace Movie.Application.Features.CQRS.Queries.SeriesQueries
{
    public class GetSeriesByCategoryQuery
    {
        public int CategoryId { get; set; }

        // paging
        public int Page { get; set; } = 1;       // 1-based
        public int PageSize { get; set; } = 20;

        public GetSeriesByCategoryQuery(int categoryId, int page = 1, int pageSize = 20)
        {
            CategoryId = categoryId;
            Page = page;
            PageSize = pageSize;
        }
    }
}
