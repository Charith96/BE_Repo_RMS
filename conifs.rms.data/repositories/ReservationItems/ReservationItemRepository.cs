using conifs.rms.data.entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conifs.rms.data.repositories.ReservationItems
{
    public class ReservationItemRepository : ControllerBase,IReservationItemRepository
    {
        private readonly ApplicationDbContext _context;

        public ReservationItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<List<ReservationItem>>> GetReservationItem()
        {
            try
            {
                var items = await _context.ReservationItems.ToListAsync();
                return Ok(items);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        public async Task<ActionResult<List<ReservationItem>>> GetReservationItemById(Guid id)
        {
            try
            {
                var item = await _context.ReservationItems.FindAsync(id);
                if (item == null)
                {
                    return NotFound("Item not found");
                }
                return Ok(item);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        public async Task<ActionResult<List<ReservationItem>>> AddReservationItem(ReservationItem item)
        {
            try
            {
                _context.ReservationItems.Add(item);
                await _context.SaveChangesAsync();
                return Ok(await _context.ReservationItems.ToListAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        public async Task<ActionResult<List<ReservationItem>>> UpdateReservationItem(ReservationItem updatedItem)
        {
            try
            {
                var item = await _context.ReservationItems.FindAsync(updatedItem.id);
                if (item == null)
                {
                    return NotFound("Item not found");
                }
                item.itemName = updatedItem.itemName;
                item.timeSlotType = updatedItem.timeSlotType;
                item.slotDurationType = updatedItem.slotDurationType;
                item.durationPerSlot = updatedItem.durationPerSlot;
                item.noOfSlots = updatedItem.noOfSlots;
                item.noOfReservations = updatedItem.noOfReservations;
                item.capacity = updatedItem.capacity;
                await _context.SaveChangesAsync();
                return Ok(await _context.ReservationItems.ToListAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        public async Task<ActionResult<List<ReservationItem>>> DeleteReservationItem(Guid id)
        {
            try
            {
                var item = await _context.ReservationItems.FindAsync(id);
                if (item == null)
                {
                    return NotFound("Item not found");
                }
                _context.ReservationItems.Remove(item);
                await _context.SaveChangesAsync();
                return Ok(await _context.ReservationItems.ToListAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
