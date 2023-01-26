using FilmDB.Models;
using FilmDB.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FilmDB.Controllers
{
    public class FilmController : Controller
    {
        private readonly FilmManager _filmManager;
        public FilmController(FilmManager filmManager)
        { 
            _filmManager = filmManager;
        }
        public IActionResult Index()
        {
            var films = _filmManager.GetFilms();

            return View(films);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(FilmModel film)
        {
            _filmManager.AddFilm(film);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Remove (int id)
        {
            var filmToDelete = _filmManager.GetFilm(id);
            return View(filmToDelete);
        }

        [HttpPost]
        public IActionResult RemoveConfirm (int id)
        {
            _filmManager.RemoveFilm(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit (int id)
        {
            FilmModel film = _filmManager.GetFilm(id);
            return View(film);      
        }

        [HttpPost]
        public IActionResult Edit (FilmModel film)
        {
            _filmManager.UpdateFilm(film);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details (int id)
        {
            FilmModel film = _filmManager.GetFilm(id);
            return View(film);
        }
    }
}
