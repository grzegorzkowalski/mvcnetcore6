using FilmDB.Data;
using FilmDB.Models;

namespace FilmDB.Repositories
{
    public class FilmManager
    {
        private readonly FilmContext _context;
        public FilmManager(FilmContext context)
        {
            _context = context;
        }

        public FilmManager AddFilm(FilmModel filmModel)
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
            return this;
        }

        public FilmManager RemoveFilm(int id)
        {
            var filmToDelete = _context.Films.SingleOrDefault(x => x.ID == id);

            if (filmToDelete != null)
            {
                _context.Films.Remove(filmToDelete);
                _context.SaveChanges();
            } 
            return this;
        }

        public FilmManager UpdateFilm(FilmModel filmModel)
        
        {
            _context.Films.Update(filmModel);
            _context.SaveChanges();

            return this;
        }

        public FilmManager ChangeTitle(int id, string newTitle)
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
            return this;
        }

        public FilmModel GetFilm(int id)
        {
            return _context.Films.SingleOrDefault(x => x.ID == id);
        }

        public List<FilmModel> GetFilms()
        {
            return _context.Films.ToList();
        }
    }
}
