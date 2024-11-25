using LibraryManagement.Models;
using LibraryManagement.Models.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.InteropServices;

namespace LibraryManagement.Controllers
{
    public class LoanController : Controller
    {
        private readonly LoanContext _LoanContext;
        private readonly UserContext _UserContext;
        private readonly BookContext _BookContext;

        public LoanController(LoanContext loanContext, UserContext userContext, BookContext bookContext)
        {
            _LoanContext = loanContext;
            _UserContext = userContext;
            _BookContext = bookContext;
        }
        public IActionResult Index()
        {
            var list = _LoanContext.Loans.ToList();
            return View(list);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Users = new SelectList(_UserContext.Users.ToList(), "UserId", "UserName");
            ViewBag.Books = new SelectList(_BookContext.Books.ToList(), "BookId", "Title");

            return View();
        }
        [HttpPost]
        public IActionResult Create(Loans loan)
        {
            if (ModelState.IsValid)
            {
                if (loan.LoanDate == null)
                {
                    loan.LoanDate = DateTime.Now;
                }
                _LoanContext.Loans.Add(loan);
                _LoanContext.SaveChanges();

                TempData["SuccessMessage"] = "Created successfully!";

                return RedirectToAction("Index");
            }
            ViewBag.Users = new SelectList(_UserContext.Users.ToList(), "UserId", "UserName");
            ViewBag.Books = new SelectList(_BookContext.Books.ToList(), "BookId", "Title");

            return View(loan);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var loan = _LoanContext.Loans.Find(id);
            if (loan == null)
            {
                return NotFound();
            }
            ViewBag.Users = new SelectList(_UserContext.Users.ToList(), "UserId", "UserName");
            ViewBag.Books = new SelectList(_BookContext.Books.ToList(), "BookId", "Title");

            return View(loan);
        }

        [HttpPost]
        public IActionResult Edit(Loans loan)
        {
            if (ModelState.IsValid)
            {
                _LoanContext.Loans.Update(loan);
                _LoanContext.SaveChanges();
                TempData["SuccessMessage"] = "Updated successfully!";
                return RedirectToAction("Index");
            }
            ViewBag.Users = new SelectList(_UserContext.Users.ToList(), "UserId", "UserName");
            ViewBag.Books = new SelectList(_BookContext.Books.ToList(), "BookId", "Title");

            return View(loan);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var loan = _LoanContext.Loans.Find(id);
            if (loan == null)
            {
                return NotFound();
            }

            _LoanContext.Loans.Remove(loan);
            _LoanContext.SaveChanges();
            TempData["SuccessMessage"] = "Deleted successfully!";

            return RedirectToAction("Index");
        }
    }
}
