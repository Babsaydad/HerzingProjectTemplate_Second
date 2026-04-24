using HerzingProjectTemplate.Models;

namespace HerzingProjectTemplate.Repositories
{
    public interface IProgressRepository
    {
        Task<IEnumerable<Progress>> GetAllAsync();

        Task<Progress?> GetByIdWithNutritionWorkoutAsync(int id);
        //Task<Progress?> GetByEmailAsync(string email);
        Task<Progress?> GetByIdAsync(int id);

        //Task<Progress?> GetUserIdAsync(int id);
        Task AddAsync(Progress progress);
        Task UpdateAsync(Progress progress);
        Task DeleteAsync(int id);
        Task<IEnumerable<Progress>> GetByUserIdAsync(int userId);
    }
}
