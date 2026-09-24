using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Challenge___5_Pet_Registry_API.Models;
using Challenge___5_Pet_Registry_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Challenge___5_Pet_Registry_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetController : ControllerBase
    {
        private readonly IPetService _pet;

        public PetController(IPetService pet)
        {
            _pet = pet;
        }

         [HttpGet("getallpets")]
        public ActionResult <List<Pet>> GetAll()
        {
            List<Pet> pets = _pet.GetAll();

            return Ok(pets);
        }

        

        [HttpPost("Create")]

        public ActionResult<Pet> Create ([FromBody] Pet newPet)
        {
            Pet createdPet = _pet.Create(newPet);
            return CreatedAtAction(
                nameof(GetAll),
                createdPet 
            );

    }
        [HttpGet("pet/{id}")]
        public ActionResult
}
}