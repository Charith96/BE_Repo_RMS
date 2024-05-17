using conifs.rms.business.managers;
using conifs.rms.data.entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace conifs.rms.@base.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationGroupController : ControllerBase
    {
        private readonly IReservationGroupManager _reservationGroupManager;

        public ReservationGroupController(IReservationGroupManager reservationGroupManager)
        {
            _reservationGroupManager = reservationGroupManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGroups()
        {
            try
            {
                var result = await _reservationGroupManager.GetReservationGroup();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGroup(Guid id)
        {
            try
            {
                var result = await _reservationGroupManager.GetReservationGroupById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddGroup(ReservationGroup group)
        {
            try
            {
                await _reservationGroupManager.AddReservationGroup(group);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGroup(ReservationGroup updatedGroup)
        {
            try
            {
                await _reservationGroupManager.UpdateReservationGroup(updatedGroup);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroup(Guid id)
        {
            try
            {
                await _reservationGroupManager.DeleteReservationGroup(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
