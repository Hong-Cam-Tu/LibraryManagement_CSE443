using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Models.Context
{
    public class CategoryContext:DbContext
    {
        public CategoryContext(DbContextOptions<CategoryContext> options) : base(options)
        {
        }
        public DbSet<Categories> Categories { get; set; }
    }
}
