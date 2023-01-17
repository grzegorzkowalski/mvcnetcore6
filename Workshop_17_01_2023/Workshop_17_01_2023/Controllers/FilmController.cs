using FilmDB.logic;
using FilmDB.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmDB.Controllers
{
    public class FilmController : Controller
    {
        private readonly FilmManager _filmManager;

        public FilmController(IConfiguration configuration)
        {
            _filmManager = new FilmManager(configuration);
        }
        public IActionResult Index()
        {
            var film = new FilmModel()
            {
                //ID = 1,
                Title = "Rambo",
                Year = 1980
            };
           
            try
            {
                _filmManager.AddFilm(film);
            }
            catch (Exception)
            {

                film.ID = 0;
                _filmManager.AddFilm(film);
            }

            return View();
        }
    }
}
