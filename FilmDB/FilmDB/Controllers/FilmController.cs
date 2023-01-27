using FilmDB.Data;
using FilmDB.Models;
using FilmDB.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FilmDB.Controllers
{
    public class FilmController : Controller
    {
        private readonly FilmManager _filmManager;
        private readonly FilmContext _filmContext;
        public FilmController(FilmManager filmManager, FilmContext filmContext)
        { 
            _filmManager = filmManager;
            _filmContext = filmContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Genre = _filmContext.GenreModel.ToList();
            var films = _filmManager.GetFilms();

            return View(films);
        }

        [HttpPost]
        public IActionResult Index([FromForm(Name="GenreName")] string name)
        {
            ViewBag.Genre = _filmContext.GenreModel.ToList();
            var films = new List<FilmModel>(); 
            if (name == "wszystkie")
            {
                films = _filmManager.GetFilms();
            }
            else 
            {
                films = _filmManager.GetFilmsByCategory(name);
            }
            

            return View(films);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Genre = _filmContext.GenreModel.ToList();
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
            ViewBag.Genre = _filmContext.GenreModel.ToList();
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
