using conifs.rms.data;
using conifs.rms.data.entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace conifs.rms.@base.api.Controllers
{
    [Route("api/[controller]")]
[ApiController]
public class PrivilegeController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public PrivilegeController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]//show all the privilege data 
    public async Task<ActionResult<List<Privilege>>> GetAllPrvl()
    {
        var prvl = await _context.Privileges.ToListAsync();

        return Ok(prvl);
    }

    [HttpGet("{id}")]//show particular privilege data for a given row id
    public async Task<ActionResult<List<Privilege>>> GetPrvl(int id)
    {
        var prvl = await _context.Privileges.FindAsync(id);
        if (prvl is null)
            return NotFound("Privilege not found.");

        return Ok(prvl);
    }

    [HttpPost]//Create a new privilege 
    public async Task<ActionResult<List<Privilege>>> AddCrole(Privilege pvrl)
    {
        _context.Privileges.Add(pvrl);
        await _context.SaveChangesAsync();

        return Ok(await _context.Privileges.ToListAsync());
    }

    [HttpPut] // update perticular  privilege data for a given row id
    public async Task<ActionResult<List<Privilege>>> UpdatePvrl(Privilege updatedPvrl)
    {

        if (updatedPvrl == null)
            return BadRequest("Invalid privilege data.");

        var dbPvrl = await _context.Privileges.FindAsync(updatedPvrl.Id);
        if (dbPvrl == null)
            return NotFound("Privilege not found.");

        dbPvrl.PrivilegeId = updatedPvrl.PrivilegeId;
        dbPvrl.PrivilegeName = updatedPvrl.PrivilegeName;

        await _context.SaveChangesAsync();

        return Ok(await _context.Privileges.ToListAsync());
    }

    [HttpDelete]  //Delete a privilege for a given row id
    public async Task<ActionResult<List<Privilege>>> DeletPvrl(int id)
    {
        var dbPvrl = await _context.Privileges.FindAsync(id);
        if (dbPvrl is null)
            return NotFound("Privilege not found.");

        _context.Privileges.Remove(dbPvrl);
        await _context.SaveChangesAsync();

        return Ok(await _context.Privileges.ToListAsync());
    }

}
}


