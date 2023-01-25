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
