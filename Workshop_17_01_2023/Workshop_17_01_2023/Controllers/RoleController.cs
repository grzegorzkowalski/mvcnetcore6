using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FilmDB.Controllers
{
    [Authorize]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public RoleController (RoleManager<IdentityRole> roleManager, 
            UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var roles = _roleManager.Roles;
            return View(roles);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(IdentityRole identityRole)
        {
            IdentityResult result = await _roleManager.CreateAsync(identityRole);
            if (result.Succeeded) {
                return RedirectToAction("Index");
            } 
            else
            {
                return View("Error");
            }  
        }

        [HttpGet]
        public IActionResult Remove()
        {
            var roles = _roleManager.Roles;
            return View(roles);
        }

        [HttpPost]
        public async Task<IActionResult> Remove([FromForm] string name)
        {
            var roleToDelete = await _roleManager.FindByNameAsync(name);

            if (roleToDelete != null)
            {
                var result = await _roleManager.DeleteAsync(roleToDelete);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Error");
                }
            }
            return RedirectToAction("Index");
        }
    }
}
