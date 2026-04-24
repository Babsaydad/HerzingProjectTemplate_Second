using HerzingProjectTemplate.Models;
using HerzingProjectTemplate.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HerzingProjectTemplate.Controllers
{
    public class ProgressController : Controller
    {
        private readonly IProgressService _service;

        public ProgressController(IProgressService service)
        {
            _service = service;
        }

        // GET: Progress
        public async Task<IActionResult> Index(int id)
        {
            //fetch all data with this method
            var progressList = await _service.GetAllAsync();

            //filters based on id
            //if (id.HasValue)
            //{
            //    progressList = progressList.Where(x => x.UserId == id.Value);
            //}
            return View(progressList);
        }

        // GET: Progress/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var progress = await _service.GetByIdAsync(id);
            if (progress == null)
                return NotFound();

            return View(progress);
        }

        // GET: Progress/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Progress/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Progress progress)
        {
            if (!ModelState.IsValid)
                return View(progress);

            await _service.CreateAsync(progress);
            return RedirectToAction(nameof(Index));
        }

        // GET: Progress/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var progress = await _service.GetByIdAsync(id);
            if (progress == null)
                return NotFound();

            return View(progress);
        }

        // POST: Progress/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Progress progress)
        {
            if (id != progress.ProgressId)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(progress);

            await _service.UpdateAsync(progress);
            return RedirectToAction(nameof(Index));
        }

        // GET: Progress/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var progress = await _service.GetByIdAsync(id);
            if (progress == null)
                return NotFound();

            return View(progress);
        }

        // POST: Progress/DeleteConfirmed/5
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

