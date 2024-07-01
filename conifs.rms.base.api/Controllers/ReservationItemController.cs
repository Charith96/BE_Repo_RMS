using conifs.rms.business.managers;
using conifs.rms.data.entities;
using Microsoft.AspNetCore.Mvc;
using conifs.rms.dto.ReservationItem;
using System;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;

namespace conifs.rms.@base.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationItemController : ControllerBase
    {
        private readonly IReservationItemManager _reservationItemManager;

        public ReservationItemController(IReservationItemManager reservationItemManager)
        {
            _reservationItemManager = reservationItemManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllItems(Guid? groupId = null)
        {
            try
            {


                if (groupId.HasValue)
                {
                    return Ok(await _reservationItemManager.GetReservationItemsByGroupId(groupId.Value));
                }
                else
                {
                    return Ok(await _reservationItemManager.GetReservationItem());
                }


            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(Guid id)
        {
            try
            {
                var result = await _reservationItemManager.GetReservationItemById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPost]
        public async Task<IActionResult> AddItem(ReservationItemDto item)
        {
            try
            {
                var reservationItem = await _reservationItemManager.AddReservationItem(item);
                return Ok(reservationItem);
            }
            catch (ValidationException vex)
            {
                return BadRequest(new { errors = vex.Errors.Select(e => e.ErrorMessage) });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPut]
        public async Task<IActionResult> UpdateItem(ReservationItemDto updatedItem)
        {
            try
            {
                await _reservationItemManager.UpdateReservationItem(updatedItem);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(Guid id)
        {
            try
            {
                await _reservationItemManager.DeleteReservationItem(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
