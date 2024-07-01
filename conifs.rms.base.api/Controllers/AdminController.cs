using conifs.rms.business.managers;
using conifs.rms.dto.Admin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace conifs.rms.@base.api.Controllers
{
    [Route("api/[controller]")]
[ApiController]
public class AdminController : ControllerBase
{
        private readonly IAdminManager _adminManager;

        public AdminController(IAdminManager adminManager)
        {
            _adminManager = adminManager;
        }
        [Authorize(Policy = "AdminOnly")]
        [HttpGet]
        public async Task<IActionResult> GetAllAdmins()
        {
            try
            {
                var result = await _adminManager.GetAllAdmins();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdmin(Guid id)
        {
            try
            {
                var result = await _adminManager.GetAdminById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

      //  [Authorize(Policy = "AdminOnly")]
        [HttpPost]
        public async Task<IActionResult> AddAdmin(AdminDto admin)
        {
            try
            {
                await _adminManager.AddAdmin(admin);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
