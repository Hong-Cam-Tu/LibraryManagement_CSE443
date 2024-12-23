using LibraryManagement.Models;
using LibraryManagement.Models.Context;
using LibraryManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryManagement.ViewModels;

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
            var list = _Authorcontext.Authors.ToList();
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Authors author, IFormFile PdfFile)
        {
            if (ModelState.IsValid)
            {
                if (PdfFile != null && PdfFile.Length > 0)
                {
                    // Generate unique filename and save path
                    var fileName = $"{Guid.NewGuid()}_{PdfFile.FileName}";
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", fileName);

                    // Ensure the "uploads" directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                    // Save the file
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        PdfFile.CopyTo(stream);
                    }

                    // Save the file path to the model
                    author.PdfFilePath = $"/uploads/{fileName}";
                }
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
        public IActionResult Edit(Authors author, IFormFile? PdfFile)
        {
            // Tìm thông tin tác giả hiện tại trong cơ sở dữ liệu
            var existingAuthor = _Authorcontext.Authors.Find(author.AuthorId);
            if (existingAuthor == null)
            {
                TempData["errorMessage"] = "Author not found!";
                return RedirectToAction("Index");
            }
            if (ModelState.IsValid)
            { // Nếu người dùng upload file PDF mới
                if (PdfFile != null && PdfFile.Length > 0)
                {
                    // Tạo đường dẫn file mới
                    var fileName = $"{Guid.NewGuid()}{Path.GetExtension(PdfFile.FileName)}";
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", fileName);

                    // Đảm bảo thư mục tồn tại
                    Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                    // Lưu file mới
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        PdfFile.CopyTo(stream);
                    }

                    // Xóa file PDF cũ (nếu có)
                    if (!string.IsNullOrEmpty(existingAuthor.PdfFilePath))
                    {
                        var oldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", existingAuthor.PdfFilePath.TrimStart('/'));
                        if (System.IO.File.Exists(oldFilePath))
                        {
                            System.IO.File.Delete(oldFilePath);
                        }
                    }

                    // Cập nhật đường dẫn file PDF mới
                    existingAuthor.PdfFilePath = $"/uploads/{fileName}";
                }
                _Authorcontext.Entry(existingAuthor).CurrentValues.SetValues(author);
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
        public IActionResult ReadPDF(int id)
        {
            var pdf = _Authorcontext.Authors.Find(id);
            if (pdf == null || string.IsNullOrEmpty(pdf.PdfFilePath))
            {
                return NotFound("PDF not found for this book.");
            }
            ViewBag.PdfUrl = pdf.PdfFilePath;
            return View();
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
                model.Authors = _Authorcontext.Authors
           .Where(a => a.FirstName.Contains(model.Keyword) || a.LastName.Contains(model.Keyword))
           .ToList();
            }
            return View(model);
        }
    }
}

