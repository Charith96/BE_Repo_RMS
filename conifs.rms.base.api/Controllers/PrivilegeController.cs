using conifs.rms.business;
using conifs.rms.data.entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace conifs.rms.@base.api.Controllers
{
    [Route("api/[controller]")]
[ApiController]
public class PrivilegeController : ControllerBase
{
    private readonly IPrivilegeManager _privilegeManager;

    public PrivilegeController(IPrivilegeManager privilegeManager)
    {
        _privilegeManager = privilegeManager;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPrivileges()
    {
        try
        {
            var privileges = await _privilegeManager.GetAllPrivilegesAsync();
            return Ok(privileges);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet("{privilegeId}")]
    public async Task<IActionResult> GetPrivilegeById(string privilegeId)
    {
        try
        {
            var privilege = await _privilegeManager.GetPrivilegeByIdAsync(privilegeId);
            if (privilege == null)
            {
                return NotFound();
            }

            return Ok(privilege);
        }
        catch (FormatException)
        {
            return BadRequest("Invalid privilege ID format.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddPrivilege([FromBody] Privilege newPrivilege)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var addedPrivilege = await _privilegeManager.AddPrivilegeAsync(newPrivilege);
            return CreatedAtAction(nameof(GetPrivilegeById), new { privilegeId = addedPrivilege.PrivilegeId }, addedPrivilege);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPut("{privilegeId}")]
    public async Task<IActionResult> UpdatePrivilege(string privilegeId, [FromBody] Privilege privilege)
    {
        if (privilegeId != privilege.PrivilegeId)
        {
            return BadRequest("Privilege ID mismatch");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var updatedPrivilege = await _privilegeManager.UpdatePrivilegeAsync(privilege);
            if (updatedPrivilege == null)
            {
                return NotFound();
            }

            return Ok(updatedPrivilege);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpDelete("{privilegeId}")]
    public async Task<IActionResult> DeletePrivilege(string privilegeId)
    {
        try
        {
            await _privilegeManager.DeletePrivilegeAsync(privilegeId);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
}
