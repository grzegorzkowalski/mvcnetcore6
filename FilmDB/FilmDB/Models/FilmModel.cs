using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FilmDB.Models
{
    public class FilmModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public int GenreID { get; set; }
        [ForeignKey("GenreID")]
        [JsonIgnore]
        public GenreModel? Genre { get; set; }
        public ICollection<FilmActor> FilmActors { get; set; }
    }
}
