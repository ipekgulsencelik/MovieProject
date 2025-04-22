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

        public Repository(MovieContext context)
        {
            _context = context;
        }

        public DbSet<T> Table { get => _context.Set<T>(); }

        public async Task CreateAsync(T entity)
        {
            await Table.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var value = await Table.FindAsync(id);
            if (value == null)
                throw new KeyNotFoundException($"{typeof(T).Name} with ID {id} was not found.");

            if (value.DataStatus == DataStatus.Deleted)
                return;

            value.DataStatus = DataStatus.Deleted;
            value.DeletedDate = DateTime.UtcNow;
            value.IsActive = false;
            value.IsVisible = false;

            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetActiveAsync()
        {
            return await Table.Where(x => x.IsActive).ToListAsync();
        }

        public async Task<T> GetByFilterAsync(Expression<Func<T, bool>> predicate)
        {
            return await Table.Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await Table.FindAsync(id);
            if (entity == null || entity.DataStatus == DataStatus.Deleted)
                throw new KeyNotFoundException($"{typeof(T).Name} with ID {id} not found or deleted.");

            return entity;
        }

        public async Task<List<T>> GetListAsync()
        {
            return await Table.Where(x => x.DataStatus != DataStatus.Deleted).ToListAsync();
        }

        public async Task<List<T>> GetListByFilterAsync(Expression<Func<T, bool>> predicate)
        {
            return await Table.Where(predicate).ToListAsync();
        }

        public async Task<List<T>> GetVisibleAsync()
        {
            return await Table.Where(x => x.IsActive && x.IsVisible).ToListAsync();
        }

        public async Task HideAsync(int id)
        {
            var entity = await Table.FindAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"{typeof(T).Name} with ID {id} not found.");

            if (entity.CanBeHidden())
            {
                entity.IsVisible = false;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return true;
            }
            return false;
        }

        public async Task ShowAsync(int id)
        {
            var entity = await Table.FindAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"{typeof(T).Name} with ID {id} not found.");

            if (entity.CanBeShown())
            {
                entity.IsVisible = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task ToggleStatusAsync(int id)
        {
            var entity = await Table.FindAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"{typeof(T).Name} with ID {id} not found.");

            entity.IsActive = !entity.IsActive;
            if (!entity.IsActive)
            {
                entity.IsVisible = false;
            }

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            var value = await Table.FindAsync(entity.Id);
            if (value == null)
                throw new KeyNotFoundException($"{typeof(T).Name} with ID {entity.Id} was not found.");

            entity.DataStatus = DataStatus.Modified;
            entity.ModifiedDate = DateTime.UtcNow;

            _context.Entry(value).CurrentValues.SetValues(entity);

            await _context.SaveChangesAsync();
        }
    }
}