using System.Collections.Generic;
using System.Threading.Tasks;
using HerzingProjectTemplate.Models;
using HerzingProjectTemplate.Repositories;
using HerzingProjectTemplate.Services;

namespace HerzingProjectTemplate.Repositories
{
    public interface INutritionRepository
    {
        Task<IEnumerable<Nutrition>> GetAllAsync();
        Task<Nutrition?> GetByIdAsync(int id);
        Task AddAsync(Nutrition nutrition);
        Task UpdateAsync(Nutrition nutrition);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}