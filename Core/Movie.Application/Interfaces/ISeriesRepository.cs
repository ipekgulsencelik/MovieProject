using Movie.Domain.Entities;
using Movie.Domain.Entities.Enum;

namespace Movie.Application.Interfaces
{
    public interface ISeriesRepository : IRepository<Series>
    {
        Task<Series?> GetByIdWithCategories(int id);
        Task<List<Series>> GetPublished();
        Task<List<Series>> GetPending();
        Task<List<Series>> GetIncludingDeleted();
        Task<bool> Exists(int id);
        Task<List<Series>> GetSeriesByCategory(int categoryId, int page, int pageSize);

        Task<List<Series>> GetByCategory(int categoryId, bool published, int page, int pageSize);
        Task<List<Series>> SearchAsync(string? q, SeriesStatus? status, decimal? minRating, decimal? maxRating, DateTime? fromFirstAirDate, DateTime? toFirstAirDate, int page, int pageSize);
    }
}