using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models

{
    public class Books
    {
        [Key]
        public int BookId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? BookCode { get; set; }
        public string? Publisher { get; set; }
        public DateTime? PublishedYear { get; set; }
        public int CategoryId { get; set; }
        public int? AuthorId { get; set; }
        public int? TotalCopies { get; set; }
        public int? AvailableCopies { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? Avatar { get; set; }
        public string? Pdf { get; set; }
        public bool? IsActive { get; set; }

        // Navigation properties for Category, Author, and related Loans
        /// one-to-one
        public Categories? Category { get; set; }
        public Authors? Author { get; set; }
        /// one-to-many
        public ICollection<Loans>? Loans { get; set; }

    }
}
