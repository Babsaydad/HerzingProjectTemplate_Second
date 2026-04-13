using System.Collections.Generic;
using System.Threading.Tasks;
using HerzingProjectTemplate.Models;
using HerzingProjectTemplate.Data;
using Microsoft.EntityFrameworkCore;

namespace HerzingProjectTemplate.Repositories
{
    public class WorkoutRepository : IWorkoutRepository
    {
        private readonly ApplicationDbContext2 _context;
        public WorkoutRepository(ApplicationDbContext2 context)
        {
            _context = context;
        }


        public async Task<IEnumerable<WorkOut>> GetAllAsync() =>
            await _context.WorkOuts.ToListAsync();

        public async Task<WorkOut?> GetByIdAsync(int id) =>
            await _context.WorkOuts.FindAsync(id);

        public async Task AddAsync(WorkOut workout)
        {
            _context.WorkOuts.Add(workout);
            await _context.SaveChangesAsync();
        }

        public async Task CreateRangeAsync(IEnumerable<WorkOut> entities)
        {
            // AddRangeAsync is optimized for large batches by reducing change detection overhead
            await _context.WorkOuts.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateAsync(WorkOut workout)
        {
            _context.Update(workout);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var workout = await _context.WorkOuts.FindAsync(id);
            if (workout != null)
            {
                _context.WorkOuts.Remove(workout);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id) =>
            await _context.WorkOuts.AnyAsync(e => e.WorkoutId == id);
    }
}
