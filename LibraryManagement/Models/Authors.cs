using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class Authors
    {
        [Key]
        public int AuthorId { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Biography { get; set; }

        [StringLength(50)]
        public string? Nationality { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string? PdfFilePath { get; set; }

        // Navigation property for related Books
        /// one-to-many
/*        public ICollection<Books> Books { get; set; }
*/    }
}
