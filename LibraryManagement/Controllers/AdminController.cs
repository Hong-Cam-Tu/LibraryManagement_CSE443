using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AdminController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Dashboard()
        {
            ViewData["Title"] = "Dashboard";

            return View();
        }

        // Gán Role cho User
        public  IActionResult AssignRole(string userId, string roleName)
        {
            var user =  _userManager.FindByIdAsync(userId).Result;
            if (user == null)
            {
                TempData["Error"] = "Người dùng không tồn tại.";
                return RedirectToAction("Index", "Admin");
            }

            var roleExists = _roleManager.RoleExistsAsync(roleName).Result;
            if (!roleExists)
            {
                TempData["Error"] = "Role không tồn tại.";
                return RedirectToAction("Index", "Admin");
            }

            var result = _userManager.AddToRoleAsync(user, roleName).Result;
            if (result.Succeeded)
            {
                TempData["Success"] = "Gán quyền thành công.";
            }
            else
            {
                TempData["Error"] = "Gán quyền thất bại.";
            }
            return RedirectToAction("Index", "Admin");
        }
    }
}
