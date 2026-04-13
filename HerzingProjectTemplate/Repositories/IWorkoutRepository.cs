using System.Collections.Generic;
using System.Threading.Tasks;
using HerzingProjectTemplate.Models;

namespace HerzingProjectTemplate.Repositories
{
    public interface IWorkoutRepository
    {
        Task<IEnumerable<WorkOut>> GetAllAsync();
        Task<WorkOut?> GetByIdAsync(int id);
        Task AddAsync(WorkOut workout);
        Task CreateRangeAsync(IEnumerable<WorkOut> entities);
        Task UpdateAsync(WorkOut workout);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
