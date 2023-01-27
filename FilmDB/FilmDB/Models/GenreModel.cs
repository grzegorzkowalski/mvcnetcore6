using System.ComponentModel.DataAnnotations.Schema;

namespace FilmDB.Models
{
    [Table("Genre")]
    public class GenreModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<FilmModel> Films { get; set; }
    }
}
