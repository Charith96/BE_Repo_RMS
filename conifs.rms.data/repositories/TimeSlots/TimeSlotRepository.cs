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

        public async Task<List<TimeSlotDto>> GetTimeSlot()
        {
            try
            {
                var timeSlots = await _context.TimeSlots.ToListAsync();
                return _mapper.Map<List<TimeSlotDto>>(timeSlots);
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception($"Error getting time slots: {ex.Message}", ex);
            }
        }

        public async Task<TimeSlotDto> GetTimeSlotById(Guid id)
        {
            try
            {
                var timeSlots = await _context.TimeSlots.FindAsync(id);
                return _mapper.Map<TimeSlotDto>(timeSlots);
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception($"Error getting time slot by id: {ex.Message}", ex);
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
