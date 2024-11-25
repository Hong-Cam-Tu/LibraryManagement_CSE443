using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class Loans
    {
        [Key]
        public int LoanId { get; set; }

        public int? UserId { get; set; }

        public int? BookId { get; set; }
        public DateTime? LoanDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        // Navigation properties for User and Book
        public Users? User { get; set; }
        public Books? Book { get; set; }

    }
}
