using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Challenge___5_Pet_Registry_API.Models;

namespace Challenge___5_Pet_Registry_API.Services
{
    public interface IPetService
    {
        List<Pet> GetAll();
        Pet GetById(int id);
        Pet Create(Pet pet);
        bool Adopt(int id);
        bool Update(int id, Pet pet);
        bool Delete(int id);
        Pet Patch (int id, Pet pet);
        Pet Replace (int id, Pet pet);
       
    }
}