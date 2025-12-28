using Microsoft.EntityFrameworkCore;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;
using Movie.Persistence.Context;

namespace Movie.Persistence.Repositories
{
    public class MovieRepository : Repository<Film>, IMovieRepository
    {
        public MovieRepository(MovieContext context) : base(context) { }

        public async Task<Film?> GetByIdWithCategories(int id)
        {
            return await Table
                .Include(x => x.Categories)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Film>> GetAllWithCategories()
        {
            return await Table
                .Include(x => x.Categories)
                .ToListAsync();
        }
    }
}