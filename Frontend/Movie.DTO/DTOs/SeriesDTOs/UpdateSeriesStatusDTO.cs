using Movie.Domain.Entities.Enum;

namespace Movie.DTO.DTOs.SeriesDTOs
{
    public class UpdateSeriesStatusDTO
    {
        public int Id { get; set; }
        public SeriesStatus SeriesStatus { get; set; }
    }
}