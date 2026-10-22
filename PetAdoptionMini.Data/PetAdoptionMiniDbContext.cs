using PetAdoptionMini.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace PetAdoptionMini.Data
{
    public class PetAdoptionMiniDbContext : DbContext
    {
        public PetAdoptionMiniDbContext(DbContextOptions<PetAdoptionMiniDbContext> options) : base(options)
        {

        }
        public DbSet<Pet> Pets => Set<Pet>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure the Pet entity
            modelBuilder.Entity<Pet>(entity =>
            {
                entity.HasKey(p => p.PetId);

                entity.Property(p => p.Name).IsRequired().HasMaxLength(50);

                entity.Property(p => p.Species).IsRequired().HasMaxLength(50);

                entity.Property(p => p.Age).IsRequired();

                entity.Property(p => p.Description).HasMaxLength(500);
                    
                entity.Property(p => p.Status).IsRequired();
            });
        }
    }
}
