using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }

        [StringLength(50)]
        public string? Fullname { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }
        public int? RoleId { get; set; }
        public string? Address { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public string? Avatar { get; set; }

        // Navigation property for related Loans
        public ICollection<Loans>? Loans { get; set; }
    }
}
