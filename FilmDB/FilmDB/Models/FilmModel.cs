using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FilmDB.Models
{
    public class FilmModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public int? GenreId { get; set; }
        [ForeignKey("GenreId")]
        [JsonIgnore]
        public GenreModel? Genre { get; set; }
    }
}