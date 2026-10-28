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
        public int AdopterId { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; } = string.Empty;
        [Required, EmailAddress, StringLength(150)]
        public string Email { get; set; } = string.Empty;
        [Phone, StringLength(30)]
        public string? Phone { get; set; }
        public ICollection<Pet> AdoptedAnimals { get; set; } = new List<Pet>();
    }
}
