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
    public class StaffController : ControllerBase
    {
           private readonly IStaffService _staff;
      

        public StaffController(IStaffService staff)
        {
            _staff = staff;
        }

        [HttpGet("getallstaff")]
        public ActionResult<List<Staff>> GetAll()
        {
            List<Staff> staff = _staff.GetAll();

            return Ok(staff);
        }
        [HttpPost("create")]

        public ActionResult<Staff> Create([FromBody] Staff newStaff)
        {
            Staff createdStaff = _staff.Create(newStaff);
            return CreatedAtAction(
                nameof(GetAll),
                createdStaff
            );

        }

        [HttpPatch("patch/{id}")]
        public ActionResult<Staff> Patch (int id, [FromBody] Staff changes)
        {
            Staff? change = _staff.Patch(id, changes);

            if (change is null)
            {
                return NotFound($"No staff with that id {id}");
            }

            return NoContent();
        }


    }
}