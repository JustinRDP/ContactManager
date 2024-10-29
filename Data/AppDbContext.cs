using Microsoft.EntityFrameworkCore;
using Assignment_2.Models;

namespace Assignment_2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Category> Categories { get; set; } // Add this line

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Family" },
                new Category { Id = 2, Name = "Friends" },
                new Category { Id = 3, Name = "Work" }
            );

            // Seed Contacts
            modelBuilder.Entity<Contact>().HasData(
                new Contact { Id = 1, firstName = "John", lastName = "Doe", Phone = "1234567890", Email = "john@example.com", CategoryId = 1 },
                new Contact { Id = 2, firstName = "Jane", lastName = "Smith", Phone = "0987654321", Email = "jane@example.com", CategoryId = 2 }
            );
        }
    }
}
