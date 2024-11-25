using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace LibraryManagement.Models
{
    public class Carousel
    {
        [Key]
        public int CarouselId { get; set; }

        [Required]
        [MaxLength]
        public string ImageUrl{ get; set; }

        [Required]
        public string Title { get; set; }

        [MaxLength]
        public string? Description {  get; set; }

        [MaxLength]
        public string? LinkUrl { get; set; }
        [Required]
        public int Order {  get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
