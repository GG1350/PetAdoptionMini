using Microsoft.EntityFrameworkCore;
using PetAdoptionMini.Data;
using PetAdoptionMini.Data.Entities;
using PetAdoptionMini.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdoptionMini.Services
{
    public class AdoptionServices : IAdoptionServices
    {
        private readonly PetAdoptionMiniDbContext _db;

        public AdoptionServices(PetAdoptionMiniDbContext db)
        {
            _db = db;
        }

        public Task<List<Pet>> GetAll()
        {
            return _db.Pets
                .OrderBy(p => p.Name)
                .ToListAsync(); 
        }

        public async Task Create(string name, int age, string description, string species, Guid shelterId)
        {
            var _species = await _db.PetSpecies
                .FirstOrDefaultAsync(s => s.Name == species);

            if (_species is null)
            {
                _species = new PetSpecies
                {
                    PetSpeciesId = Guid.NewGuid(),
                    Name = species
                };

                _db.PetSpecies.Add(_species);
            }

            var shelter = await _db.Shelters
                .FirstOrDefaultAsync(s => s.ShelterId == shelterId);

            if (shelter is null)
            {
                throw new Exception("Shelter not found!");
            }

            var pet = new Pet
            {
                PetId = Guid.NewGuid(),
                Name = name,
                Age = age,
                Description = description,
                Status = PetStatus.SearchingForHome,
                PetSpeciesId = _species.PetSpeciesId,
                PetSpecies = _species,
                ShelterId = shelter.ShelterId,
                Shelter = shelter
            };

            _db.Pets.Add(pet);
            await _db.SaveChangesAsync();
        }
    }
}
