using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace LibraryManagement.data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {


        }

        public DbSet<Books> Books { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Loans> Loans { get; set; }
        public DbSet<Authors> Authors { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Carousel> Carousels { get; set; }
    }
}
