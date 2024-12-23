using LibraryManagement.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace LibraryManagement.data
{
    public class LibraryDbContext : IdentityDbContext<IdentityUser>
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
