using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Models.Context
{
    public class RoleContext:DbContext
    {
        public RoleContext(DbContextOptions<RoleContext> options) : base(options)
        {
        }
        public DbSet<Roles> Roles { get; set; }
    }
}
