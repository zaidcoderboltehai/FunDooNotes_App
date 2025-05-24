// FunDooNotes_App.DAL/ApplicationDbContext.cs

using Microsoft.EntityFrameworkCore; // Entity Framework Core ko use karne ke liye
using FunDooNotes_App.DAL.Entities; // User aur Note entities ko access karne ke liye

namespace FunDooNotes_App.DAL
{
    // ApplicationDbContext class jo database se connect karne ka kaam karti hai
    public class ApplicationDbContext : DbContext
    {
        // Constructor jo database options ko initialize karega
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        // Users table ko represent karne ke liye DbSet
        public DbSet<User> Users => Set<User>();

        // Notes table ko represent karne ke liye DbSet
        public DbSet<Note> Notes => Set<Note>();

        // Database ke liye extra configurations define karne ke liye method
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Yahan agar relationships configure karne ho to likh sakte ho (e.g., foreign keys, constraints)
        }
    }
}
