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


    }
}
