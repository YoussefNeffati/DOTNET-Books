using Microsoft.EntityFrameworkCore;
using ASP.Server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.Server.Database
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Auteur> Auteurs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().ToTable("Book");
            modelBuilder.Entity<Genre>().ToTable("Genre");
            modelBuilder.Entity<Auteur>().ToTable("Auteur");

            // Définir la relation many-to-many entre les livres et les genres
            modelBuilder.Entity<Book>()
                .HasMany(b => b.Genres)
                .WithMany(g => g.Books)
                .UsingEntity(j => j.ToTable("BookGenre"));

            // Définir la relation many-to-one entre les livres et les auteurs
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Auteur)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuteurId);
        }
    }
}
