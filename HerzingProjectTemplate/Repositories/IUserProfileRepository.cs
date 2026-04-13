using HerzingProjectTemplate.Models;
//using System.Collections.Generic;
//using System.Threading.Tasks;

namespace HerzingProjectTemplate.Repositories
{
    public interface IUserProfileRepository
    {
        Task<IEnumerable<UserProfile>> GetAllAsync();
        Task<UserProfile?> GetByIdAsync(int id);
        Task<UserProfile?> GetByEmailAsync(string email);
        Task AddAsync(UserProfile profile);
        Task UpdateAsync(UserProfile profile);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<UserProfile?> GetByIdWithNutritionWorkoutAsync(int id);
    }
}
