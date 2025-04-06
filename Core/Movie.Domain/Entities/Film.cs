using Movie.Domain.Entities.Abstract;
using Movie.Domain.Entities.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie.Domain.Entities
{
    public class Film : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string? CoverImageUrl { get; set; }

        [Range(0, 10)]
        public decimal Rating { get; set; } = 0m;

        public string? Description { get; set; } 
        public int Duration { get; set; } 
        public DateTime ReleaseDate { get; set; }

        [NotMapped]
        public int ReleaseYear => ReleaseDate.Year;

        public MovieStatus MovieStatus { get; set; } = MovieStatus.InStock;

        public virtual ICollection<Category> Categories { get; set; } = new HashSet<Category>();
        public virtual ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
    }
}