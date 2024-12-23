using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Models.Context
{
    public class LibraryContext: DbContext
    {
        public LibraryContext(DbContextOptions<AuthorContext> options) : base(options)
        {
        }
        /*public DbSet<Authors> Authors { get; set; }*/

    }
}
