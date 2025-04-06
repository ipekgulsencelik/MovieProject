using System.Linq.Expressions;

namespace Movie.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetListAsync();  // Tüm öğeleri al
        Task<List<T>> GetActiveAsync();  // Sadece aktif öğeleri al
        Task<List<T>> GetVisibleAsync();  // Sadece görünür öğeleri al
        Task<List<T>> GetListByFilterAsync(Expression<Func<T, bool>> predicate); 
        Task<T> GetByIdAsync(int id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id); // soft delete
        Task ShowAsync(int id);   // IsVisible = true
        Task HideAsync(int id);   // IsVisible = false
        Task ToggleStatusAsync(int id);
        Task<bool> SaveChangesAsync();
        Task<T> GetByFilterAsync(Expression<Func<T, bool>> predicate);
    }
}