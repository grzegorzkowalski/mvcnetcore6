using FilmDB.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FilmDB.Controllers
{
    [Authorize(Roles="Admin")]
    public class RoleController : Controller
    {
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<IdentityUser> _userManager; 

        public RoleController(RoleManager<IdentityRole> rolManager, 
            UserManager<IdentityUser> userManager)
        {
            _roleManager = rolManager;
            _userManager = userManager;

        }
        public async Task<IActionResult> Index()
        {
            var roles = _roleManager.Roles;
            var userName = User.Identity.Name;
            var user = await _userManager.FindByNameAsync(userName);
            ViewBag.UserRoles = await _userManager.GetRolesAsync(user);
            return View(roles);
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

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            return View(role);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AddToRole addToRole)
        {
            var role = await _roleManager.FindByIdAsync(addToRole.Id);
            role.Name = addToRole.Name;
            var result = await _roleManager.UpdateAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View(addToRole);
        }

        [HttpGet]
        public IActionResult AddToRole ()
        {
            var roles = _roleManager.Roles;
            var users = _userManager.Users;
            RolesUsers rolesUsers = new();
            rolesUsers.Roles = roles;
            rolesUsers.Users = users;
            return View(rolesUsers);
        }

        [HttpPost]
        public async Task<IActionResult> AddToRole(
            [FromForm(Name = "userID")] string userID, 
            [FromForm(Name = "roleID")] string roleID)
        {
            var role = await _roleManager.FindByIdAsync(roleID);
            var user = await _userManager.FindByIdAsync(userID);
            
            if (role != null & user != null)
            {
                var result = await _userManager.AddToRoleAsync(user, role.Name);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }

            return View();        
        }
    }
}
