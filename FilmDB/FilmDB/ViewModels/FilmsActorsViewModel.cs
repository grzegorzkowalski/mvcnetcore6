using FilmDB.Models;
using Microsoft.AspNetCore.Identity;

namespace FilmDB.ViewModels
{
    public class FilmsActorsViewModel
    {
        public List<FilmModel> Films { get; set; }
        public List<ActorModel> Actors { get; set; }
        public List<IdentityError>? Errors { get; set; }
    }
}
