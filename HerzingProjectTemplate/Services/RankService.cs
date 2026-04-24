using HerzingProjectTemplate.Models;
using HerzingProjectTemplate.Repositories;

namespace HerzingProjectTemplate.Services
{
    public class RankService : IRankService
    {
        private readonly IRankRepository _rankRepository;

        public RankService(IRankRepository rankRepository)
        {
            _rankRepository = rankRepository;
        }

        public async Task<IEnumerable<Rank>> GetAllRanksAsync()
        {
            return await _rankRepository.GetAllAsync();
        }

        public async Task<Rank?> GetRankByIdAsync(int id)
        {
            return await _rankRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Rank>> GetRanksByCategoryAsync(string category)
        {
            return await _rankRepository.GetByCategoryAsync(category);
        }

        public async Task<Rank?> DetermineUserRankAsync(string category, int value)
        {
            return await _rankRepository.GetRankForValueAsync(category, value);
        }

        public async Task AddRankAsync(Rank rank)
        {
            await _rankRepository.AddAsync(rank);
        }

        public async Task UpdateRankAsync(Rank rank)
        {
            await _rankRepository.UpdateAsync(rank);
        }

        public async Task DeleteRankAsync(int id)
        {
            await _rankRepository.DeleteAsync(id);
        }
    }
}
