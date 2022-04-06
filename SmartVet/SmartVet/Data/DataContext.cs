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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AnimalSpecie>().HasIndex(c => c.Name).IsUnique();
        }
    }
}
