using FilmDB.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FilmDB.ViewModels;

namespace FilmDB
{
    public class FilmContext : IdentityDbContext
    {
        public FilmContext(DbContextOptions<FilmContext> options): base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<GenreModel>()
            .HasMany(c => c.Films)
            .WithOne(e => e.Genre);

            builder.Entity<GenreModel>()
                .HasKey(o => o.GenreID);

            builder.Entity<FilmActor>()
                .HasKey(bc => new { bc.FilmModelID, bc.ActorModelID });
            builder.Entity<FilmModel>()
                .HasMany(f => f.FilmActors)
                .WithOne(fa => fa.Film)
                .HasForeignKey(fa => fa.FilmModelID);
            builder.Entity<ActorModel>()
                .HasMany(a => a.FilmActors)
                .WithOne(fa => fa.Actor)
                .HasForeignKey(fa => fa.ActorModelID);
        }

        public DbSet<FilmModel> Films { get; set; }
        public DbSet<GenreModel> GenreModels { get; set; }
        public DbSet<ActorModel> Actors { get; set; }

    }
}
