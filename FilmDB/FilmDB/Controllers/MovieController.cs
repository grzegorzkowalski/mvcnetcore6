using FilmDB.Models;
using FilmDB.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FilmDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly FilmManager _filmManager;
        public MovieController(FilmManager filmManager)
        {
            _filmManager = filmManager;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var film = _filmManager.GetFilm(id);
            if (film == null) 
            {
                return NotFound();
            }
            return Ok(film);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var films = _filmManager.GetFilms();
            if (films.Count() == 0)
            {
                return NoContent();
            }
            return Ok(films);
        }

        [HttpPost]
        public IActionResult Create([FromBody] FilmModel filmModel)
        {
            _filmManager.AddFilm(filmModel);
            return Ok();
        }

        //[HttpPost]
        //public IActionResult Create2([FromBody] FilmModel filmModel)
        //{
        //    _filmManager.AddFilm(filmModel);
        //    return CreatedAtAction(nameof(Create2), new { id = filmModel.ID }, filmModel);
        //}

        //[HttpPost]
        //public IActionResult Create3([FromBody] FilmModel filmModel)
        //{
        //    _filmManager.AddFilm(filmModel);
        //    var url = $"{HttpContext.Request.Host.Value}/api/movie/{filmModel.ID}";
        //    return Created(url, "Success");
        //}


        [HttpPatch]
        public IActionResult Update([FromBody] FilmModel filmModel)
        {
            _filmManager.UpdateFilm(filmModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _filmManager.RemoveFilm(id);
            return NoContent();
        }
    }
}
