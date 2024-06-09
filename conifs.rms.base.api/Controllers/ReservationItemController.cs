using conifs.rms.business.managers;
using conifs.rms.data.entities;
using Microsoft.AspNetCore.Mvc;
using conifs.rms.dto.ReservationItem;
using System;
using System.Threading.Tasks;
using FluentValidation;

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
        public async Task<IActionResult> GetAllItems()
        {
            try
            {
                var result = await _reservationItemManager.GetReservationItem();
                return Ok(result);
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

        [HttpPost]
        public async Task<IActionResult> AddItem(ReservationItemDto item)
        {
            try
            {
                await _reservationItemManager.AddReservationItem(item);
                return Ok();
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
