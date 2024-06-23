using conifs.rms.data.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using conifs.rms.data.repositories.TimeSlots;
using AutoMapper;
using conifs.rms.data.repositories.ReservationGroups;
using conifs.rms.business.validators;
using Microsoft.EntityFrameworkCore;
using conifs.rms.data;
using conifs.rms.dto.TimeSlot;
using conifs.rms.dto.ReservationGroup;
using FluentValidation;

namespace conifs.rms.business.managers
{
    public class TimeSlotManager : ITimeSlotManager
    {
        private readonly ITimeSlotRepository _timeSlotRepository;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public TimeSlotManager(ITimeSlotRepository timeSlotRepository, IMapper mapper, ApplicationDbContext context)
        {
            _timeSlotRepository = timeSlotRepository;
            _mapper = mapper;
            _context = context;

        }
        public Task<List<TimeSlotDto>> GetTimeSlotById(Guid itemId)
        {
            try
            {
                return _timeSlotRepository.GetTimeSlotById(itemId);
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                // Use your logging mechanism here, e.g., _logger.LogError(ex, "Error getting time slot by id");
                throw new Exception("Error getting time slots by id", ex);
            }
        }
        public async Task AddTimeSlot(TimeSlotDto timeSlot)
        {
            var convertedTimeSlot = _mapper.Map<TimeSlot>(timeSlot);
            var validator = new TimeSlotValidator(_context);
            var validationResult = await validator.ValidateAsync(convertedTimeSlot);

            if (!validationResult.IsValid)
            {
                // Handle validation errors
                throw new ValidationException(validationResult.Errors);
            }

            try
            {
                await _timeSlotRepository.AddTimeSlot(timeSlot);
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception("Error adding time slot", ex);
            }
        }
        public async Task UpdateTimeSlot(TimeSlotDto timeSlot)
        {
            var convertedTimeSlot = _mapper.Map<TimeSlot>(timeSlot);
            var validator = new TimeSlotValidator(_context);
            var validationResult = await validator.ValidateAsync(convertedTimeSlot);

            if (!validationResult.IsValid)
            {
                // Handle validation errors
                throw new ValidationException(validationResult.Errors);
            }

            try
            {

                await _timeSlotRepository.UpdateTimeSlot(timeSlot);
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception("Error updating reservation group", ex);
            }
        }

        public async Task DeleteTimeSlot(Guid id)
        {
            try
            {
                await _timeSlotRepository.DeleteTimeSlot(id);
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception("Error deleting reservation group", ex);
            }
        }

        

        
    }
}
