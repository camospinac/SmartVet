using Microsoft.EntityFrameworkCore;
using SmartVet.Data.Entities;

namespace SmartVet.Data
{
    public class DataContext : DbContext { 
    
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<AnimalSpecie> AnimalSpecies { get; set; }
        public DbSet<Procedure> Procedures { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<AnimalBreed> AnimalBreeds { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AnimalSpecie>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<DocumentType>().HasIndex(d => d.Name).IsUnique();
            modelBuilder.Entity<AnimalBreed>().HasIndex(a => a.Name).IsUnique();
        }
    }
}
