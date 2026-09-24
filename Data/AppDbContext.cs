using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Challenge___5_Pet_Registry_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Challenge___5_Pet_Registry_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        //this IS the Students table as  far as our C# code is concerned
        public DbSet<Pet> Pets {get; set;}
    }
}