using Microsoft.AspNetCore.Identity;

namespace FilmDB.ViewModels
{
    public class UsersRolesViewModel
    {
        public IQueryable<IdentityUser> Users { get; set; }
        public IQueryable<IdentityRole> Roles { get; set; }
        public List<IdentityError>? Errors { get; set; }
    }
}
