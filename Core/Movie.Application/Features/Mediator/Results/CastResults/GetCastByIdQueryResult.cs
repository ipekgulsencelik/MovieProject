using Movie.Domain.Entities.Enum;

namespace Movie.Application.Features.Mediator.Results.CastResults
{
    public class GetCastByIdQueryResult
    {
        public int Id { get; set; }
        public DataStatus DataStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }

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