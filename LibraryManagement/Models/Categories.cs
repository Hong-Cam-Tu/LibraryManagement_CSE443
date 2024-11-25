using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class Categories
    {
        [Key]
        public int CategoryId { get; set; }


        [StringLength(50)]
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public string? Avatar { get; set; }

        // Navigation property for related Books
        //one-to-many
         /*public ICollection<Books> Books { get; set;}*/
    }
}
