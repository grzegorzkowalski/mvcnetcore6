using FilmDB.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmDB.Controllers
{
    public class FilmController : Controller
    {
        private readonly FilmManager filmManager;
        private readonly FilmContext filmContext;
        public FilmController (FilmManager _filmManager, FilmContext _filmContext)
        {
            filmManager = _filmManager;
            filmContext = _filmContext;
        }
        
        public IActionResult Index()
        {
            var films = filmManager.GetFilms();

            return View(films);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Genre = filmContext.GenreModels.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Add(FilmModel filmModel)
        {
            filmManager.AddFilm(filmModel);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Remove(int id)
        {
            var film = filmManager.GetFilm(id);
            return View(film);
        }

        [HttpPost]
        public IActionResult RemoveConfirm(int id)
        {
            filmManager.RemoveFilm(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var film = filmManager.GetFilm(id);
            return View(film);
        }

        [HttpPost]
        public IActionResult Edit(FilmModel film)
        {
            filmManager.UpdateFilm(film);
            return RedirectToAction("Index");
        }

        [HttpGet("{controller}/byCategory/{name}")]
        public IActionResult GetFilmsByCategory(string name)
        {
            ViewBag.GenreList = filmContext.GenreModels.ToList();
            ViewBag.Name = name;
            var films = filmManager.GetFilmsByCategory(name);
            return View(films);
        }

        public IActionResult changeCategory([FromForm]string name)
        {
            ViewBag.GenreList = filmContext.GenreModels.ToList();
            ViewBag.Name = name;
            var films = filmManager.GetFilmsByCategory(name);
            return View(films);
        }
    }   
}
