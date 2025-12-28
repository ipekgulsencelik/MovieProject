using Movie.Domain.Entities;

namespace Movie.Application.Interfaces
{
    public interface IMovieRepository : IRepository<Film>
    {
        Task<Film?> GetByIdWithCategories(int id);
        Task<List<Film>> GetAllWithCategories();
    }
}