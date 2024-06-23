using AutoMapper;
using conifs.rms.data.entities;
using conifs.rms.dto.ReservationGroup;
using conifs.rms.dto.TimeSlot;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conifs.rms.data.repositories.TimeSlots
{
    public class TimeSlotRepository : ITimeSlotRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TimeSlotRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<TimeSlotDto>> GetTimeSlotById(Guid itemId)
        {
            try
            {
                // Fetch the time slots from the context using the itemId
                var timeSlots = await _context.TimeSlots
                    .Where(ts => ts.ItemId == itemId)
                    .ToListAsync();

                // Map the time slot entities to TimeSlotDto list
                return _mapper.Map<List<TimeSlotDto>>(timeSlots);
            }
            catch (Exception ex)
            {
                // Log the exception using your preferred logging framework
                // Example: _logger.LogError(ex, "Error getting time slots by itemId");
                throw new Exception($"Error getting time slots by itemId: {ex.Message}", ex);
            }
        }

        public async Task AddTimeSlot(TimeSlotDto timeSlot)
        {
            try
            {
                var slot = _mapper.Map<TimeSlot>(timeSlot);
                _context.TimeSlots.Add(slot);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception($"Error adding time slot: {ex.Message}", ex);
            }
        }

        public async Task UpdateTimeSlot(TimeSlotDto updatedTimeSlot)
        {
            try
            {
                var timeSlot = await _context.TimeSlots.FindAsync(updatedTimeSlot.Id);
                if (timeSlot == null)
                {
                    throw new KeyNotFoundException("Group not found");
                }
                timeSlot.StartTime = updatedTimeSlot.StartTime;
                timeSlot.EndTime = updatedTimeSlot.EndTime;
                _context.Entry(timeSlot).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception($"Error updating reservation group: {ex.Message}", ex);
            }
        }

        public async Task DeleteTimeSlot(Guid id)
        {
            try
            {
                var timeSlot = await _context.TimeSlots.FindAsync(id);
                if (timeSlot == null)
                {
                    throw new KeyNotFoundException("Group not found");
                }
                _context.TimeSlots.Remove(timeSlot);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception($"Error deleting reservation group: {ex.Message}", ex);
            }
        }
    }
}
