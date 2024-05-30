using conifs.rms.business;
using conifs.rms.dto.Role;
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

        [HttpGet("{roleCode}")]
        public async Task<IActionResult> GetRoleById(Guid roleCode)
        {
            try
            {
                var role = await _roleManager.GetRoleByIdAsync(roleCode);
                if (role == null)
                {
                    return NotFound();
                }

                return Ok(role);
            }
            catch (FormatException)
            {
                return BadRequest("Invalid role code format.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddRole([FromBody] RoleDto newRoleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var addedRole = await _roleManager.AddRoleAsync(newRoleDto);
                return CreatedAtAction(nameof(GetRoleById), new { roleCode = addedRole.RoleCode }, addedRole);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{roleCode}")]
        public async Task<IActionResult> UpdateRole(Guid roleCode, [FromBody] RoleDto roleDto)
        {
            if (roleCode != roleDto.RoleCode)
            {
                return BadRequest("Role code mismatch");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var updatedRole = await _roleManager.UpdateRoleAsync(roleDto);
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

        [HttpDelete("{roleCode}")]
        public async Task<IActionResult> DeleteRole(Guid roleCode)
        {
            try
            {
                var result = await _roleManager.DeleteRoleAsync(roleCode);
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
