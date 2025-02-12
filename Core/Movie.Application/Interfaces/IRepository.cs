using System.Linq.Expressions;

namespace Movie.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetListAsync();
        Task<List<T>> GetFilteredListAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetByIdAsync(int id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<bool> SaveChangesAsync();
        Task GetByFilterAsync(Expression<Func<T, bool>> predicate);
    }
}
