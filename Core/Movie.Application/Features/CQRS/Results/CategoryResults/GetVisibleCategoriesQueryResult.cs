namespace Movie.Application.Features.CQRS.Results.CategoryResults
{
    public class GetVisibleCategoriesQueryResult
    {
        public int CategoryID { get; set; }
        public string? Name { get; set; }
        public bool IsVisible { get; set; }
        public bool IsActive { get; set; }
    }
}