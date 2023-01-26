using FilmDB.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FilmDB.Data
{
    public class FilmContext : IdentityDbContext
    {
        public FilmContext(DbContextOptions<FilmContext> options): base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        public DbSet<FilmModel> Films { get ; set; }
    }
}
