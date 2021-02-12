using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortfolioWebMVC.Data;
using StefanBrunotteWebPage.Models;

namespace PortfolioWebMVC.Controllers
{
    public class WorkController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorkController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Work
        public async Task<IActionResult> Index()
        {
            return View(await _context.WorkViewModel.ToListAsync());
        }

        // GET: Work Search
        public async Task<IActionResult> IndexSearchResult()
        {
            return View(await _context.WorkViewModel.ToListAsync());
        }

        // GET: Work/ShowSearchForm
        public async Task<IActionResult> ShowSearchForm()
        {
            return View();
        }

        // POST: Work/ShowSearchResults
        public async Task<IActionResult> ShowSearchResults(String SearchPhrase)
        {
            return View("IndexSearchResult", await _context.WorkViewModel.
                Where(desc => desc.WorkDescription.Contains(SearchPhrase)).ToListAsync());
        }

        // GET: Work/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workViewModel = await _context.WorkViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workViewModel == null)
            {
                return NotFound();
            }

            return View(workViewModel);
        }

        // GET: Work/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Work/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CompanyName,WorkDescription,WorkExperienceGainedDescription,WorkStartDate,WorkEndDate")] WorkViewModel workViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workViewModel);
        }

        // GET: Work/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workViewModel = await _context.WorkViewModel.FindAsync(id);
            if (workViewModel == null)
            {
                return NotFound();
            }
            return View(workViewModel);
        }

        // POST: Work/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CompanyName,WorkDescription,WorkExperienceGainedDescription,WorkStartDate,WorkEndDate")] WorkViewModel workViewModel)
        {
            if (id != workViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkViewModelExists(workViewModel.Id))
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
            return View(workViewModel);
        }

        // GET: Work/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workViewModel = await _context.WorkViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workViewModel == null)
            {
                return NotFound();
            }

            return View(workViewModel);
        }

        // POST: Work/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workViewModel = await _context.WorkViewModel.FindAsync(id);
            _context.WorkViewModel.Remove(workViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkViewModelExists(int id)
        {
            return _context.WorkViewModel.Any(e => e.Id == id);
        }
    }
}
