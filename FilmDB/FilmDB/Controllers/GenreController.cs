using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FilmDB.Data;
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

        // GET: GenreModels
        public async Task<IActionResult> Index()
        {
              return View(await _context.GenreModel.ToListAsync());
        }

        // GET: GenreModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GenreModel == null)
            {
                return NotFound();
            }

            var genreModel = await _context.GenreModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (genreModel == null)
            {
                return NotFound();
            }

            return View(genreModel);
        }

        // GET: GenreModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GenreModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] GenreModel genreModel)
        {
            if (genreModel != null)
            {
                _context.Add(genreModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(genreModel);
        }

        // GET: GenreModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GenreModel == null)
            {
                return NotFound();
            }

            var genreModel = await _context.GenreModel.FindAsync(id);
            if (genreModel == null)
            {
                return NotFound();
            }
            return View(genreModel);
        }

        // POST: GenreModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] GenreModel genreModel)
        {
            if (id != genreModel.Id)
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
                    if (!GenreModelExists(genreModel.Id))
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

        // GET: GenreModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GenreModel == null)
            {
                return NotFound();
            }

            var genreModel = await _context.GenreModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (genreModel == null)
            {
                return NotFound();
            }

            return View(genreModel);
        }

        // POST: GenreModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GenreModel == null)
            {
                return Problem("Entity set 'FilmContext.GenreModel'  is null.");
            }
            var genreModel = await _context.GenreModel.FindAsync(id);
            if (genreModel != null)
            {
                _context.GenreModel.Remove(genreModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GenreModelExists(int id)
        {
          return _context.GenreModel.Any(e => e.Id == id);
        }
    }
}
