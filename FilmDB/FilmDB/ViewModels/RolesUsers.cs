using Microsoft.AspNetCore.Identity;

namespace FilmDB.ViewModels
{
    public class RolesUsers
    {
        public IQueryable<IdentityRole> Roles { get; set; }
        public IQueryable<IdentityUser> Users { get; set; }
    }
}
