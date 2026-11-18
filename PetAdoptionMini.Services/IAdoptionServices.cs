using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetAdoptionMini.Data.Entities;

namespace PetAdoptionMini.Services
{
    public   interface IAdoptionServices
    {
        Task<List<Pet>> GetAll();
    }
}
