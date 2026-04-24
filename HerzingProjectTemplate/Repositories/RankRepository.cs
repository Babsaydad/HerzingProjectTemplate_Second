using HerzingProjectTemplate.Data;
using HerzingProjectTemplate.Models;
using HerzingProjectTemplate.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HerzingProjectTemplate.Repositories
{
    public class RankRepository : IRankRepository
    {
        private readonly ApplicationDbContext2 _context;

        public RankRepository(ApplicationDbContext2 context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Rank>> GetAllAsync()
        {
            return await _context.Ranks
                .OrderBy(r => r.Category)
                .ThenBy(r => r.MinValue)
                .ToListAsync();
        }

        public async Task<Rank?> GetByIdAsync(int id)
        {
            return await _context.Ranks.FindAsync(id);
        }

        public async Task<IEnumerable<Rank>> GetByCategoryAsync(string category)
        {
            return await _context.Ranks
                .Where(r => r.Category == category)
                .OrderBy(r => r.MinValue)
                .ToListAsync();
        }

        public async Task<Rank?> GetRankForValueAsync(string category, int value)
        {
            return await _context.Ranks
                .Where(r => r.Category == category &&
                            value >= r.MinValue &&
                            value <= r.MaxValue)
                .FirstOrDefaultAsync();
        }

        public async Task AddAsync(Rank rank)
        {
            _context.Ranks.Add(rank);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Rank rank)
        {
            _context.Ranks.Update(rank);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var rank = await _context.Ranks.FindAsync(id);
            if (rank != null)
            {
                _context.Ranks.Remove(rank);
                await _context.SaveChangesAsync();
            }
        }
    }
}



