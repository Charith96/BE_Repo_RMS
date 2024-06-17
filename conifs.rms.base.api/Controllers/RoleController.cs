using conifs.rms.business;
using conifs.rms.data.entities;
using conifs.rms.dto.Role;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
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
                var roleDtos = roles.Select(role => new RoleDto
                {
                    RoleID = role.RoleID,
                    RoleName = role.RoleName
                });

                return Ok(roleDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{RoleCode}")]
        public async Task<IActionResult> GetRoleById(Guid RoleCode)
        {
            try
            {
                var role = await _roleManager.GetRoleByIdAsync(RoleCode);
                if (role == null)
                {
                    return NotFound();
                }

                var roleDto = new RoleDto
                {
                    RoleID = role.RoleID,
                    RoleName = role.RoleName
                };

                return Ok(roleDto);
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
        public async Task<IActionResult> AddRole([FromBody] RoleDto newRoleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var newRole = new Role
                {
                    RoleCode = Guid.NewGuid(),
                    RoleID = newRoleDto.RoleID,
                    RoleName = newRoleDto.RoleName
                };

                var addedRole = await _roleManager.AddRoleAsync(newRole);

                var addedRoleDto = new RoleDto
                {
                    RoleID = addedRole.RoleID,
                    RoleName = addedRole.RoleName
                };

                return CreatedAtAction(nameof(GetRoleById), new { RoleCode = addedRole.RoleCode }, addedRoleDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{RoleCode}")]
        public async Task<IActionResult> UpdateRole(Guid RoleCode, [FromBody] RoleDto roleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var existingRole = await _roleManager.GetRoleByIdAsync(RoleCode);
                if (existingRole == null)
                {
                    return NotFound();
                }

                existingRole.RoleID = roleDto.RoleID;
                existingRole.RoleName = roleDto.RoleName;

                var updatedRole = await _roleManager.UpdateRoleAsync(existingRole);

                var updatedRoleDto = new RoleDto
                {
                    RoleID = updatedRole.RoleID,
                    RoleName = updatedRole.RoleName
                };

                return Ok(updatedRoleDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{RoleCode}")]
        public async Task<IActionResult> DeleteRole(Guid RoleCode)
        {
            try
            {
                await _roleManager.DeleteRoleAsync(RoleCode);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}