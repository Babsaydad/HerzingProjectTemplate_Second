using HerzingProjectTemplate.Models;
using HerzingProjectTemplate.Services;
using Microsoft.AspNetCore.Mvc;

namespace HerzingProjectTemplate.Controllers
{
    public class RankController : Controller
    {
        private readonly IRankService _rankService;

        public RankController(IRankService rankService)
        {
            _rankService = rankService;
        }

        // GET: /Rank
        public async Task<IActionResult> Index()
        {
            var ranks = await _rankService.GetAllRanksAsync();
            return View(ranks);
        }

        // GET: /Rank/Category/Workout
        public async Task<IActionResult> Category(string category)
        {
            if (string.IsNullOrEmpty(category))
                return BadRequest("Category is required.");

            var ranks = await _rankService.GetRanksByCategoryAsync(category);
            return View("Index", ranks);
        }

        // GET: /Rank/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var rank = await _rankService.GetRankByIdAsync(id);
            if (rank == null)
                return NotFound();

            return View(rank);
        }

        // GET: /Rank/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Rank/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Rank rank)
        {
            if (!ModelState.IsValid)
                return View(rank);

            await _rankService.AddRankAsync(rank);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Rank/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var rank = await _rankService.GetRankByIdAsync(id);
            if (rank == null)
                return NotFound();

            return View(rank);
        }

        // POST: /Rank/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Rank rank)
        {
            if (id != rank.RankId)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(rank);

            await _rankService.UpdateRankAsync(rank);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Rank/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var rank = await _rankService.GetRankByIdAsync(id);
            if (rank == null)
                return NotFound();

            return View(rank);
        }

        // POST: /Rank/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _rankService.DeleteRankAsync(id);
            return RedirectToAction(nameof(Index));
        }

        // OPTIONAL: API endpoint for Gamification page
        // GET: /Rank/GetUserRank?category=Workout&value=32
        public async Task<IActionResult> GetUserRank(string category, int value)
        {
            if (string.IsNullOrEmpty(category))
                return BadRequest("Category is required.");

            var rank = await _rankService.DetermineUserRankAsync(category, value);

            if (rank == null)
                return NotFound("No rank found for the given value.");

            return Json(rank);
        }
    }


    //public class RankController : Controller
    //{
    //    public IActionResult Index()
    //    {
    //        return View();
    //    }
    //}
}








