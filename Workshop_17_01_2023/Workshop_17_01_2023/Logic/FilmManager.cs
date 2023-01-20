using FilmDB.Data;
using FilmDB.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmDB.logic
{
    public class FilmManager
    {
        private readonly FilmContext context;
        public FilmManager(FilmContext filmContext)
        {
            context = filmContext;
        }

        public FilmManager AddFilm(FilmModel filmModel)
        {
            context.Films.Add(filmModel);
            context.SaveChanges();
            return this;
        }

        public FilmManager RemoveFilm(int id)
        {
            var elementToDelete = context.Films.SingleOrDefault(x => x.ID == id);
            if(elementToDelete != null)
            {
                context.Films.Remove(elementToDelete);
                context.SaveChanges();
            }
            return this;
        }

        public FilmManager UpdateFilm(FilmModel filmModel)
        {
            context.Films.Update(filmModel);
            context.SaveChanges();
            return this;
        }

        public FilmManager ChangeTitle(int id, string newTitle)
        {
            var film = new FilmModel();
            film = context.Films.SingleOrDefault(x => x.ID == id);
            try
            {
                film.Title = newTitle;
                //context.Films.Update(film);
                context.SaveChanges();
            }
            catch (Exception)
            {
                film.Title = "Brak tytułu";
                //context.Films.Update(film);
                context.SaveChanges();
            }
            return this;
        }

        public FilmModel GetFilm(int id)
        {
            var film = new FilmModel();
            film = context.Films.SingleOrDefault(x => x.ID == id);
            return film;
        }

        public List<FilmModel> GetFilms()
        {   var list = new List<FilmModel>();
            list = context.Films.Include(s => s.Genre).ToList();
            return list;
        }
    }
}
