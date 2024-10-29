using Microsoft.EntityFrameworkCore;
using Assignment_2.Models;

namespace Assignment_2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Category> Categories { get; set; } // Ensure this is added
    }
}
