using CRUD_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Application.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Gallery> Gallery { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3 }
                ); 
            modelBuilder.Entity<Gallery>().HasData(
                new Gallery{Id = 1, UserName = "Vasco", Description = "A simple Description", ImageURL = "outum" },
                new Gallery{Id = 2, UserName = "Daniel", Description = "A simpler Description", ImageURL = "outum" },
                new Gallery{Id = 3, UserName = "Antonio", Description = "The simplest Description", ImageURL = "outum"  }
                );

        }
    }
}
