using PetAdoptionMini.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace PetAdoptionMini.Data.Entities
{
    public class Pet
    {
        public Guid PetId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string Species { get; set; } = string.Empty;
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "The age cannot be negative.")]
        public int Age { get; set; }
        public string Description { get; set; } = string.Empty;
        public PetStatus Status { get; set; } = PetStatus.SearchingForHome;
        [Required]
        public int PetSpeciesId { get; set; }
        public PetSpecies? AnimalSpecies { get; set; }

        [Required]
        public Guid ShelterId { get; set; }
        public Shelter? Shelter { get; set; }
        public Guid? AdopterId { get; set; }
        public Adopter? Adopter { get; set; }
    }
}
