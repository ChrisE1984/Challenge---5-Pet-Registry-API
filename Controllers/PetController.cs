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
        public ActionResult<List<Pet>> GetAll()
        {
            List<Pet> pets = _pet.GetAll();


            return Ok(pets);
        }

        [HttpPost("create")]

        public ActionResult<Pet> Create([FromBody] Pet newPet)
        {
            Pet createdPet = _pet.Create(newPet);
            return CreatedAtAction(
                nameof(GetAll),
                createdPet
            );

        }
        
        [HttpGet("pets/{id}")]
        public ActionResult<Pet> GetById (int id)
        {
            Pet item = _pet.GetById(id);

            if(item == null)
            {
                return NotFound($"There is no pet with id {id}");
            }

            return Ok(item);
        }   

        [HttpPut("update/{id}")]
        public ActionResult<bool> UpdatePet(int id, Pet item)
        {
            bool updated = _pet.Update(id, item);
            if(updated == false)
            {
                return NotFound($"There is no pet with id {id}");
            }

            return NoContent();
        }

        [HttpPut("adopt/{id}")]
        public ActionResult AdoptPet(int id)
        {
            bool adopted = _pet.Adopt(id);
            if(adopted == false)
            {
                return NotFound($"There is no pet with id {id}");
            }

            return Ok($"You have adopted pet {id}");
        }   

        [HttpDelete("delete/{id}")]
        public ActionResult <bool> DeletePet (int id)
        {
            bool deleted =_pet.Delete(id);
            if (deleted == false)
            {
                return NotFound($"There is no pet with id {id}");
            }

            return NoContent();
        }
        [HttpPatch("patch/{id}")]
         public ActionResult<Pet> Patch (int id, [FromBody] Pet changes)
        {
            Pet? change = _pet.Patch(id, changes);

            if(change is null)
            {
                return NotFound($"No pet with id {id}");
            }

            return NoContent();


    }
}
}