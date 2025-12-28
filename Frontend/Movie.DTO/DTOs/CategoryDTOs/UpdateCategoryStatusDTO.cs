using Movie.Domain.Entities.Enum;

namespace Movie.DTO.DTOs.CategoryDTOs
{
    public class UpdateCategoryStatusDTO
    {
        public int Id { get; set; }
        public CategoryStatus CategoryStatus { get; set; }
    }
}