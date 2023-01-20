using FilmDB.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Newtonsoft.Json;

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

        [HttpGet]
        public IActionResult Edit(string id)
        {
            var result = _roleManager.Roles.SingleOrDefault(x => x.Id == id);
            if (result == null)
            {
                return View("Error");            
            }
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(IdentityRole role)
        {
            var result = await _roleManager.UpdateAsync(role);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddToRole(string errors)
        {
            var users =  _userManager.Users;
            var roles =  _roleManager.Roles;
            List<IdentityError> errorsList = new();
            if (errors != null) 
            {
                errorsList = JsonConvert.DeserializeObject<List<IdentityError>>(errors);
            }
            
            var userRoles = new UsersRolesViewModel()
            {
                Users = users,
                Roles = roles,
                Errors = errorsList
            };

            return View(userRoles);
        }

        [HttpPost]
        public async Task<IActionResult> AddToRolePost([FromForm(Name ="userID")] string UserID, [FromForm(Name = "roleName")] string RoleName)
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
                    return RedirectToAction("AddToRole", new {errors = json});
                }
            }
            return View("Error");
        }
    }
}
