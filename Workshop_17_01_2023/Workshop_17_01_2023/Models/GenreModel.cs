using System.ComponentModel.DataAnnotations;

namespace FilmDB.Models
{
    public class GenreModel
    {
        [Key]
        public int GenreId { get; set; }
        public string Name { get; set; }    
        public ICollection<FilmModel> Films { get; set; }
    }
}
