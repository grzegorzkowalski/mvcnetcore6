using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FilmDB.Controllers
{
    [Authorize]
    public class RoleController : Controller
    {
        private RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> rolManager)
        {
            _roleManager = rolManager;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
