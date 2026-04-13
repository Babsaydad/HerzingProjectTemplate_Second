using HerzingProjectTemplate.Models;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace HerzingProjectTemplate.Services
{
    public interface IUserProfileService
    {
        //Task ProcessAndSaveProfileAsync(UserProfile profile);
        Task<IEnumerable<UserProfile>> GetAllProfilesAsync();
        Task<UserProfile?> GetProfileByIdAsync(int id);
        Task<UserProfile?> GetByEmailAsync(string email);
        Task CreateProfileAsync(UserProfile profile);
        Task UpdateProfileAsync(UserProfile profile);
        Task DeleteProfileAsync(int id);
        Task<bool> ProfileExistsAsync(int id);

        Task<UserProfile?> GetByIdWithNutritionWorkoutAsync(int id);
        //Task ProcessAndSaveProfileAsync(UserProfile profile);
    }
}
