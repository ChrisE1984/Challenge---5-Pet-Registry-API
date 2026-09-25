using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge___5_Pet_Registry_API.Models
{
    public class Staff : BaseEntity
    {
        public string FirstName {get;set;} = string.Empty;
        public string LastName {get;set;} = string.Empty;
        public string Email {get;set;} = string.Empty;
        public string Salary {get;set;} = string.Empty;
        public string JobPosition {get;set;} = string.Empty;
        public bool? IsWorking {get;set;} = null;
        
    }
}