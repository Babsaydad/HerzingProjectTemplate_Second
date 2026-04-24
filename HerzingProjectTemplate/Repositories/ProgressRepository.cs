using HerzingProjectTemplate.Models;
using Microsoft.EntityFrameworkCore;
using HerzingProjectTemplate.Data;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace HerzingProjectTemplate.Repositories
{
    public class ProgressRepository : IProgressRepository
    {
        private readonly ApplicationDbContext2 _context;

        public ProgressRepository(ApplicationDbContext2 context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Progress>> GetAllAsync()
        {
            return await _context.Progresses
                .Include(u => u.WorkOuts)
                .Include(u => u.Nutritions)
                .OrderByDescending(p => p.ProgressDate)
                .ToListAsync();
        }

        public async Task<Progress?> GetByIdWithNutritionWorkoutAsync(int id)
        {
            return await _context.Progresses
                .Include(u => u.WorkOuts)
                .Include(u => u.Nutritions)
                .FirstOrDefaultAsync(u => u.UserId == id);
        }
        public async Task<Progress?> GetByIdAsync(int id)
        {
            return await _context.Progresses
                .FirstOrDefaultAsync(p => p.ProgressId == id);
        }

        //This selects only the user that signs in
        public async Task<int?> GetUserIdAsync(int id)
        {
            return await _context.Progresses
                .Where(u => u.UserId == id)
                .Select(u => u.UserId) // Only pulls the ID column
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Progress>> GetByUserIdAsync(int userId)
        {
            return await _context.Progresses
                .Where(p => p.UserId == userId)
                .OrderByDescending(p => p.ProgressDate)
                .ToListAsync();
        }

        public async Task AddAsync(Progress progress)
        {
            _context.Progresses.Add(progress);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Progress progress)
        {
            _context.Progresses.Update(progress);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var progress = await GetByIdAsync(id);
            if (progress != null)
            {
                _context.Progresses.Remove(progress);
                await _context.SaveChangesAsync();
            }
        }
    }
}

