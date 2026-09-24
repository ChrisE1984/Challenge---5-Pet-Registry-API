using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge___5_Pet_Registry_API.Models
{
    public class Pet
    {
            public int Id {get; set;}
            public string Name {get; set;}
            public string Species {get; set;}
            public string Breed {get; set;}
            public int Age {get; set;}
            public bool IsAdopted {get; set;}
            public bool IsDeleted {get; set;}
    }
}