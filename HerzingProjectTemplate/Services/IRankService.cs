using HerzingProjectTemplate.Models;

namespace HerzingProjectTemplate.Services
{
    public interface IRankService
    {
        Task<IEnumerable<Rank>> GetAllRanksAsync();
        Task<Rank?> GetRankByIdAsync(int id);
        Task<IEnumerable<Rank>> GetRanksByCategoryAsync(string category);
        Task<Rank?> DetermineUserRankAsync(string category, int value);
        Task AddRankAsync(Rank rank);
        Task UpdateRankAsync(Rank rank);
        Task DeleteRankAsync(int id);
    }
}
