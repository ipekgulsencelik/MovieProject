using Movie.Domain.Entities.Abstract;
using Movie.Domain.Entities.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie.Domain.Entities
{
    public class Series : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string? CoverImageUrl { get; set; }
        public string? Description { get; set; }

        public DateTime FirstAirDate { get; set; }

        [NotMapped]
        public int FirstAirYear => FirstAirDate.Year;

        [Range(0, 10)]
        public decimal Rating { get; set; } = 0m;

        [Range(0, int.MaxValue)]
        public int SeasonCount { get; set; }

        [Range(0, int.MaxValue)]
        public int EpisodeCount { get; set; }

        [Range(0, int.MaxValue)]
        public int? AverageEpisodeDuration { get; set; }

        public SeriesStatus SeriesStatus { get; set; } = SeriesStatus.Ongoing;
        public SeriesStatus? PreviousStatus { get; set; }

        public virtual ICollection<Category> Categories { get; set; } = new HashSet<Category>();
    }
}