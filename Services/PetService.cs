using System;
using System.Collections.Generic;
using System.Linq;
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
            return _db.Pets.ToList();
        }
        
        public Pet Create(Pet newPet)
        {
            newPet.Id = 0;

            _db.Pets.Add(newPet);
            _db.SaveChanges();

            return newPet;
        }

        public bool Adopt(int id, Pet pet)
        {
            Pet? existingPet = _db.Pets.FirstOrDefault(c => c.Id == id);

            if (existingPet == null)
            {
                return false;
            }

            existingPet.IsAdopted = pet.IsAdopted;
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

            if(existing == null)
            {
                return false;
            }

            existing.Name = item.Name;
            existing.Species = item.Species;
            existing.Breed = item.Breed;
            existing.Age = item.Age;
            existing.IsAdopted = item.IsAdopted;
            existing.IsDeleted = item.IsDeleted;

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

        public bool Restore(int id)
        {
            Pet? existingPet = _db.Pets.FirstOrDefault(c => c.Id == id);

            if (existingPet == null)
            {
                return false;
            }

            existingPet.IsDeleted = false;
            _db.SaveChanges();

            return true;
        }

    }
}