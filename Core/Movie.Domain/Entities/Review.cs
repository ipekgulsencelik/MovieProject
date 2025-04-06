using Movie.Domain.Entities.Abstract;
using Movie.Domain.Entities.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie.Domain.Entities
{
    public class Review : BaseEntity
    {
        public string? Comment { get; set; }

        [Range(0, 10)]
        public decimal Rating { get; set; }

        public DateTime ReviewDate { get; set; } = DateTime.UtcNow;
        public ReviewStatus ReviewStatus { get; set; } = ReviewStatus.Pending;

        public int FilmId { get; set; }

        [ForeignKey(nameof(FilmId))]
        public virtual Film Film { get; set; } = null!;
    }
}