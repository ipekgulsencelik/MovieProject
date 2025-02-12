using Microsoft.EntityFrameworkCore;
using Movie.Application.Interfaces;
using Movie.Persistence.Context;
using System.Linq.Expressions;

namespace Movie.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
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
            var value = await GetByIdAsync(id);
            _context.Remove(value);
            await _context.SaveChangesAsync();
        }

        public async Task<T> GetByFilterAsync(Expression<Func<T, bool>> predicate)
        {
            return await Table.Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await Table.FindAsync(id);
        }

        public async Task<List<T>> GetFilteredListAsync(Expression<Func<T, bool>> predicate)
        {
            return await Table.Where(predicate).ToListAsync();
        }

        public async Task<List<T>> GetListAsync()
        {
            return await Table.ToListAsync();
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

        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        Task IRepository<T>.GetByFilterAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}