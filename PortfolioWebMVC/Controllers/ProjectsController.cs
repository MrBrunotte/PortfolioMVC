using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortfolioWebMVC.Data;
using PortfolioWebMVC.Models;

namespace PortfolioWebMVC.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Projects
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProjectsViewModel.ToListAsync());
        }

        // GET: Projects Search
        public async Task<IActionResult> IndexSearchResult()
        {
            return View(await _context.ProjectsViewModel.ToListAsync());
        }

        // GET: Projects/ShowSearchForm
        public async Task<IActionResult> ShowSearchForm()
        {
            return View();
        }

        // POST: Projects/ShowSearchResults
        public async Task<IActionResult> ShowSearchResults(String SearchPhrase)
        {
            return View("IndexSearchResult", await _context.ProjectsViewModel.
                Where(desc => desc.ProjectDescription.Contains(SearchPhrase)).ToListAsync());
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectsViewModel = await _context.ProjectsViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectsViewModel == null)
            {
                return NotFound();
            }

            return View(projectsViewModel);
        }

        // GET: Projects/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProjectName,ProjectDescription,FrameworkToolsDescription,GitHubLink,DeployedLink")] ProjectsViewModel projectsViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projectsViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(projectsViewModel);
        }

        // GET: Projects/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectsViewModel = await _context.ProjectsViewModel.FindAsync(id);
            if (projectsViewModel == null)
            {
                return NotFound();
            }
            return View(projectsViewModel);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProjectName,ProjectDescription,FrameworkToolsDescription,GitHubLink,DeployedLink")] ProjectsViewModel projectsViewModel)
        {
            if (id != projectsViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectsViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectsViewModelExists(projectsViewModel.Id))
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
            return View(projectsViewModel);
        }

        // GET: Projects/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectsViewModel = await _context.ProjectsViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectsViewModel == null)
            {
                return NotFound();
            }

            return View(projectsViewModel);
        }

        // POST: Projects/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projectsViewModel = await _context.ProjectsViewModel.FindAsync(id);
            _context.ProjectsViewModel.Remove(projectsViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectsViewModelExists(int id)
        {
            return _context.ProjectsViewModel.Any(e => e.Id == id);
        }
    }
}
