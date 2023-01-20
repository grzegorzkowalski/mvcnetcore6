using Microsoft.AspNetCore.Mvc;

namespace FilmDB.ViewModels
{
    public class UserRoleIDsViewModel
    {
        [FromForm(Name = "RoleID")]
        public string RoleID { get; set; }
        [FromForm(Name = "UserID")]
        public string UserID { get; set; }
    }
}
