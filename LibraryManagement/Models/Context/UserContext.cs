using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Models.Context
{
    public class UserContext:DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }
        public DbSet<Users> Users { get; set; }
    }
}
