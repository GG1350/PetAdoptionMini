using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdoptionMini.Data.Entities
{
    public class Shelter
    {
        public Guid ShelterId { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [Required, MaxLength(80)]
        public string Settlement { get; set; } = string.Empty;
        [MaxLength(200)]
        public string? Address { get; set; }
        [Phone, MaxLength(30)]
        public string? Phone { get; set; }
        public ICollection<Pet> Pets { get; set; } = new List<Pet>();
    }
}
