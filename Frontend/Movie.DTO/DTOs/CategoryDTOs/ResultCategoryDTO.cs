using Movie.Domain.Entities.Enum;

namespace Movie.DTO.DTOs.CategoryDTOs
{
    public class ResultCategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int DisplayOrder { get; set; }

        public int MovieCount { get; set; }
        public int ReviewCount { get; set; }
        public double AvgRating { get; set; }

        public CategoryStatus CategoryStatus { get; set; }
    }
}
