using Movie.Domain.Entities;

namespace Movie.Application.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task ToggleCategoryStatusAsync(int id);
        Task HideCategoryAsync(int id);
        Task<List<Category>> GetActiveCategoriesAsync();
        Task<List<Category>> GetVisibleCategoriesAsync();
        Task ShowCategoryAsync(int id);
    }
}