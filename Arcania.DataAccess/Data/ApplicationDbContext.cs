using Arcania.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Arcania.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Race> Races { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure your identity and other entities here

            // Seed the races
            modelBuilder.Entity<Race>().HasData(
                new Race { Id = 1, Name = "Human", Description = "The versatile and adaptable human race." },
                new Race { Id = 2, Name = "Dwarf", Description = "The stout and hearty dwarf race." },
                new Race { Id = 3, Name = "Elf", Description = "The graceful and agile elf race." },
                new Race { Id = 4, Name = "Gnome", Description = "The clever and inventive gnome race." },
                new Race { Id = 5, Name = "Ogre", Description = "The powerful and intimidating ogre race." }
            );
        }
    }
}
