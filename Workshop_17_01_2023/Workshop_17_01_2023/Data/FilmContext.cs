﻿using FilmDB.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmDB.Data
{
    public class FilmContext : DbContext
    {
        public FilmContext(DbContextOptions<FilmContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        public DbSet<FilmModel> Films { get; set; }
    }
}
