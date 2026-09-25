using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Challenge___5_Pet_Registry_API.Models;
using Challenge___5_Pet_Registry_API.Data;

namespace Challenge___5_Pet_Registry_API.Services
{
    public class StaffService : IStaffService
    {
        private readonly AppDbContext _db;

        public StaffService(AppDbContext db)
        {
            _db = db;
        }
        public List<Staff> GetAll()
        {
            return _db.Staff.ToList();
        }
        public Staff Create(Staff newStaff)
        {
            newStaff.Id = 0;

            _db.Staff.Add(newStaff);
            _db.SaveChanges();

            return newStaff;
        }
        public Staff GetById(int id)
        {
            Staff? item = _db.Staff.FirstOrDefault(c => c.Id == id);

            return item;

        }

        public Staff Patch(int id, Staff changes)
        {
            Staff? existingStaff = _db.Staff.Find(id);
             if (existingStaff == null)
            {
                return null;
            }
             if (!string.IsNullOrWhiteSpace(changes.Salary))
            {
                existingStaff.Salary = changes.Salary;
            }
        
            if (!string.IsNullOrWhiteSpace(changes.JobPosition))
            {
                existingStaff.JobPosition = changes.JobPosition;
            }

            _db.SaveChanges();
            return existingStaff;

        }
    }
}