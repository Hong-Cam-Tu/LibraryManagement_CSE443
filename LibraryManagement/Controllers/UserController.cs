using LibraryManagement.Models.Context;
using LibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using Microsoft.Win32;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Security.Cryptography;

namespace LibraryManagement.Controllers
{
    public class UserController : Controller
    {
        private readonly UserContext _Usercontext;
        private readonly RoleContext _Rolecontext;

        public UserController(UserContext userContext,
                              RoleContext roleContext)
        {
            _Usercontext = userContext;
            _Rolecontext = roleContext;
        }
        public IActionResult Index()
        {
            var list = _Usercontext.Users.ToList();
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Roles = new SelectList(_Rolecontext.Roles.ToList(), "RoleId", "RoleName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Users user)
        {
            if (ModelState.IsValid)
            {
                if (user.CreatedDate == null)
                {
                    user.CreatedDate = DateTime.Now;
                }
                _Usercontext.Users.Add(user);
                _Usercontext.SaveChanges();

                TempData["SuccessMessage"] = "Create successfully!";

                return RedirectToAction("Index");
            }
            ViewBag.Roles = new SelectList(_Rolecontext.Roles.ToList(), "RoleId", "RoleName");

            return View(user);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var user = _Usercontext.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            ViewBag.Roles = new SelectList(_Rolecontext.Roles.ToList(), "RoleId", "RoleName");

            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(Users user)
        {
            if (ModelState.IsValid)
            {
                _Usercontext.Users.Update(user);
                _Usercontext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var user = _Usercontext.Users.Find(id);

            if (user == null)
            {
                return NotFound();
            }

            _Usercontext.Users.Remove(user);
            _Usercontext.SaveChanges();

            TempData["SuccessMessage"] = "Deleted successfully!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Users user)
        {            
            if (ModelState.IsValid)
            {
                // Hash the password
                user.CreatedDate = DateTime.Now;

                // Check if email is already registered
                if (_Usercontext.Users.Any(u => u.Email == user.Email))
                {
                    ModelState.AddModelError("", "Email already exists.");
                    return View();
                }

                _Usercontext.Users.Add(user);
                _Usercontext.SaveChanges();

                TempData["SuccessMessage"] = "Registration successful! You can now log in.";
                return RedirectToAction("Login");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("", "Email and Password are required.");
                return View();
            }

            var user = _Usercontext.Users.FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user == null)
            {
                ModelState.AddModelError("", "Invalid login credentials.");
                return View();
            }

            // Login successful
            HttpContext.Session.SetString("UserId", user.UserId.ToString());
            return RedirectToAction("Index", "Home");
        }
    }
}

