using FilmDB.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmDB
{
    public class FilmManager
    {
        private readonly IConfiguration _configuration;
        private readonly FilmContext _context;

        public FilmManager(IConfiguration configuration, FilmContext context)
        {
            _configuration = configuration;
            _context = context;
        }


        public FilmManager AddFilm(FilmModel filmModel)
        {
            try
            {
                _context.Films.Add(filmModel);
                _context.SaveChanges();
            }
            catch (System.Exception)
            {
                filmModel.ID = 0;
                _context.Films.Add(filmModel);
                _context.SaveChanges();
            }
                return this;
        }

        public void RemoveFilm(int id)
        {
            FilmModel filmToDelete = _context.Films.SingleOrDefault(x => x.ID == id);
            if (filmToDelete != null) 
            {
                _context.Films.Remove(filmToDelete);
                _context.SaveChanges();
            }
        }

        public void UpdateFilm(FilmModel filmModel)
        {
            _context.Films.Update(filmModel);
            _context.SaveChanges();
        }

        public void ChangeTitle(int id, string newTitle)
        {
            FilmModel film = this.GetFilm(id);
            if (String.IsNullOrEmpty(newTitle))
            {
                newTitle = "Brak tytułu";
            }
            film.Title = newTitle;
            _context.Films.Update(film);
            _context.SaveChanges();
    }

        public FilmModel GetFilm(int id)
        {
            return _context.Films.SingleOrDefault(x => x.ID == id);

        }

        public List<FilmModel> GetFilms()
        {
            return _context.Films.Include(s => s.Genre).ToList();
        }

        public List<FilmModel> GetFilmsByCategory(string name)
        {
                return _context.Films
                .Include(s => s.Genre)
                .Where(s => s.Genre.Name == name).ToList();

        }
    }
}
