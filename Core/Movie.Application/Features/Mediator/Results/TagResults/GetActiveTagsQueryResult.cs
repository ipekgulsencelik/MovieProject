using Movie.Domain.Entities.Enum;

namespace Movie.Application.Features.Mediator.Results.TagResults
{
    public class GetActiveTagsQueryResult
    {
        public int Id { get; set; }
        public DataStatus DataStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }

        public string Title { get; set; }
        public bool IsVisible { get; set; }
        public bool IsActive { get; set; }
    }
}
