using LibraryManagement.Models.Context;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleContext _Rolecontext;
        public IActionResult Index()
        {
            var list= _Rolecontext.Roles.ToList();
            return View();
        }
    }
}
