using FilmDB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FilmDB.Data
{
    public class FilmContext : IdentityDbContext<IdentityUser>
    {
        public FilmContext(DbContextOptions<FilmContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        public DbSet<FilmModel> Films { get; set; }
        public DbSet<GenreModel> Genres { get; set; }
    }
}