using conifs.rms.business.managers;
using conifs.rms.data.entities;
using Microsoft.AspNetCore.Mvc;
using System;

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
        public IActionResult GetAllGroups()
        {
            try
            {
                _reservationGroupManager.GetReservationGroup();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetGroup(Guid id)
        {
            try
            {
                _reservationGroupManager.GetReservationGroupById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult AddGroup(ReservationGroup group)
        {
            try
            {
                _reservationGroupManager.AddReservationGroup(group);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut]
        public IActionResult UpdateGroup(ReservationGroup updatedGroup)
        {
            try
            {
                _reservationGroupManager.UpdateReservationGroup(updatedGroup);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete]
        public IActionResult DeleteGroup(Guid id)
        {
            try
            {
                _reservationGroupManager.DeleteReservationGroup(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
