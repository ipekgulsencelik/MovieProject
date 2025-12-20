using Movie.Domain.Entities.Enum;
using System.ComponentModel.DataAnnotations;

namespace Movie.DTO.DTOs.CategoryDTOs
{
    public class UpdateCategoryDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public int DisplayOrder { get; set; } = 0;

        public CategoryStatus CategoryStatus { get; set; } = CategoryStatus.Active;
    }
}