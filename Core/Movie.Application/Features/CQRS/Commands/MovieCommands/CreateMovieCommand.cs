using Movie.Domain.Entities.Enum;
using System.ComponentModel.DataAnnotations;

namespace Movie.Application.Features.CQRS.Commands.MovieCommands
{
    public class CreateMovieCommand
    {
        [Required]
        [StringLength(150, MinimumLength = 2)]
        public string Title { get; set; } = string.Empty;

        [Url]
        public string? CoverImageUrl { get; set; }

        [Range(0, 10)]
        public decimal Rating { get; set; }

        public string? Description { get; set; }

        [Range(1, 600)]
        public int Duration { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        public MovieStatus MovieStatus { get; set; } = MovieStatus.InStock;

        [MinLength(1)]
        public List<int> CategoryIds { get; set; } = new();
    }
}