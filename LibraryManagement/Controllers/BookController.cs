using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Models;
using LibraryManagement.Models.Context;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;
using System.Net;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.CompilerServices;
namespace LibraryManagement.Controllers
{
    public class BookController : Controller
    {
        private readonly BookContext _Bookcontext;
        private readonly AuthorContext _authorContext;
        private readonly CategoryContext _categoryContext;
        public BookController(BookContext context, CategoryContext categoryContext, AuthorContext authorContext)
        {
            _Bookcontext = context;
            _categoryContext = categoryContext;
            _authorContext = authorContext;
        }

        public IActionResult Index()
        {
            var list = _Bookcontext.Books.ToList();
            return View(list);
        }
        public IActionResult BookDetail(int id)
        {
            var book = _Bookcontext.Books.Where(b => b.BookId == id);
            ViewBag.Book = book;
            return View(book);
        }
        public IActionResult Category(int categoryId)
        {
            var book = _Bookcontext.Books.Where(b => b.CategoryId == categoryId).ToList();
            ViewBag.Book = book;
            Console.WriteLine(book);
            return View();
        }

        public IActionResult ReadPDF(int id)
        {
            var book = _Bookcontext.Books.Find(id);
            if (book == null || string.IsNullOrEmpty(book.Pdf))
            {
                return NotFound("PDF not found for this book.");
            }
            ViewBag.PdfUrl = book.Pdf;
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
 
           ViewBag.Authors = new SelectList(_authorContext.Authors.Select(a => new { AuthorId = a.AuthorId, FullName = a.FirstName + " " + a.LastName })
            .ToList(),
            "AuthorId",
            "FullName"
            );
            ViewBag.Categories = new SelectList(_categoryContext.Categories.ToList(), "CategoryId", "Name");

            return View();
        }
        [HttpPost]
        public IActionResult Create(Books book)
        {
            if (ModelState.IsValid)
            {
                if (book.CreatedDate == null)
                {
                    book.CreatedDate = DateTime.Now;
                }
                _Bookcontext.Books.Add(book);
                _Bookcontext.SaveChanges();

                TempData["SuccessMessage"] = "Created successfully!";

                return RedirectToAction("Index");
            }
            ViewBag.Authors = new SelectList(_authorContext.Authors.Select(a => new { AuthorId = a.AuthorId, FullName = a.FirstName + " " + a.LastName })
           .ToList(),
           "AuthorId",
           "FullName"
           );
            ViewBag.Categories = new SelectList(_categoryContext.Categories.ToList(), "CategoryId", "Name");
            return View(book);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var book = _Bookcontext.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            ViewBag.Authors = new SelectList(_authorContext.Authors.Select(a => new { AuthorId = a.AuthorId, FullName = a.FirstName + " " + a.LastName })
             .ToList(),
             "AuthorId",
             "FullName"
             ); 
            ViewBag.Categories = new SelectList(_categoryContext.Categories.ToList(), "CategoryId", "Name");
            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Books book)
        {
            if (ModelState.IsValid)
            {
                _Bookcontext.Books.Update(book);
                _Bookcontext.SaveChanges();
                TempData["SuccessMessage"] = "Updated successfully!";
                return RedirectToAction("Index");
            }
            ViewBag.Authors = new SelectList(_authorContext.Authors.Select(a => new { AuthorId = a.AuthorId, FullName = a.FirstName + " " + a.LastName })
           .ToList(),
           "AuthorId",
           "FullName"
           );
            ViewBag.Categories = new SelectList(_categoryContext.Categories.ToList(), "CategoryId", "Name");
            return View(book);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var book = _Bookcontext.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            _Bookcontext.Books.Remove(book);
            _Bookcontext.SaveChanges();
            TempData["SuccessMessage"] = "Deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}
