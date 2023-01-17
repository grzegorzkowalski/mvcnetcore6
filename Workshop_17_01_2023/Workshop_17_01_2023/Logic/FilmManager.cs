using FilmDB.Data;
using FilmDB.Models;

namespace FilmDB.logic
{
    public class FilmManager
    {
        private readonly IConfiguration _configuration;

        public FilmManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public FilmManager AddFilm(FilmModel filmModel)
        {
            using (var context = new FilmContext(_configuration))
            {
                context.Films.Add(filmModel);
                context.SaveChanges();
            }
            return this;
        }

        public FilmManager RemoveFilm(int id)
        {
            return this;
        }

        public FilmManager UpdateFilm(FilmModel filmModel)
        {
            return this;
        }

        public FilmManager ChangeTitle(int id, string newTitle)
        {
            return this;
        }

        public FilmManager GetFilm(int id)
        {
            return null;
        }

        public List<FilmModel> GetFilms()
        {
            return null;
        }
    }
}
