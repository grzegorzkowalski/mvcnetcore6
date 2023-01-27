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
            return Ok(film);
        }
    }
}
