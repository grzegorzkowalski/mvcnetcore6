using System.ComponentModel.DataAnnotations;

namespace FilmDB.Models
{
    public class FilmModel
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }
        public int Year { get; set; }
    }
}
