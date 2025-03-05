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

        public async Task<List<Category>> GetVisibleCategoriesAsync()
        {
            return await _context.Categories.Where(c => c.IsActive && c.IsVisible).ToListAsync();
        }

        public async Task HideCategoryAsync(int id)
        {
            var value = await _context.Categories.FindAsync(id);

            if (value == null)
            {
                throw new KeyNotFoundException($"Category with ID {id} not found.");
            }

            if (value.IsActive && value.IsVisible)
            {
                value.IsVisible = false;
                await _context.SaveChangesAsync();
            }
        }

        public async Task ShowCategoryAsync(int id)
        {
            var value = await _context.Categories.FindAsync(id);

            if (value == null)
            {
                throw new KeyNotFoundException($"Category with ID {id} not found.");
            }

            if (value.IsActive && !value.IsVisible)
            {
                value.IsVisible = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task ToggleCategoryStatusAsync(int id)
        {
            var value = await _context.Categories.FindAsync(id);

            if (value == null)
            {
                throw new KeyNotFoundException($"Category with ID {id} not found.");
            }

            value.IsActive = !value.IsActive;

            if (!value.IsActive) 
            {
                value.IsVisible = false;
            }

            await _context.SaveChangesAsync(); 
        }
    }
}