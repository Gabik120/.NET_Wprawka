using Microsoft.EntityFrameworkCore;
using Wprawka1.Models;

namespace Wprawka1.Data
{
    public class Biblioteka : DbContext
    {
        public Biblioteka(DbContextOptions options) :
            base(options) { }
        public DbSet<Wydawca> Wydawcy { get; set; }
        public DbSet<Ksiazka> Ksiazki { get; set; }
        public DbSet<Czytelnik> Czytelnicy { get; set; }
        public DbSet<Wypozyczenie> Wypozyczenia { get; set; }

        protected override void OnModelCreating(ModelBuilder
            modelBuilder)
        {
            modelBuilder.Entity<Czytelnik>()
                .HasMany(e => e.Wypozyczenia)
                .WithOne(e => e.czytelnik);
        }
    }
}
