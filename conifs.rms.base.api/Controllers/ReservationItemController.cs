using conifs.rms.business.managers;
using conifs.rms.data;
using conifs.rms.data.entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

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
        public IActionResult GetAllItems()
        {
            try
            {
                _reservationItemManager.GetReservationItem();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetItem(Guid id)
        {
            try
            {
                _reservationItemManager.GetReservationItemById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult AddItem(ReservationItem item)
        {
            try
            {
                _reservationItemManager.AddReservationItem(item);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut]
        public IActionResult UpdateItem(ReservationItem updatedItem)
        {
            try
            {
                _reservationItemManager.UpdateReservationItem(updatedItem);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete]
        public IActionResult DeleteItem(Guid id)
        {
            try
            {
                _reservationItemManager.DeleteReservationItem(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
