using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Models.Context
{
    public class AuthorContext : DbContext
    {
        public AuthorContext(DbContextOptions<AuthorContext> options) : base(options)
        {
        }
        public DbSet<Authors> Authors { get; set; }

    }
}
