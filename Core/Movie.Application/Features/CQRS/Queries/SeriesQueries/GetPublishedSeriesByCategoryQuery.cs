namespace Movie.Application.Features.CQRS.Queries.SeriesQueries
{
    public class GetPublishedSeriesByCategoryQuery
    {
        public int CategoryId { get; set; }

        public bool Published { get; set; } = true;

        public int Page { get; set; } = 1;       // 1-based
        public int PageSize { get; set; } = 20;

        public GetPublishedSeriesByCategoryQuery(int categoryId, bool published = true, int page = 1, int pageSize = 20)
        {
            CategoryId = categoryId;
            Published = published;
            Page = page;
            PageSize = pageSize;
        }
    }
}