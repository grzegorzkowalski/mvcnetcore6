using System.ComponentModel.DataAnnotations;

namespace FilmDB.ViewModels
{
    public class AddToRole
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
