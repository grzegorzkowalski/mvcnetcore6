using FilmDB.ViewModels;
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

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddToRole addToRole)
        {
            var newRole = new IdentityRole(addToRole.Name);
            var result = await _roleManager.CreateAsync(newRole);

            if (result.Succeeded)
            {
                return RedirectToAction("index");
            }
            else
            {
                return View(addToRole);
            }
        }
    }
}
