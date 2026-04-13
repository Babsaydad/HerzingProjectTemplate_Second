using HerzingProjectTemplate.Data;
using HerzingProjectTemplate.Models;
using HerzingProjectTemplate.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HerzingProjectTemplate.Controllers
{
    public class NutritionController : Controller
    {
        private readonly INutritionService _service;

        public NutritionController(INutritionService service)
        {
            _service = service;
        }

        // GET: Nutritions
        public async Task<IActionResult> Index()
        {
            var nutrition = (await _service.GetAllAsync()).ToList();


            if (!nutrition.Any())
                return RedirectToAction(nameof(Create));

            return View(nutrition);
        }

        // GET: Nutritions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nutrition = await _service.GetByIdAsync(id.Value);
            if (nutrition == null)
            {
                return NotFound();
            }

            return View(nutrition);
        }

        // GET: Nutritions/Create
        public IActionResult Create(int userId)
        {
            var model = new Nutrition { UserId = userId };
            return View(model);
        }

        // POST: Nutritions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NutritionId,MealType,FoodName,FoodEnergy,Day,DailyTotal,Protein,Fats,Carbohydrates,Calories,NutritionActivityDate,UserId, UserProfileUserId")] Nutrition nutrition)
        {
            
            if (ModelState.IsValid)
            {
                await _service.CreateAsync(nutrition);
                
                return RedirectToAction("Details", "UserProfile", new { id = nutrition.UserId });
            }
            return View(nutrition);
        }

        // GET: Nutritions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nutrition = await _service.GetByIdAsync(id.Value); 
            if (nutrition == null)
            {
                return NotFound();
            }
            return View(nutrition);
        }

        // POST: Nutritions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NutritionId,MealType,FoodName,FoodEnergy,Day,DailyTotal,Protein,Fats,Calories,NutritionActivityDate,UserId")] Nutrition nutrition)
        {
            if (id != nutrition.NutritionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.UpdateAsync(nutrition);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _service.ExistsAsync(nutrition.NutritionId))
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
            return View(nutrition);
        }

        // GET: Nutritions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nutrition = await _service.GetByIdAsync(id.Value);
               
            if (nutrition == null)
            {
                return NotFound();
            }

            return View(nutrition);
        }

        // POST: Nutritions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Details));
        }

        //private bool NutritionExists(int id)
        //{
        //    return _service.Nutritions.Any(e => e.NutritionId == id);
        //}
    }
}
