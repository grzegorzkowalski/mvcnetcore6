using FilmDB.Data;
using FilmDB.Models;

namespace FilmDB.Repositories
{
    public class FilmManager
    {
        public FilmManager AddFilm(FilmModel filmModel)
        {
            using (var _context = new FilmContext())
            {
                try
                {
                    _context.Films.Add(filmModel);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    filmModel.ID = 0;
                    _context.Films.Add(filmModel);
                    _context.SaveChanges();
                }

            }
            return this;
        }

        public FilmManager RemoveFilm(int id)
        {
            using (var _context = new FilmContext())
            {
                var filmToDelete = _context.Films.SingleOrDefault(x => x.ID == id);

                if (filmToDelete != null)
                {
                    _context.Films.Remove(filmToDelete);
                    _context.SaveChanges();
                }
            } 
            return this;
        }

        public FilmManager UpdateFilm(FilmModel filmModel)
        {
            using(var _context = new FilmContext())
            {
                _context.Films.Update(filmModel);
                _context.SaveChanges();
            }
                return this;
        }

        public FilmManager ChangeTitle(int id, string newTitle)
        {
            using (var _context = new FilmContext())
            {
                try
                {
                    var film = _context.Films.Single(x => x.ID == id);
                    if (!String.IsNullOrWhiteSpace(newTitle))
                    {
                        film.Title = newTitle;
                        _context.SaveChanges();
                    }
                }
                catch (Exception)
                {

                    return null;
                }

            }
            return this;
        }

        public FilmModel GetFilm(int id)
        {
            using (var _context = new FilmContext())
            {
                var film = _context.Films.SingleOrDefault(x => x.ID == id);
                return film;
            }
        }

        public List<FilmModel> GetFilms()
        {
            using (var _context = new FilmContext())
            {
                return _context.Films.ToList();
            }
            return null;
        }
    }
}
