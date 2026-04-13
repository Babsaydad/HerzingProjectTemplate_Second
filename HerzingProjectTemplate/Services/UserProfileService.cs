using HerzingProjectTemplate.Models;
using HerzingProjectTemplate.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;    

namespace HerzingProjectTemplate.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUserProfileRepository _repository;
        public UserProfileService(IUserProfileRepository repository) => _repository = repository;

        public async Task<IEnumerable<UserProfile>> GetAllProfilesAsync()
        {
            var profiles = await _repository.GetAllAsync();
            return profiles ?? Enumerable.Empty<UserProfile>();
        }

        public async Task<UserProfile?> GetByIdWithNutritionWorkoutAsync(int id)
        {
            return await _repository.GetByIdWithNutritionWorkoutAsync(id);
        }

        public async Task<UserProfile?> GetByEmailAsync(string email)
        {
            return await _repository.GetByEmailAsync(email);
        }

        public async Task<UserProfile?> GetProfileByIdAsync(int id) =>
            await _repository.GetByIdAsync(id);

        public async Task CreateProfileAsync(UserProfile profile)
        {
            CalculateMetetrics(profile);
            await _repository.AddAsync(profile);
        }

        public async Task UpdateProfileAsync(UserProfile profile)
        {
            CalculateMetetrics(profile);
            await _repository.UpdateAsync(profile);
        }

        public async Task DeleteProfileAsync(int id) =>
            await _repository.DeleteAsync(id);

        public async Task<bool> ProfileExistsAsync(int id) =>
            await _repository.ExistsAsync(id);

        // This is a private helper method used by Create and Update
        private void CalculateMetetrics(UserProfile profile)
        {
            // Check if Gender is "male" (ignores case, handles nulls safely)
            bool isMale = string.Equals(profile.Gender, "male", StringComparison.OrdinalIgnoreCase);

            if (isMale)
            {
                profile.BMR = (10 * profile.Weight) + (6.25 * profile.Height) - (5 * profile.Age) + 5;
            }
            else
            {
                profile.BMR = (10 * profile.Weight) + (6.25 * profile.Height) - (5 * profile.Age) - 161;
            }

            // 2. Calculate TDEE based on Activity Level
            double activityMultiplier = profile.ActivityLevel switch
            {
                "Sedentary" => 1.2,
                "Lightly Active" => 1.375,
                "Moderately Active" => 1.55,
                "Very Active" => 1.725,
                "Extra Active" => 1.9,
                _ => 1.2
            };

            profile.TDEE = profile.BMR * activityMultiplier;
        }
    }
}
