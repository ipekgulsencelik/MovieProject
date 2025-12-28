using Movie.Domain.Entities.Enum;
using System.ComponentModel.DataAnnotations;

namespace Movie.DTO.DTOs.MovieDTOs
{
    public class CreateMovieDTO
    {
        [Required(ErrorMessage = "Film adı zorunludur.")]
        [StringLength(150, MinimumLength = 2)]
        public string Title { get; set; } = string.Empty;

        [Url]
        public string? CoverImageUrl { get; set; }

        [Range(0, 10)]
        public decimal Rating { get; set; } = 0;

        public string? Description { get; set; }

        [Range(1, 600)]
        public int Duration { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; } = DateTime.Today;

        public MovieStatus MovieStatus { get; set; } = MovieStatus.InStock;

        [MinLength(1, ErrorMessage = "En az bir kategori seçmelisiniz.")]
        public List<int> CategoryIds { get; set; } = new();
    }
}