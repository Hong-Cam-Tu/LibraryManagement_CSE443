using LibraryManagement.Models;
using LibraryManagement.Models.Context;
using LibraryManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Controllers
{
    public class CategoryController : Controller

    {
        private readonly CategoryContext _Categorycontext;

        public CategoryController(CategoryContext context)
        {
            _Categorycontext = context;
        }
        public IActionResult Index()
        {

            var list = _Categorycontext.Categories.ToList();
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Categories category)
        {
            if (ModelState.IsValid)
            {
                if (category.CreatedDate == null)
                {
                    category.CreatedDate = DateTime.Now;
                }
                _Categorycontext.Categories.Add(category);
                _Categorycontext.SaveChanges();

                TempData["SuccessMessage"] = "Create successfully!";

                return RedirectToAction("Index");
            }
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine(error.ErrorMessage);
            }

            return View(category);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = _Categorycontext.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Categories category)
        {
            if (ModelState.IsValid)
            {
                var exist = _Categorycontext.Categories.Find(category.CategoryId);
                if (exist == null)
                {
                    return NotFound();
                }

                // Update other fields
                exist.Name = category.Name;
                exist.Description = category.Description;
                exist.IsActive = category.IsActive;

                // Set the UpdatedDate to the current datetime
                exist.UpdatedDate = DateTime.Now;

                // Save changes to the database
                _Categorycontext.Categories.Update(exist);
                _Categorycontext.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var category = _Categorycontext.Categories.Find(id);

            if (category == null)
            {
                return NotFound();
            }

            _Categorycontext.Categories.Remove(category);
            _Categorycontext.SaveChanges();

            TempData["SuccessMessage"] = "Deleted successfully!";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Search()
        {
            return View(new SearchViewModel());
        }

        [HttpPost]
        public IActionResult Search(SearchViewModel model)
        {
            if (!string.IsNullOrEmpty(model.Keyword))
            {
                model.Categories = _Categorycontext.Categories
          .Where(c => c.Name.Contains(model.Keyword))
          .ToList();
            }
            return View(model);

        }
    }
}
