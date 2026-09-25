using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Challenge___5_Pet_Registry_API.Models;

namespace Challenge___5_Pet_Registry_API.Services
{
    public interface IStaffService
    {
        List<Staff> GetAll();
        Staff GetById(int id);
        Staff Create(Staff staff);
        Staff Patch (int id, Staff changes);
        
    }
}