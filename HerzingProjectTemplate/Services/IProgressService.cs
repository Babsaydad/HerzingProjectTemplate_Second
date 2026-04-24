using HerzingProjectTemplate.Models;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace HerzingProjectTemplate.Services
{
    public interface IProgressService
    {
        Task<IEnumerable<Progress>> GetAllAsync();
        Task<Progress?> GetByIdAsync(int id);
        Task<IEnumerable<Progress>> GetByUserIdAsync(int userId);

        //Task<Progress?> GetUserIdAsync(int id);
        Task CreateAsync(Progress progress);
        Task UpdateAsync(Progress progress);
        Task DeleteAsync(int id);
        Task<Progress?> GetByIdWithNutritionWorkoutAsync(int id);
    }
}
