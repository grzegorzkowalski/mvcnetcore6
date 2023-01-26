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

        [HttpGet]
        public IActionResult Remove()
        {
            var roles = _roleManager.Roles;
            return View(roles);
        }

        [HttpPost]
        public async Task<IActionResult> Remove([FromForm] string id)
        {
            var roleToDelete = await _roleManager.FindByIdAsync(id);

            if (roleToDelete != null)
            {
                var result = await _roleManager.DeleteAsync(roleToDelete);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }

            return View();
        }
    }
}
