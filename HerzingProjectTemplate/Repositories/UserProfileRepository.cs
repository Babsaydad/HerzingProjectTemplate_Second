using HerzingProjectTemplate.Data;
using HerzingProjectTemplate.Models;
using Microsoft.EntityFrameworkCore;
//using System.Threading.Tasks;
//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;

namespace HerzingProjectTemplate.Repositories
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly ApplicationDbContext2 _context;

        public UserProfileRepository(ApplicationDbContext2 context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserProfile>> GetAllAsync() =>
           await _context.UserProfiles.ToListAsync();

        public async Task<UserProfile?> GetByIdWithNutritionWorkoutAsync(int id)
        {
            // Inside the repository, you have access to the DbContext
            return await _context.UserProfiles
                .Include(u => u.WorkOuts)
                .Include(u => u.Nutritions)
                .FirstOrDefaultAsync(u => u.UserId == id);
        }

        public async Task<UserProfile?> GetByIdAsync(int id)
        {
            return await _context.UserProfiles
                .Include(u => u.Nutritions) // This joins the tables
                .FirstOrDefaultAsync(u => u.UserId == id);
        }
            //await _context.UserProfiles.FindAsync(id);

        public async Task<UserProfile?> GetByEmailAsync(string email) =>
            await _context.UserProfiles.FirstOrDefaultAsync(u => u.Email == email);
        public async Task AddAsync(UserProfile profile)
        {
            _context.UserProfiles.Add(profile);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UserProfile profile)
        {
            _context.Update(profile);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var profile = await _context.UserProfiles.FindAsync(id);
            if (profile != null)
            {
                _context.UserProfiles.Remove(profile);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id) =>
            await _context.UserProfiles.AnyAsync(e => e.UserId == id);
    }
}
