using FilmDB.logic;
using FilmDB.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : Controller
    {
        private readonly FilmManager _filmManager;
        public MovieController (FilmManager filmManager)
        {
            _filmManager = filmManager;
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var film = _filmManager.GetFilm(id);
            return Json(film);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<FilmModel> films = _filmManager.GetFilms();
            return Json(films);
        }

        [HttpPost]
        public IActionResult Create([FromBody] FilmModel filmModel)
        {
            _filmManager.AddFilm(filmModel);
            var url = $"{HttpContext.Request.Host.Value}/api/movie/{filmModel.ID}";
            return Created(url, "Success");
        }

        [HttpPut]
        public IActionResult Update([FromBody] FilmModel film)
        {
            _filmManager.UpdateFilm(film);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _filmManager.RemoveFilm(id);
            return NoContent();
        }
    }
}
