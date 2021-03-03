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
    public class AcademicController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AcademicController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Academic
        public async Task<IActionResult> Index()
        {
           
            return View(await _context.AcademicViewModel.ToListAsync());
        }

        // GET: Academic Search
        public async Task<IActionResult> IndexSearchResult()
        {
            return View(await _context.AcademicViewModel.ToListAsync());
        }

        // GET: Academic/ShowSearchForm
        public IActionResult ShowSearchForm()
        {
            return View();
        }

        // POST: Academic/ShowSearchResults
        public async Task<IActionResult> ShowSearchResults(String SearchPhrase)
        {
            return View("IndexSearchResult", await _context.AcademicViewModel.
                Where(desc=> desc.CourseCoversDescription.Contains(SearchPhrase)).ToListAsync());
        }

        // GET: Academic/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academicViewModel = await _context.AcademicViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (academicViewModel == null)
            {
                return NotFound();
            }

            return View(academicViewModel);
        }

        // GET: Academic/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Academic/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UniversityName,CourseName,CourseCoversDescription,ExperienceGainedDescription,CourseStartDate,CourseEndDate")] AcademicViewModel academicViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(academicViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(academicViewModel);
        }

        // GET: Academic/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academicViewModel = await _context.AcademicViewModel.FindAsync(id);
            if (academicViewModel == null)
            {
                return NotFound();
            }
            return View(academicViewModel);
        }

        // POST: Academic/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UniversityName,CourseName,CourseCoversDescription,ExperienceGainedDescription,CourseStartDate,CourseEndDate")] AcademicViewModel academicViewModel)
        {
            if (id != academicViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(academicViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcademicViewModelExists(academicViewModel.Id))
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
            return View(academicViewModel);
        }

        // GET: Academic/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academicViewModel = await _context.AcademicViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (academicViewModel == null)
            {
                return NotFound();
            }

            return View(academicViewModel);
        }

        // POST: Academic/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var academicViewModel = await _context.AcademicViewModel.FindAsync(id);
            _context.AcademicViewModel.Remove(academicViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AcademicViewModelExists(int id)
        {
            return _context.AcademicViewModel.Any(e => e.Id == id);
        }
    }
}
