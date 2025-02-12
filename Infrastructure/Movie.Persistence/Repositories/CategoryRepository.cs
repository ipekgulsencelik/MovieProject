using Microsoft.EntityFrameworkCore;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;
using Movie.Persistence.Context;

namespace Movie.Persistence.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(MovieContext context) : base(context)
        {
        }

        public async Task<List<Category>> GetActiveCategoriesAsync()
        {
            return await _context.Categories.Where(c => c.IsActive).ToListAsync();
        }

        public Task<List<Category>> GetVisibleCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task HideCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task ShowCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task ToggleCategoryStatusAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}