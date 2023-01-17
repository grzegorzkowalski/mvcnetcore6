using FilmDB.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmDB.Data
{
    public class FilmContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public FilmContext (IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));   
        }

        public DbSet<FilmModel> Films { get; set; }
    }
}
