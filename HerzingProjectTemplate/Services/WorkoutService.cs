using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HerzingProjectTemplate.Models;
using HerzingProjectTemplate.Repositories;

namespace HerzingProjectTemplate.Services
{
    public class WorkoutService : IWorkoutService
    {
        private readonly IWorkoutRepository _repository;
        public WorkoutService(IWorkoutRepository repository) => _repository = repository;

        public async Task<IEnumerable<WorkOut>> GetAllAsync()
        {
            var items = await _repository.GetAllAsync();
            return items ?? Enumerable.Empty<WorkOut>();
        }

        public async Task<WorkOut?> GetByIdAsync(int id) =>
            await _repository.GetByIdAsync(id);

        public async Task CreateAsync(WorkOut workout)
        {
            Normalize(workout);
            await _repository.AddAsync(workout);
        }

        public async Task CreateRangeAsync(IEnumerable<WorkOut> workouts)
        {
            await _repository.CreateRangeAsync(workouts);
        }


        public async Task UpdateAsync(WorkOut workout)
        {
            Normalize(workout);
            await _repository.UpdateAsync(workout);
        }

        public async Task DeleteAsync(int id) =>
            await _repository.DeleteAsync(id);

        public async Task<bool> ExistsAsync(int id) =>
            await _repository.ExistsAsync(id);

        // Ensure model consistency before persistence
        private void Normalize(WorkOut w)
        {
            if (w.ExerciseList == null)
                w.ExerciseList = new List<string>();

            if (w.WorkOutActivityDate == default)
                w.WorkOutActivityDate = DateTime.UtcNow.Date;

            if (string.IsNullOrWhiteSpace(w.Day))
                w.Day = w.WorkOutActivityDate.DayOfWeek.ToString();
        }
    }
}
