using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FilmDB;
using FilmDB.Models;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using FilmDB.ViewModels;

namespace FilmDB.Controllers
{
    public class ActorController : Controller
    {
        private readonly FilmContext _context;

        public ActorController(FilmContext context)
        {
            _context = context;
        }

        // GET: Actor
        public async Task<IActionResult> Index()
        {
              return View(await _context.Actors.ToListAsync());
        }

        // GET: Actor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Actors == null)
            {
                return NotFound();
            }

            var actorModel = await _context.Actors
                .FirstOrDefaultAsync(m => m.ID == id);
            if (actorModel == null)
            {
                return NotFound();
            }

            return View(actorModel);
        }

        // GET: Actor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Actor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FirstName,LastName,BirthYear")] ActorModel actorModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(actorModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(actorModel);
        }

        // GET: Actor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Actors == null)
            {
                return NotFound();
            }

            var actorModel = await _context.Actors.FindAsync(id);
            if (actorModel == null)
            {
                return NotFound();
            }
            return View(actorModel);
        }

        // POST: Actor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName,BirthYear")] ActorModel actorModel)
        {
            if (id != actorModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(actorModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActorModelExists(actorModel.ID))
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
            return View(actorModel);
        }

        // GET: Actor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Actors == null)
            {
                return NotFound();
            }

            var actorModel = await _context.Actors
                .FirstOrDefaultAsync(m => m.ID == id);
            if (actorModel == null)
            {
                return NotFound();
            }

            return View(actorModel);
        }

        // POST: Actor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Actors == null)
            {
                return Problem("Entity set 'FilmContext.ActorModel'  is null.");
            }
            var actorModel = await _context.Actors.FindAsync(id);
            if (actorModel != null)
            {
                _context.Actors.Remove(actorModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActorModelExists(int id)
        {
          return _context.Actors.Any(e => e.ID == id);
        }
        [HttpGet]
        public IActionResult AddActorToFilm(string errors)
        {
            var films = _context.Films.ToList();
            var actors = _context.Actors.ToList();
            List<IdentityError> errorsList = new();
            if (errors != null)
            {
                errorsList = JsonConvert.DeserializeObject<List<IdentityError>>(errors);
            }

            var filmActors = new FilmsActorsViewModel()
            {
                Films = films,
                Actors = actors,
                Errors = errorsList
            };

            return View(filmActors);
        }

        //[HttpPost]
        //public async Task<IActionResult> AddToRolePost([FromForm(Name = "userID")] string UserID, [FromForm(Name = "roleName")] string RoleName)
        //{
        //    //var user = await _userManager.FindByIdAsync(UserID);
        //    //if (user != null)
        //    //{
        //    //    var result = await _userManager.AddToRoleAsync(user, RoleName);
        //    //    if (result.Succeeded)
        //    //    {
        //    //        return RedirectToAction("Index");
        //    //    }

        //    //    else
        //    //    {
        //    //        List<IdentityError> errorList = result.Errors.ToList();
        //    //        string json = JsonConvert.SerializeObject(errorList);
        //    //        return RedirectToAction("AddToRole", new { errors = json });
        //    //    }
        //    }
        //    return View("Error");
        //}
    }
}
