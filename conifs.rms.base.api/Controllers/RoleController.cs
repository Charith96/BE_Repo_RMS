using conifs.rms.data;
using conifs.rms.data.entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace conifs.rms.@base.api.Controllers
{
    [Route("api/[controller]")]
[ApiController]
public class RoleController : ControllerBase
{

        private readonly ApplicationDbContext _context;
        private object? croles;

        public RoleController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet] //get all the roles data
        public async Task<ActionResult<List<Role>>> GetAllCroles()
        {
            var croles = await _context.Roles.ToListAsync();

            return Ok(croles);
        }

        [HttpGet("{id}")]  //Get particular role data using row id 
        public async Task<ActionResult<List<Role>>> GetCrole(int id)
        {
            var crole = await _context.Roles.FindAsync(id);
            if (crole is null)
                return NotFound("Role not found.");

            return Ok(crole);
        }


        [HttpPost]   //Create a new role 
        public async Task<ActionResult<List<Role>>> AddCrole(Role crole)
        {
            _context.Roles.Add(crole);
            await _context.SaveChangesAsync();

            return Ok(await _context.Roles.ToListAsync());
        }

        [HttpPut]//Update a particular role data (for a given row id)
        public async Task<ActionResult<List<Role>>> UpdateCrole(Role updatedCrole)
        {

            if (updatedCrole == null)
                return BadRequest("Invalid role data.");

            var dbCrole = await _context.Roles.FindAsync(updatedCrole.Id);
            if (dbCrole == null)
                return NotFound("Role not found.");

            dbCrole.RoleId = updatedCrole.RoleId;
            dbCrole.RoleName = updatedCrole.RoleName;

            await _context.SaveChangesAsync();

            return Ok(await _context.Roles.ToListAsync());
        }

        [HttpDelete]//Delete a particular role data(for a given id)
        public async Task<ActionResult<List<Role>>> DeletCrole(int id)
        {
            var dbCrole = await _context.Roles.FindAsync(id);
            if (dbCrole is null)
                return NotFound("Role not found.");

            _context.Roles.Remove(dbCrole);
            await _context.SaveChangesAsync();

            return Ok(await _context.Roles.ToListAsync());
        }
    }
}
