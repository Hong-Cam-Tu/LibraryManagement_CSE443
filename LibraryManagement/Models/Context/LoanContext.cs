using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Models.Context
{
    public class LoanContext : DbContext
    {
        public LoanContext(DbContextOptions<LoanContext> options) : base(options)
        {
        }
        public DbSet<Loans> Loans { get; set; }
    }
}
