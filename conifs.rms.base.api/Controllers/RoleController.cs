using conifs.rms.business;
using conifs.rms.data.entities;
using conifs.rms.dto;
using conifs.rms.dto.Role;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

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
               // var roleDtos = roles.Select(role => new RoleDto
              

                return Ok(roles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{RoleCode:guid}")]
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

                return Ok(addedRole);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{RoleCode:guid}")]
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

        [HttpDelete("{RoleCode:guid}")]
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

        // RolePrivilege methods

        [HttpPost("AddRolePrivilege")]
        public async Task<IActionResult> AddRolePrivilege([FromBody] RolePrivilegeDto rolePrivilegeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _roleManager.AddRolePrivilege(rolePrivilegeDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetRolePrivileges")]
        public async Task<IActionResult> GetAllRolePrivileges()
        {
            try
            {
                var result = await _roleManager.GetAllRolePrivilege();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetRolePrivilegeById")]
        public async Task<IActionResult> GetRolePrivilegeById([FromQuery] Guid roleCode)
        {
            try
            {
                var result = await _roleManager.GetRolePrivilege(roleCode);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("UpdateRolePrivilege")]
        public async Task<IActionResult> UpdateRolePrivilege([FromBody] RolePrivilegeDto updatedRolePrivilege)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _roleManager.UpdateRolePrivilege(updatedRolePrivilege);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("DeleteRolePrivilege/{id:guid}")]
        public async Task<IActionResult> DeleteRolePrivilege(Guid id)
        {
            try
            {
                await _roleManager.DeleteRolePrivilege(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}