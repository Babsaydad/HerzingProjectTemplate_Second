using HerzingProjectTemplate.Data;
using HerzingProjectTemplate.Models;
using HerzingProjectTemplate.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HerzingProjectTemplate.Controllers
{
    public class WorkOutController : Controller
    {
        private readonly IWorkoutService _service;

        public WorkOutController(IWorkoutService service)
        {
            _service = service;
        }

        // GET: WorkOut
        public async Task<IActionResult> Index()
        {
            var workouts = (await _service.GetAllAsync()).ToList();

            if (!workouts.Any())
                return RedirectToAction(nameof(Create));

            return View(workouts);
        }

        // GET: WorkOut/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workout = await _service.GetByIdAsync(id.Value);
            if (workout == null)
            {
                return NotFound();
            }

            return View(workout);
        }

        // GET: WorkOut/Create
        public IActionResult Create(int userId)
        {
            var model = new WorkOut { UserId = userId };
            return View();
        }

        // POST: WorkOut/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,WorkoutId,WorkOutType,ExerciseList,Day,WorkOutActivityDate,WorkoutDetails,WorkoutTypeMode")] WorkOut workOut)
        {
            if (!ModelState.IsValid)
            {
                return View(workOut);
            }

            // Call the service layer
            await _service.CreateAsync(workOut);
            return RedirectToAction("Details", "UserProfile", new { id = workOut.UserId });
        }

        // GET: WorkOut/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workOut = await _service.GetByIdAsync(id.Value);
            if (workOut == null)
            {
                return NotFound();
            }
            return View(workOut);
        }

        // POST: WorkOut/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WorkoutId,WorkOutType,WorkoutTypeMode,ExerciseList,Day,WorkOutActivityDate")] WorkOut workOut)
        {
            if (id != workOut.WorkoutId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_service.Update(workOut);
                    await _service.UpdateAsync(workOut);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _service.ExistsAsync(workOut.WorkoutId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(workOut);
        }

        // GET: WorkOut/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workOut = await _service.GetByIdAsync(id.Value);
            
            if (workOut == null)
            {
                return NotFound();
            }

            return View(workOut);
        }

        // POST: WorkOut/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
    
}
