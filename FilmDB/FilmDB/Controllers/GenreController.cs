using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FilmDB;
using FilmDB.Models;

namespace FilmDB.Controllers
{
    public class GenreController : Controller
    {
        private readonly FilmContext _context;

        public GenreController(FilmContext context)
        {
            _context = context;
        }

        // GET: Genre
        public async Task<IActionResult> Index()
        {
              return View(await _context.GenreModels.ToListAsync());
        }

        // GET: Genre/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GenreModels == null)
            {
                return NotFound();
            }

            var genreModel = await _context.GenreModels
                .FirstOrDefaultAsync(m => m.GenreID == id);
            if (genreModel == null)
            {
                return NotFound();
            }

            return View(genreModel);
        }

        // GET: Genre/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Genre/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,GenreID")] GenreModel genreModel)
        {
                _context.Add(genreModel);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
        }

        // GET: Genre/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GenreModels == null)
            {
                return NotFound();
            }

            var genreModel = await _context.GenreModels.FindAsync(id);
            if (genreModel == null)
            {
                return NotFound();
            }
            return View(genreModel);
        }

        // POST: Genre/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,GenreID")] GenreModel genreModel)
        {
            if (id != genreModel.GenreID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(genreModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GenreModelExists(genreModel.GenreID))
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
            return View(genreModel);
        }

        // GET: Genre/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GenreModels == null)
            {
                return NotFound();
            }

            var genreModel = await _context.GenreModels
                .FirstOrDefaultAsync(m => m.GenreID == id);
            if (genreModel == null)
            {
                return NotFound();
            }

            return View(genreModel);
        }

        // POST: Genre/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GenreModels == null)
            {
                return Problem("Entity set 'FilmContext.GenreModels'  is null.");
            }
            var genreModel = await _context.GenreModels.FindAsync(id);
            if (genreModel != null)
            {
                _context.GenreModels.Remove(genreModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GenreModelExists(int id)
        {
          return _context.GenreModels.Any(e => e.GenreID == id);
        }
    }
}
