using Microsoft.EntityFrameworkCore;
using Assignment_2.Models;

namespace Assignment_2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // Optionally, seed some initial contacts
            modelBuilder.Entity<Contact>().HasData(
                new Contact
                {
                    Id = 97,
                    firstName = "Connor",
                    lastName = "McDavid",
                    Phone = "9797979797",
                    Email = "connor.oiler@gmail.com",
                    Category = "Other", // Replace with CategoryId if you're using IDs
                    Organization = "Oilers",
                    DateAdded = DateTime.Now // Use DateTime.Now or a fixed date
                },
                new Contact
                {
                    Id = 29,
                    firstName = "Leon",
                    lastName = "Draisaitl",
                    Phone = "2929292929",
                    Email = "leon.oiler@gmail.com",
                    Category = "Other", // Replace with CategoryId if you're using IDs
                    Organization = "Oilers",
                    DateAdded = DateTime.Now // Use DateTime.Now or a fixed date
                }
            );
        }
    }
}
