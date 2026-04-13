using System.Collections.Generic;
using System.Threading.Tasks;
using HerzingProjectTemplate.Models;
using HerzingProjectTemplate.Data;
using Microsoft.EntityFrameworkCore;

namespace HerzingProjectTemplate.Repositories
{
    public class NutritionRepository : INutritionRepository
    {
        private readonly ApplicationDbContext2 _context;

        public NutritionRepository(ApplicationDbContext2 context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Nutrition>> GetAllAsync() =>
            await _context.Nutritions.ToListAsync();

        public async Task<Nutrition?> GetByIdAsync(int id) =>
            await _context.Nutritions.FindAsync(id);

        public async Task AddAsync(Nutrition nutrition)
        {
            _context.Nutritions.Add(nutrition);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Nutrition nutrition)
        {
            _context.Update(nutrition);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var nutrition = await _context.Nutritions.FindAsync(id);
            if (nutrition != null)
            {
                _context.Nutritions.Remove(nutrition);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id) =>
            await _context.Nutritions.AnyAsync(e => e.NutritionId == id);
    }
}