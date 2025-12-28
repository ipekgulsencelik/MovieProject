using Movie.Domain.Entities;

namespace Movie.Application.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<List<Category>> GetByIds(List<int> ids);
        Task<bool> AreAllIdsExist(List<int> ids);
        Task<List<Category>> GetActiveCategories();
        Task<List<Category>> GetVisibleCategories();
        Task<List<Category>> GetArchivedCategories();
        Task<List<Category>> GetListWithFilms();
        Task<Category?> GetByIdWithFilms(int id);
    }
}