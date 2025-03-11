namespace Movie.Application.Features.Mediator.Results.CastResults
{
    public class GetCastByIdQueryResult
    {
        public int CastID { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string ImageUrl { get; set; }
        public string? Overview { get; set; }
        public string? Biography { get; set; }
        public bool IsVisible { get; set; }
        public bool IsActive { get; set; }
    }
}