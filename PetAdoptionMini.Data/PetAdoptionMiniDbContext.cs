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
    }
}
