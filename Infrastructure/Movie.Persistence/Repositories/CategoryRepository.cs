using Microsoft.EntityFrameworkCore;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;
using Movie.Domain.Entities.Enum;
using Movie.Persistence.Context;

namespace Movie.Persistence.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(MovieContext context) : base(context)
        {
        }

        public async Task<List<Category>> GetByIds(List<int> ids)
        {
            ids ??= new List<int>();

            var distinctIds = ids
                .Where(x => x > 0)
                .Distinct()
                .ToList();

            if (distinctIds.Count == 0)
                return new List<Category>();

            return await Table
                .AsNoTracking()
                .Where(c => distinctIds.Contains(c.Id))
                .ToListAsync();
        }

        public async Task<bool> AreAllIdsExist(List<int> ids)
        {
            ids ??= new List<int>();

            var distinctIds = ids
                .Where(x => x > 0)
                .Distinct()
                .ToList();

            // ✅ Repository semantiği:
            // Kontrol edilecek ID yoksa => "hepsi mevcut" kabul edilir
            if (distinctIds.Count == 0)
                return true;

            var count = await Table
                .AsNoTracking()
                .CountAsync(c => distinctIds.Contains(c.Id));

            return count == distinctIds.Count;
        }

        public async Task<List<Category>> GetActiveCategories()
        {
            return await Table
                .AsNoTracking()
                .Where(x => x.CategoryStatus == CategoryStatus.Active)
                .OrderBy(x => x.DisplayOrder)
                .ThenBy(x => x.Name)
                .ToListAsync();
        }

        public async Task<List<Category>> GetVisibleCategories()
        {
            // Şu anki kabul: Active = Visible
            return await Table
                .AsNoTracking()
                .Where(x => x.CategoryStatus == CategoryStatus.Active)
                .OrderBy(x => x.DisplayOrder)
                .ThenBy(x => x.Name)
                .ToListAsync();
        }

        public async Task<List<Category>> GetArchivedCategories()
        {
            return await Table
                .AsNoTracking()
                .Where(x => x.CategoryStatus == CategoryStatus.Archived)
                .OrderBy(x => x.DisplayOrder)
                .ThenBy(x => x.Name)
                .ToListAsync();
        }

        public async Task<List<Category>> GetListWithFilms()
        {
            return await Table
                .AsNoTracking()
                .Include(x => x.Films)
                .OrderBy(x => x.DisplayOrder)
                .ThenBy(x => x.Name)
                .ToListAsync();
        }

        public async Task<Category?> GetByIdWithFilms(int id)
        {
            if (id <= 0)
                return null;

            return await Table
                .AsNoTracking()
                .Include(x => x.Films)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}