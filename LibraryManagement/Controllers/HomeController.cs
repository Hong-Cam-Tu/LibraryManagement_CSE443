using LibraryManagement.data;
using LibraryManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LibraryManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        private readonly LibraryDbContext _Homecontext;
        public HomeController(LibraryDbContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _Homecontext = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            var carouselItems = _Homecontext.Carousels
            .Where(c => c.IsActive)
            .OrderBy(c => c.Order)
            .ToList();

            return View(carouselItems);
        }
    }
}
