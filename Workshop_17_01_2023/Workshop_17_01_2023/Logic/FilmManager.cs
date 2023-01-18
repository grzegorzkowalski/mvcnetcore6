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
            using (var context = new FilmContext(_configuration))
            {
                var elementToDelete = context.Films.SingleOrDefault(x => x.ID == id);
                if(elementToDelete != null)
                {
                    context.Films.Remove(elementToDelete);
                    context.SaveChanges();
                }
            }
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

        public FilmModel GetFilm(int id)
        {
            var film = new FilmModel();
            using (var context = new FilmContext(_configuration))
            {
                film = context.Films.SingleOrDefault(x => x.ID == id);
            }
            return film;
        }

        public List<FilmModel> GetFilms()
        {
            return null;
        }
    }
}
