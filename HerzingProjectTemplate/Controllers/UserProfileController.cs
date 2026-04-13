using HerzingProjectTemplate.Data;
using HerzingProjectTemplate.Models;
using HerzingProjectTemplate.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Linq;
using System.Threading.Tasks;

namespace HerzingProjectTemplate.Controllers
{
    public class UserProfileController : Controller
    {
        private readonly IUserProfileService _service;
        public UserProfileController(IUserProfileService service) => _service = service;

        // GET: UserProfiles
        public async Task<IActionResult> Index()
        {
            var profiles = (await _service.GetAllProfilesAsync()).ToList();

            if (!profiles.Any())
                return RedirectToAction(nameof(Create));

            return View(profiles);
        }

        // GET: UserProfiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // The Service should handle fetching the profile AND its Nutrition records
            var userProfile = await _service.GetByIdWithNutritionWorkoutAsync(id.Value);
            //GetByEmailWithNutritionAsync(email);
            //GetProfileByIdAsync(id.Value); GetByEmailWithNutritionWorkoutAsync(email);

            if (userProfile == null)
            {
                return NotFound();
            }

            return View(userProfile);
        }

        // GET: UserProfiles/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,FirstName,LastName,Email,Password,Age,Weight,Height,Gender,ActivityLevel,FitnessGoal,BMR,TDEE")] UserProfile userProfile)
        {
            if (ModelState.IsValid)
            {
                await _service.CreateProfileAsync(userProfile);
                return RedirectToAction(nameof(Index));
            }
            return View(userProfile);
        }

        // GET: UserProfiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var userProfile = await _service.GetProfileByIdAsync(id.Value);
            if (userProfile == null) return NotFound();

            return View(userProfile);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,FirstName,LastName,Age,Weight,Height,Gender,ActivityLevel,FitnessGoal,BMR,TDEE")] UserProfile userProfile)
        {
            if (id != userProfile.UserId) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.UpdateProfileAsync(userProfile);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _service.ProfileExistsAsync(userProfile.UserId)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(userProfile);
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = await _service.GetByEmailAsync(email);

            if (user != null && user.Password == password)
            {
                return RedirectToAction("Details", new { id = user.UserId });
            }

            ModelState.AddModelError("", "Invalid login attempt.");
            return View();
        }

        // GET: UserProfiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var userProfile = await _service.GetProfileByIdAsync(id.Value);
            if (userProfile == null) return NotFound();

            return View(userProfile);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteProfileAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
