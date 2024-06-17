﻿using conifs.rms.business;
using conifs.rms.data.entities;
using conifs.rms.dto.Privilege;
using conifs.rms.business.mappers;
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
                var privilegeDtos = privileges.Select(PrivilegeMappers.ToDto);
                return Ok(privilegeDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{privilegeId}")]
        public async Task<IActionResult> GetPrivilegeById(Guid privilegeId)
        {
            try
            {
                var privilege = await _privilegeManager.GetPrivilegeByIdAsync(privilegeId);
                if (privilege == null)
                {
                    return NotFound();
                }

                return Ok(PrivilegeMappers.ToDto(privilege));
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
        public async Task<IActionResult> AddPrivilege([FromBody] PrivilegeDto newPrivilegeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var newPrivilege = PrivilegeMappers.ToEntity(newPrivilegeDto);
                var addedPrivilege = await _privilegeManager.AddPrivilegeAsync(newPrivilege);
                return CreatedAtAction(nameof(GetPrivilegeById), new { privilegeId = addedPrivilege.PrivilegeCode }, PrivilegeMappers.ToDto(addedPrivilege));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{privilegeId}")]
        public async Task<IActionResult> UpdatePrivilege(Guid privilegeId, [FromBody] PrivilegeDto privilegeDto)
        {
            var privilege = PrivilegeMappers.ToEntity(privilegeDto);
            privilege.PrivilegeCode = privilegeId;

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

                return Ok(PrivilegeMappers.ToDto(updatedPrivilege));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{privilegeId}")]
        public async Task<IActionResult> DeletePrivilege(Guid privilegeId)
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