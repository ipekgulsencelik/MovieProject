using Microsoft.EntityFrameworkCore;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;
using Movie.Domain.Entities.Enum;
using Movie.Persistence.Context;

namespace Movie.Persistence.Repositories
{
    public class SeriesRepository : Repository<Series>, ISeriesRepository
    {
        public SeriesRepository(MovieContext context) : base(context)
        {
        }

        public async Task<Series?> GetByIdWithCategories(int id)
        {
            return await _context.Series
                .Include(x => x.Categories)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Series>> GetPublished()
        {
            return await _context.Series
                .Where(x =>
                    x.IsActive &&
                    x.IsVisible &&
                    x.DataStatus != DataStatus.Deleted &&
                    x.SeriesStatus != SeriesStatus.Archived)
                .ToListAsync();
        }

        public async Task<List<Series>> GetPending()
        {
            return await _context.Series
                .Where(x => x.SeriesStatus == SeriesStatus.Archived)
                .ToListAsync();
        }

        public async Task<List<Series>> GetIncludingDeleted()
        {
            return await _context.Series
                .IgnoreQueryFilters()
                .ToListAsync();
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.Series.AnyAsync(x => x.Id == id);
        }

        public async Task<List<Series>> SearchAsync(string? q, SeriesStatus? status, decimal? minRating, decimal? maxRating, DateTime? fromFirstAirDate, DateTime? toFirstAirDate, int page, int pageSize)
        {
            q = (q ?? string.Empty).Trim();
            page = page <= 0 ? 1 : page;
            pageSize = pageSize <= 0 ? 20 : pageSize;

            var queryable = _context.Series.AsQueryable();

            queryable = queryable.Where(x => x.DataStatus != DataStatus.Deleted);

            if (!string.IsNullOrEmpty(q))
                queryable = queryable.Where(x => x.Title.Contains(q));

            if (status.HasValue)
                queryable = queryable.Where(x => x.SeriesStatus == status.Value);

            if (minRating.HasValue)
                queryable = queryable.Where(x => x.Rating >= minRating.Value);

            if (maxRating.HasValue)
                queryable = queryable.Where(x => x.Rating <= maxRating.Value);

            if (fromFirstAirDate.HasValue)
                queryable = queryable.Where(x => x.FirstAirDate >= fromFirstAirDate.Value);

            if (toFirstAirDate.HasValue)
                queryable = queryable.Where(x => x.FirstAirDate <= toFirstAirDate.Value);

            return await queryable
                .OrderByDescending(x => x.FirstAirDate)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<List<Series>> GetByCategory(int categoryId, bool published, int page, int pageSize)
        {
            page = page <= 0 ? 1 : page;
            pageSize = pageSize <= 0 ? 20 : pageSize;

            var query = _context.Series
                .Where(s => s.DataStatus != DataStatus.Deleted)
                .Where(s => s.Categories.Any(c => c.Id == categoryId));

            if (published)
            {
                query = query.Where(s =>
                    s.IsActive &&
                    s.IsVisible &&
                    s.SeriesStatus != SeriesStatus.Archived);
            }

            return await query.OrderByDescending(s => s.FirstAirDate).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<List<Series>> GetSeriesByCategory(int categoryId, int page, int pageSize)
        {
            page = page <= 0 ? 1 : page;
            pageSize = pageSize <= 0 ? 50 : pageSize;

            return await _context.Series
                .Where(s => s.Categories.Any(c => c.Id == categoryId))
                .OrderByDescending(s => s.FirstAirDate)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}