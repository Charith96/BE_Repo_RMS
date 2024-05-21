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

        [HttpGet("{privilegeCode}")]
        public async Task<IActionResult> GetPrivilegeById(Guid privilegeCode)
        {
            try
            {
                var privilege = await _privilegeManager.GetPrivilegeByIdAsync(privilegeCode);
                if (privilege == null)
                {
                    return NotFound();
                }

                return Ok(privilege);
            }
            catch (FormatException)
            {
                return BadRequest("Invalid privilege code format.");
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
                return CreatedAtAction(nameof(GetPrivilegeById), new { privilegeCode = addedPrivilege.PrivilegeCode }, addedPrivilege);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{privilegeCode}")]
        public async Task<IActionResult> UpdatePrivilege(Guid privilegeCode, [FromBody] Privilege privilege)
        {
            if (privilegeCode != privilege.PrivilegeCode)
            {
                return BadRequest("Privilege code mismatch");
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

        [HttpDelete("{privilegeCode}")]
        public async Task<IActionResult> DeletePrivilege(Guid privilegeCode)
        {
            try
            {
                var result = await _privilegeManager.DeletePrivilegeAsync(privilegeCode);
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
