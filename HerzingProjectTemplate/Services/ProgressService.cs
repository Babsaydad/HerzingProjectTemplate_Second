using HerzingProjectTemplate.Models;
using HerzingProjectTemplate.Repositories;
using NuGet.Protocol.Core.Types;

namespace HerzingProjectTemplate.Services
{
    public class ProgressService : IProgressService
    {
        private readonly IProgressRepository _repository;

        public ProgressService(IProgressRepository repository)
        {
            _repository = repository;
        }

        public async Task<Progress?> GetByIdWithNutritionWorkoutAsync(int id)
        {
            return await _repository.GetByIdWithNutritionWorkoutAsync(id);
        }
        public async Task<IEnumerable<Progress>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Progress?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        
        public async Task<IEnumerable<Progress>> GetByUserIdAsync(int userId)
        {
            return await _repository.GetByUserIdAsync(userId);
        }

        public async Task CreateAsync(Progress progress)
        {
            // Example business rule
            if (progress.ProgressDate == default)
                progress.ProgressDate = DateTime.Today;

            await _repository.AddAsync(progress);
        }

        public async Task UpdateAsync(Progress progress)
        {
            await _repository.UpdateAsync(progress);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
