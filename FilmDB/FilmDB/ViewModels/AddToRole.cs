using System.ComponentModel.DataAnnotations;

namespace FilmDB.ViewModels
{
    public class AddToRole
    {
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
