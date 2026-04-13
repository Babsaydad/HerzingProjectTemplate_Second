using System.Collections.Generic;
using System.Threading.Tasks;
using HerzingProjectTemplate.Models;

namespace HerzingProjectTemplate.Services
{
    public interface INutritionService
    {
        Task<IEnumerable<Nutrition>> GetAllAsync();
        Task<Nutrition?> GetByIdAsync(int id);
        Task CreateAsync(Nutrition nutrition);
        Task UpdateAsync(Nutrition nutrition);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
