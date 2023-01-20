using FilmDB.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FilmDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : Controller
    {
        private readonly FilmManager filmManager;
        public MovieController(FilmManager _filmManager)
        {
            filmManager = _filmManager;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var film = filmManager.GetFilm(id);
            return Json(film);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<FilmModel> films = filmManager.GetFilms();
            return Json(films);
        }


        [HttpPost]
        public IActionResult Create2([FromBody] FilmModel filmModel)
        {
            filmManager.AddFilm(filmModel);
            return CreatedAtAction(nameof(Create2),new { id = filmModel.ID }, filmModel);
        }

        [HttpPost]
        public IActionResult Create([FromBody] FilmModel filmModel)
        {
            filmManager.AddFilm(filmModel);
            var url =  $"HttpContext.Request.Host.Value/api/movie/{filmModel.ID}";
            return Created(url, "Success");
        }

        [HttpPut]
        public IActionResult Update([FromBody] FilmModel film)
        {
            filmManager.UpdateFilm(film);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            filmManager.RemoveFilm(id);
            return NoContent();
        }
    }
}
