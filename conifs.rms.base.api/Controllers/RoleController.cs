using conifs.rms.business;
using conifs.rms.data.entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace conifs.rms.@base.api.Controllers
{
    [Route("api/[controller]")]
[ApiController]
public class RoleController : ControllerBase
{
    private readonly IRoleManager _roleManager;

    public RoleController(IRoleManager roleManager)
    {
        _roleManager = roleManager;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllRoles()
    {
        try
        {
            var roles = await _roleManager.GetAllRolesAsync();
            return Ok(roles);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet("{RoleID}")]
    public async Task<IActionResult> GetRoleById(string RoleID)
    {
        try
        {
            var role = await _roleManager.GetRoleByIdAsync(RoleID);
            if (role == null)
            {
                return NotFound();
            }

            return Ok(role);
        }
        catch (FormatException)
        {
            return BadRequest("Invalid role ID format.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddRole([FromBody] Role newRole)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var addedRole = await _roleManager.AddRoleAsync(newRole);
            return CreatedAtAction(nameof(GetRoleById), new { RoleID = addedRole.RoleID }, addedRole);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPut("{RoleID}")]
    public async Task<IActionResult> UpdateRole(string RoleID, [FromBody] Role role)
    {
        if (RoleID != role.RoleID)
        {
            return BadRequest("Role ID mismatch");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var updatedRole = await _roleManager.UpdateRoleAsync(role);
            if (updatedRole == null)
            {
                return NotFound();
            }

            return Ok(updatedRole);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpDelete("{RoleID}")]
    public async Task<IActionResult> DeleteRole(string RoleID)
    {
        try
        {
            await _roleManager.DeleteRoleAsync(RoleID);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
}
