using FilmDB.Models;
using FilmDB.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FilmDB.Controllers
{
    public class FilmController : Controller
    {
        public IActionResult Index()
        {
            var filmManager = new FilmManager();
            // filmManager.AddFilm(film);

            filmManager.RemoveFilm(3);

            return View();
        }
    }
}
