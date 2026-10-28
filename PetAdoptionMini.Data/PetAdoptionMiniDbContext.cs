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
        public DbSet<PetSpecies> PetSpecies => Set<PetSpecies>();

        public DbSet<Shelter> Shelters => Set<Shelter>();

        public DbSet<Adopter> Adopters => Set<Adopter>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PetSpecies>(entity =>
            {
                entity.HasKey(s => s.PetSpeciesId);

                entity.Property(s => s.Name).IsRequired().HasMaxLength(100);

                entity.HasIndex(s => s.Name).IsUnique();
            });

            modelBuilder.Entity<Pet>(entity =>
            {
                entity.HasKey(a => a.PetId);

                entity.Property(a => a.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(a => a.Age).IsRequired();

                entity.Property(a => a.Description).HasMaxLength(2000);

                entity.Property(a => a.Status).IsRequired();

                entity.HasOne(a => a.PetSpecies)
                    .WithMany(s => s.Pets)
                    .HasForeignKey(a => a.PetSpeciesId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(a => a.Shelter)
                    .WithMany(s => s.Pets)
                    .HasForeignKey(a => a.ShelterId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(a => a.Adopter)
                    .WithMany(ad => ad.AdoptedPets)
                    .HasForeignKey(a => a.AdopterId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Shelter>(entity =>
            {
                entity.HasKey(s => s.ShelterId);

                entity.Property(s => s.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(s => s.Settlement)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(s => s.Address)
                    .HasMaxLength(250);

                entity.Property(s => s.Phone)
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Adopter>(entity =>
            {
                entity.HasKey(a => a.AdopterId);

                entity.Property(a => a.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(a => a.Email)
                    .IsRequired()
                    .HasMaxLength(254);

                entity.HasIndex(a => a.Email)
                    .IsUnique();

                entity.Property(a => a.Phone)
                    .HasMaxLength(30);
            });
        }
    }
}