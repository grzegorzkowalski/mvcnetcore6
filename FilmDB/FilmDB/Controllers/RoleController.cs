using FilmDB.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FilmDB.Controllers
{
    [Authorize(Roles=("Admin"))]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
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
        public async Task<IActionResult> Add(RoleViewModel role)
        {
            IdentityResult result =
                await _roleManager.CreateAsync(new IdentityRole(role.Name));
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                throw new Exception(result.Errors.ToString());
            }
        }

        [HttpGet]
        public IActionResult Remove()
        {
            var roles = _roleManager.Roles;
            return View(roles);
        }

        [HttpPost]
        public async Task<IActionResult> Remove(string Id)
        {
            var roleToDelete = await _roleManager.FindByIdAsync(Id);

            if (roleToDelete != null)
            {
                var resultOfDelete = await _roleManager.DeleteAsync(roleToDelete);

                if (resultOfDelete.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult AddToRole(string errors)
        {
            var users = _userManager.Users;
            var roles = _roleManager.Roles;
            List<IdentityError> errorsList = new();
            if (errors != null)
            {
                errorsList = JsonConvert.DeserializeObject<List<IdentityError>>(errors);
            }

            var userRoles = new UserRoleViewModel()
            {
                Users = users,
                Roles = roles,
                Errors = errorsList
            };

            return View(userRoles);
        }

        [HttpPost]
        public async Task<IActionResult> AddToRolePost([FromForm(Name = "userID")] string UserID, [FromForm(Name = "roleName")] string RoleName)
        {
            var user = await _userManager.FindByIdAsync(UserID);
            if (user != null)
            {
                var result = await _userManager.AddToRoleAsync(user, RoleName);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                else
                {
                    List<IdentityError> errorList = result.Errors.ToList();
                    string json = JsonConvert.SerializeObject(errorList);
                    return RedirectToAction("AddToRole", new { errors = json });
                }
            }
            return View("Error");
        }
    } 
}
