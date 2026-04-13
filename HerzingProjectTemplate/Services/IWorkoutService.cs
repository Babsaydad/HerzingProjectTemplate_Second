using System.Collections.Generic;
using System.Threading.Tasks;
using HerzingProjectTemplate.Models;

namespace HerzingProjectTemplate.Services
{
    public interface IWorkoutService
    {
        Task<IEnumerable<WorkOut>> GetAllAsync();
        Task<WorkOut?> GetByIdAsync(int id);
        Task CreateAsync(WorkOut workout);
        Task CreateRangeAsync(IEnumerable<WorkOut> workouts);
        Task UpdateAsync(WorkOut workout);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
