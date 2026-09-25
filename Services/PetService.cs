using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Challenge___5_Pet_Registry_API;
using Challenge___5_Pet_Registry_API.Data;
using Challenge___5_Pet_Registry_API.Models;

namespace Challenge___5_Pet_Registry_API.Services
{
    public class PetService : IPetService
    {
        private readonly AppDbContext _db;

        public PetService(AppDbContext db)
        {
            _db = db;
        }

        public List<Pet> GetAll()
        {
            return _db.Pets.Where(pet => !pet.IsDeleted).ToList();
        }

        public Pet Create(Pet newPet)
        {
            newPet.Id = 0;

            _db.Pets.Add(newPet);
            _db.SaveChanges();

            return newPet;
        }

        public bool Adopt(int id)
        {
            Pet? existingPet = _db.Pets.FirstOrDefault(c => c.Id == id);

            if (existingPet == null)
            {
                return false;
            }

            existingPet.IsAdopted = true;
            _db.SaveChanges();

            return true;
        }

        public Pet GetById(int id)
        {
            Pet? item = _db.Pets.FirstOrDefault(c => c.Id == id);

            return item;

        }
        public bool Update(int id, Pet item)
        {

            //first or default checks the list against the conditions c.Id == id
            //returns the first result or defaults to null
            Pet? existing = _db.Pets.FirstOrDefault(c => c.Id == id);

            if (existing == null)
            {
                return false;
            }

            existing.Name = item.Name;
            existing.Species = item.Species;
            existing.Breed = item.Breed;
            existing.Age = item.Age;
            existing.IsAdopted = item.IsAdopted;
            existing.IsDeleted = item.IsDeleted;

            _db.SaveChanges();
            
            return true;
        }
        public bool Delete(int id)
        {
            Pet? existingPet = _db.Pets.FirstOrDefault(c => c.Id == id);

            if (existingPet == null)
            {
                return false;
            }

            existingPet.IsDeleted = true;
            _db.SaveChanges();

            return true;
        }

        public Pet Replace(int id, Pet pet)
        {
            Pet? existingPet = _db.Pets.Find(id);

            if (existingPet == null)
            {
                return null;
            }

            existingPet.Name = existingPet.Name;
            existingPet.Species = existingPet.Species;
            existingPet.Breed = existingPet.Breed;
            existingPet.Age = existingPet.Age;
            existingPet.IsAdopted = existingPet.IsAdopted;
            existingPet.IsDeleted = existingPet.IsDeleted;
            _db.SaveChanges();

            return existingPet;
        }

        public Pet Patch(int id, Pet changes)
        {
            Pet? existingPet = _db.Pets.Find(id);
             if (existingPet == null)
            {
                return null;
            }
            existingPet.IsDeleted = changes.IsDeleted;
            existingPet.IsAdopted = changes.IsAdopted;  
            _db.SaveChanges();
            return existingPet;

        }

      
    }
}