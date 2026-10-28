using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdoptionMini.Data.Entities
{
    public class PetSpecies
    {
        public int PetSpeciesId { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        public ICollection<Pet> Pets { get; set; } = new List<Pet>();
    }
}
