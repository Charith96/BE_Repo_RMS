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

        [HttpGet("{roleId}")]
        public async Task<IActionResult> GetRoleById(string roleId)
        {
            try
            {
                var role = await _roleManager.GetRoleByIdAsync(roleId);
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
                return CreatedAtAction(nameof(GetRoleById), new { roleId = addedRole.RoleID }, addedRole);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{roleId}")]
        public async Task<IActionResult> UpdateRole(string roleId, [FromBody] Role role)
        {
            if (roleId != role.RoleID)
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

        [HttpDelete("{roleId}")]
        public async Task<IActionResult> DeleteRole(string roleId)
        {
            try
            {
                var result = await _roleManager.DeleteRoleAsync(roleId);
                if (!result)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
