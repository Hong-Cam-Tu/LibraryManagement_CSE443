using LibraryManagement.Models;
using LibraryManagement.Models.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Controllers
{
    public class AuthorController : Controller
    {
        private readonly AuthorContext _Authorcontext;

        public AuthorController(AuthorContext context)
        {
            _Authorcontext = context;
        }
        public IActionResult Index()
        {
            var list= _Authorcontext.Authors.ToList();
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Authors author)
        {
            if (ModelState.IsValid)
            {
                author.CreatedDate = DateTime.Now;
                _Authorcontext.Authors.Add(author);
                _Authorcontext.SaveChanges();
                TempData["SuccessMessage"] = "Author created successfully!";
                return RedirectToAction("Index");
            }
            return View(author);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var author = _Authorcontext.Authors.Find(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        [HttpPost]
        public IActionResult Edit(Authors author)
        {
            if (ModelState.IsValid)
            {
                _Authorcontext.Authors.Update(author);
                _Authorcontext.SaveChanges();
                TempData["SuccessMessage"] = "Author updated successfully!";
                return RedirectToAction("Index");
            }
            return View(author);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var author = _Authorcontext.Authors.Find(id);
            if (author == null)
            {
                return NotFound();
            }

            _Authorcontext.Authors.Remove(author);
            _Authorcontext.SaveChanges();
            TempData["SuccessMessage"] = "Author deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}
