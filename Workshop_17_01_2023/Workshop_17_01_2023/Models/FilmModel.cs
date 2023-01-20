using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmDB.Models
{
    public class FilmModel
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }
        public int Year { get; set; }
        public int? GenreId { get; set; }
        [ForeignKey("GenreId")]
        public GenreModel Genre { get; set; }
    }
}
