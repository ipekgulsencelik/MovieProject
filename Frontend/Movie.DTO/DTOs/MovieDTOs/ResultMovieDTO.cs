using Movie.Domain.Entities.Enum;

namespace Movie.DTO.DTOs.MovieDTOs
{
    public class ResultMovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CoverImageUrl { get; set; }
        public decimal Rating { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public DateTime ReleaseDate { get; set; }
        public MovieStatus MovieStatus { get; set; }
    }
}