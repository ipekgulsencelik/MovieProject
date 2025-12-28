using Movie.Domain.Entities.Abstract;
using System.Data.Entity;
using System.Linq.Expressions;

namespace Movie.Application.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }

        Task<List<T>> GetListAsync();                     // Deleted hariç (standart liste)
        Task<List<T>> GetActiveAsync();                   // Deleted hariç + IsActive = true
        Task<List<T>> GetVisibleAsync();                  // Deleted hariç + IsActive = true + IsVisible = true

        Task<T> GetByIdAsync(int id);                     // Deleted hariç
        Task<T?> GetByIdIncludingDeletedAsync(int id);    // Deleted dahil

        Task<T?> GetByFilterAsync(Expression<Func<T, bool>> predicate);
        Task<List<T>> GetListByFilterAsync(Expression<Func<T, bool>> predicate);

        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);

        Task DeleteAsync(int id);                         // Soft delete (DataStatus=Deleted)
        Task RemoveAsync(T entity);                       // Hard delete (Remove)

        Task ShowAsync(int id);                           // IsVisible = true
        Task HideAsync(int id);                           // IsVisible = false
        Task ToggleStatusAsync(int id);                   // IsActive toggle

        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, bool includeDeleted = true);

        Task<bool> SaveChangesAsync();
    }
}