using HerzingProjectTemplate.Models;

namespace HerzingProjectTemplate.Repositories
{
    public interface IRankRepository
    {
        Task<IEnumerable<Rank>> GetAllAsync();
        Task<Rank?> GetByIdAsync(int id);
        Task<IEnumerable<Rank>> GetByCategoryAsync(string category);
        Task<Rank?> GetRankForValueAsync(string category, int value);
        Task AddAsync(Rank rank);
        Task UpdateAsync(Rank rank);
        Task DeleteAsync(int id);
    }
}