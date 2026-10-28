using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdoptionMini.Data.Entities
{
    public class Adopter
    {
        public Guid AdopterId { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [Required, EmailAddress, MaxLength(150)]
        public string Email { get; set; } = string.Empty;
        [Phone, MaxLength(30)]
        public string? Phone { get; set; }
        public ICollection<Pet> AdoptedAnimals { get; set; } = new List<Pet>();
    }
}
