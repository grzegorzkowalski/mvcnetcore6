using FilmDB.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmDB.Controllers
{
    public class FilmController : Controller
    {
        public IActionResult Index()
        {
            var film = new FilmModel()
            {
                Title = "Rambo",
                Year = 1985
            };
            var filmManager = new FilmManager();
            filmManager.AddFilm(film);

            return View();
        }
    }
}
