using Movie.Domain.Entities.Enum;
using System.ComponentModel.DataAnnotations;

namespace Movie.DTO.DTOs.CategoryDTOs
{
    public class CreateCategoryDTO
    {
        [Required(ErrorMessage = "Kategori adı zorunludur.")]
        [StringLength(60, ErrorMessage = "Kategori adı en fazla 60 karakter olmalıdır.")]
        public string Name { get; set; } = string.Empty;

        [StringLength(250, ErrorMessage = "Açıklama en fazla 250 karakter olmalıdır.")]
        public string? Description { get; set; }

        [Range(0, 9999, ErrorMessage = "Sıra 0 ile 9999 arasında olmalıdır.")]
        public int DisplayOrder { get; set; } = 0;

        public CategoryStatus CategoryStatus { get; set; } = CategoryStatus.Pending;
    }
}