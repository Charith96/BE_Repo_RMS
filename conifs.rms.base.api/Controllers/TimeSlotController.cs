using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using conifs.rms.data.entities;
using conifs.rms.business.managers;
using conifs.rms.dto.TimeSlot;

namespace conifs.rms.@base.api.Controllers
{
    [Route("api/[controller]")]
[ApiController]
public class TimeSlotController : ControllerBase
{
private readonly ITimeSlotManager _timeSlotManager;

    public TimeSlotController(ITimeSlotManager timeSlotManager)
        {
        _timeSlotManager = timeSlotManager;
    }

        [HttpGet]
        public async Task<IActionResult> GetTimeSlot([FromQuery] Guid? itemId)
        {
            try
            {
                if (itemId == null)
                {
                    return BadRequest("Item ID is required.");
                }

                var result = await _timeSlotManager.GetTimeSlotById(itemId.Value);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpPost]
    public async Task<IActionResult> AddTimeSlot(TimeSlotDto timeSlot)
        {
        try
            {
            await _timeSlotManager.AddTimeSlot(timeSlot);
            return Ok();
        }
        catch (Exception ex)
            {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

        [HttpPut]
    public async Task<IActionResult> UpdateTimeSlot(TimeSlotDto timeSlot)
        {
        try
            {
            await _timeSlotManager.UpdateTimeSlot(timeSlot);
            return Ok();
        }
        catch (Exception ex)
            {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

        [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTimeSlot(Guid id)
        {
        try
            {
            await _timeSlotManager.DeleteTimeSlot(id);
            return Ok();
        }
        catch (Exception ex)
            {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }   
        }
}
}
