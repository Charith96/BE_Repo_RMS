using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using conifs.rms.data.entities;
using conifs.rms.data;
using Microsoft.EntityFrameworkCore;

namespace conifs.rms.@base.api.Controllers
{
    [Route("api/[controller]")]
[ApiController]
public class ReservationItemController : ControllerBase
{
        private readonly ApplicationDbContext _context;

        public ReservationItemController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<ReservationItem>>> GetAllItems()
        {
            var items = await _context.ReservationItems.ToListAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<ReservationItem>>> GetItem(Guid id)
        {
            var item = await _context.ReservationItems.FindAsync(id);
            if (item == null)
            {
                return NotFound("item not found");
            }
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<List<ReservationItem>>> AddItem(ReservationItem itm)
        {
            _context.ReservationItems.Add(itm);
            await _context.SaveChangesAsync();

            return Ok(await _context.ReservationItems.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<ReservationItem>>> UpdateItem(ReservationItem UpdatedItem)
        {
            var item = await _context.ReservationItems.FindAsync(UpdatedItem.id);
            if (item == null)
            {
                return NotFound("item not found");
            }
            item.itemName = UpdatedItem.itemName;
            item.timeSlotType = UpdatedItem.timeSlotType;
            item.slotDurationType = UpdatedItem.slotDurationType;
            item.durationPerSlot = UpdatedItem.durationPerSlot;
            item.noOfSlots = UpdatedItem.noOfSlots;
            item.noOfReservations = UpdatedItem.noOfReservations;
            item.capacity = UpdatedItem.capacity;


            await _context.SaveChangesAsync();

            return Ok(await _context.ReservationItems.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<ReservationItem>>> DeleteItem(Guid id)
        {
            var item = await _context.ReservationItems.FindAsync(id);
            if (item == null)
            {
                return NotFound("item not found");
            }

            _context.ReservationItems.Remove(item);
            await _context.SaveChangesAsync();

            return Ok(await _context.ReservationItems.ToListAsync());
        }
    }
}
