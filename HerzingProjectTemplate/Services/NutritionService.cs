using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HerzingProjectTemplate.Models;
using HerzingProjectTemplate.Repositories;

namespace HerzingProjectTemplate.Services
{
    public class NutritionService : INutritionService
    {
        private readonly INutritionRepository _repository;
        public NutritionService(INutritionRepository repository) => _repository = repository;

        public async Task<IEnumerable<Nutrition>> GetAllAsync()
        {
            var items = await _repository.GetAllAsync();
            return items ?? Enumerable.Empty<Nutrition>();
        }

        public async Task<Nutrition?> GetByIdAsync(int id) =>
            await _repository.GetByIdAsync(id);

        public async Task CreateAsync(Nutrition nutrition)
        {
            NormalizeNutrition(nutrition);
            await _repository.AddAsync(nutrition);
        }

        public async Task UpdateAsync(Nutrition nutrition)
        {
            NormalizeNutrition(nutrition);
            await _repository.UpdateAsync(nutrition);
        }

        public async Task DeleteAsync(int id) =>
            await _repository.DeleteAsync(id);

        public async Task<bool> ExistsAsync(int id) =>
            await _repository.ExistsAsync(id);

        // Small normalization/helper used before persistence
        private void NormalizeNutrition(Nutrition n)
        {
            if (string.IsNullOrWhiteSpace(n.MealType))
                n.MealType = "Unknown";

            if (n.NutritionActivityDate == default)
                n.NutritionActivityDate = DateTime.UtcNow.Date;

            // Ensure calories are consistent with macros if client didn't set them
            // Calculation for Total Energy (Calories)
            // Formula: (Protein * 4) + (Carbohydrates * 4) + (Fats * 9)
            n.Calories = (n.Protein * 4) + (n.Carbohydrates * 4) + (n.Fats * 9);
        }
    }
}
