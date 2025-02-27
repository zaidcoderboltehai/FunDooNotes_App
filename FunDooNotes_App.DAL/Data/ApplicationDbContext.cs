// FunDooNotes_App.DAL/ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;
using FunDooNotes_App.DAL.Entities;

namespace FunDooNotes_App.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Note> Notes => Set<Note>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Yahan agar relationships configure karne ho to likh sakte ho
        }
    }
}
