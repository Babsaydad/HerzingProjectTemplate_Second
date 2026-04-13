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
        public async Task<IActionResult> Create([Bind("WorkoutId,WorkOutType,ExerciseList,Day,WorkOutActivityDate,UserId,WorkoutDetails,WorkoutTypeMode,UserProfileUserId")] WorkOut workOut)
        {
            if (!ModelState.IsValid)
            {
                return View(workOut);
            }

            // Call the service layer
            await _service.CreateAsync(workOut);
            return RedirectToAction("Details", "UserProfile", new { id = workOut.UserId });
        }


        //public async Task<IActionResult> Create([Bind("WorkoutId,WorkOutType,ExerciseList,Day,WorkOutActivityDate,UserId,WorkoutDetails,WorkoutTypeMode,UserProfileUserId")] WorkOut workOut)
        //{
        //    // 1. Check if we have any exercises to process
        //    if (workOut.ExerciseList != null && workOut.ExerciseList.Any())
        //    {
        //        //var workoutRows = new List<WorkOut>();

        //foreach (var item in workOut.ExerciseList)
        //{
        // 2. Split the string by the pipe symbol
        //var parts = item.Split('|').Select(p => p.Trim()).ToArray();

        //// 3. Create a new row for every exercise
        //var newRow = new WorkOut
        //{
        //    UserId = workOut.UserId,
        //    WorkOutType = workOut.WorkOutType,
        //    Day = workOut.Day,
        //    WorkOutActivityDate = workOut.WorkOutActivityDate,
        //   // UserId = workOut.UserId // Ensure the Foreign Key is set
        //};

        // 4. Map the split parts based on how much data was provided
        //if (parts.Length >= 3)
        //{
        //    newRow.ExerciseList = new List<string> { parts[0] };
        //    newRow.WorkoutTypeMode = parts[1];
        //    newRow.WorkoutDetails = parts[2];
        //}
        //else if (parts.Length == 2)
        //{
        //    newRow.ExerciseList = new List<string> { parts[0] };
        //    newRow.WorkoutTypeMode = parts[1];
        //    newRow.WorkoutDetails = "No details provided";
        //}
        //else
        //{
        //    newRow.ExerciseList = new List<string> { parts[0] };
        //    newRow.WorkoutTypeMode = "General";
        //    newRow.WorkoutDetails = "No details provided";
        //}

        //workoutRows.Add(newRow);
        //        }

        //        // 5. Save the rows if we successfully parsed any
        //        if (workoutRows.Any())
        //        {
        //            await _service.CreateRangeAsync(workoutRows);
        //            // Redirect back to UserProfile Details to see the new data
        //            return RedirectToAction("Details", "UserProfile", new { id = workOut.UserId });
        //        }
        //    }

        //    // If something failed, return to the view with the current model
        //    return View(workOut);
        //}





        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("WorkoutId,WorkOutType,ExerciseList,Day,WorkOutActivityDate,UserId,WorkoutDetails,WorkoutTypeMode,UserProfileUserId")] WorkOut workOut)
        //{
        //    if (ModelState.IsValid && workOut.ExerciseList != null)
        //    {
        //        var workoutRows = new List<WorkOut>();

        //        foreach (var item in workOut.ExerciseList)
        //        {
        //            var parts = item.Split('|').Select(p => p.Trim()).ToArray();
        //            if (parts.Length == 3)
        //            {
        //                workoutRows.Add(new WorkOut
        //                {
        //                    UserId = workOut.UserId,
        //                    WorkOutType = workOut.WorkOutType,
        //                    Day = workOut.Day,
        //                    WorkOutActivityDate = workOut.WorkOutActivityDate,
        //                    // Map the split data to the individual row
        //                    ExerciseList = new List<string> { parts[0] },
        //                    WorkoutTypeMode = parts[1],
        //                    WorkoutDetails = parts[2]
        //                });
        //            }
        //        }

        //        // Single service call for better performance
        //        await _service.CreateRangeAsync(workoutRows);
        //        return RedirectToAction("Index");
        //    }
        //    return View(workOut);
        //}





        //public async Task<IActionResult> Create([Bind("WorkoutId,WorkOutType,ExerciseList,Day,WorkOutActivityDate,UserId")] WorkOut workOut)
        //{
        //    // Note: We remove WorkoutTypeMode and WorkoutDetails from the Bind 
        //    // because we will extract those from the pipe-delimited ExerciseList string.

        //    if (ModelState.IsValid && workOut.ExerciseList != null)
        //    {
        //        foreach (var item in workOut.ExerciseList)
        //        {
        //            var parts = item.Split('|').Select(p => p.Trim()).ToArray();

        //            if (parts.Length == 3)
        //            {
        //                // Create a NEW object for each selected exercise
        //                var newWorkoutRow = new WorkOut
        //                {
        //                    UserId = workOut.UserId,
        //                    WorkOutType = workOut.WorkOutType,
        //                    Day = workOut.Day,
        //                    WorkOutActivityDate = workOut.WorkOutActivityDate,

        //                    // Assign the specific split data
        //                    ExerciseList = new List<string> { parts[0] }, // Just the name
        //                    WorkoutTypeMode = parts[1],                  // The category (e.g. Beginner)
        //                    WorkoutDetails = parts[2]                   // The reps/rest
        //                };

        //                // Save this specific exercise as its own row
        //                await _service.CreateAsync(newWorkoutRow);
        //            }
        //        }

        //        return RedirectToAction("Index");
        //    }

        //    return View(workOut);
        //}



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
