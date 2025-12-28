using Microsoft.EntityFrameworkCore;
using Movie.Application.Interfaces;
using Movie.Domain.Entities.Abstract;
using Movie.Domain.Entities.Enum;
using Movie.Persistence.Context;
using Movie.Persistence.Extensions;
using System.Linq.Expressions;

namespace Movie.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly MovieContext _context;
        protected readonly DbSet<T> _set;

        public Repository(MovieContext context)
        {
            _context = context;
            _set = _context.Set<T>();
        }

        public DbSet<T> Table => _set;

        // Soft-deleted olmayanlar için ortak query (standart)
        protected IQueryable<T> Query => _set.Where(x => x.DataStatus != DataStatus.Deleted);

        System.Data.Entity.DbSet<T> IRepository<T>.Table => throw new NotImplementedException();

        public async Task CreateAsync(T entity)
        {
            await _set.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        // Soft delete by id
        public async Task DeleteAsync(int id)
        {
            var entity = await _set.FindAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"{typeof(T).Name} with ID {id} was not found.");

            if (entity.DataStatus == DataStatus.Deleted)
                return;

            entity.DataStatus = DataStatus.Deleted;
            entity.DeletedDate = DateTime.UtcNow;
            entity.ModifiedDate = DateTime.UtcNow;
            entity.IsActive = false;
            entity.IsVisible = false;

            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetListAsync()
        {
            return await Query.AsNoTracking().ToListAsync();
        }

        public async Task<List<T>> GetActiveAsync()
        {
            return await Query.AsNoTracking()
                              .Where(x => x.IsActive)
                              .ToListAsync();
        }

        public async Task<List<T>> GetVisibleAsync()
        {
            return await Query.AsNoTracking()
                              .Where(x => x.IsActive && x.IsVisible)
                              .ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await Query.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
                throw new KeyNotFoundException($"{typeof(T).Name} with ID {id} not found or deleted.");

            return entity;
        }

        public async Task<T?> GetByIdIncludingDeletedAsync(int id)
        {
            return await _set.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<T?> GetByFilterAsync(Expression<Func<T, bool>> predicate)
        {
            return await Query.AsNoTracking().FirstOrDefaultAsync(predicate);
        }

        public async Task<List<T>> GetListByFilterAsync(Expression<Func<T, bool>> predicate)
        {
            return await Query.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task ShowAsync(int id)
        {
            var entity = await Query.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
                throw new KeyNotFoundException($"{typeof(T).Name} with ID {id} not found.");

            if (entity.CanBeShown())
            {
                entity.IsVisible = true;
                entity.ModifiedDate = DateTime.UtcNow;
                entity.DataStatus = DataStatus.Updated;
                await _context.SaveChangesAsync();
            }
        }

        public async Task HideAsync(int id)
        {
            var entity = await Query.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
                throw new KeyNotFoundException($"{typeof(T).Name} with ID {id} not found.");

            if (entity.CanBeHidden())
            {
                entity.IsVisible = false;
                entity.ModifiedDate = DateTime.UtcNow;
                entity.DataStatus = DataStatus.Updated;
                await _context.SaveChangesAsync();
            }
        }

        public async Task ToggleStatusAsync(int id)
        {
            var entity = await Query.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
                throw new KeyNotFoundException($"{typeof(T).Name} with ID {id} not found.");

            entity.IsActive = !entity.IsActive;
            if (!entity.IsActive)
                entity.IsVisible = false;

            entity.ModifiedDate = DateTime.UtcNow;
            entity.DataStatus = DataStatus.Updated;

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            var dbEntity = await Query.FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (dbEntity == null)
                throw new KeyNotFoundException($"{typeof(T).Name} with ID {entity.Id} was not found.");

            // DB'deki CreatedDate/DeletedDate gibi alanları yanlışlıkla ezmemek için sakla
            var createdDate = dbEntity.CreatedDate;
            var deletedDate = dbEntity.DeletedDate;
            var dataStatus = dbEntity.DataStatus;

            // Yeni değerleri uygula
            _context.Entry(dbEntity).CurrentValues.SetValues(entity);

            // Sistem alanlarını geri sabitle
            dbEntity.CreatedDate = createdDate;
            dbEntity.DeletedDate = deletedDate;      // silinmişse silinmiş kalsın
            dbEntity.DataStatus = DataStatus.Updated;
            dbEntity.ModifiedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(T entity)
        {
            if (entity == null) return;

            if (_context.Entry(entity).State == EntityState.Detached)
                _set.Attach(entity);

            _set.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, bool includeDeleted = true)
        {
            return includeDeleted
                ? await _set.AsNoTracking().AnyAsync(predicate)
                : await Query.AsNoTracking().AnyAsync(predicate);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}