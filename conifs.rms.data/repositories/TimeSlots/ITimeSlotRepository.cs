using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using conifs.rms.dto.TimeSlot;
using conifs.rms.data.entities;

namespace conifs.rms.data.repositories.TimeSlots
{
    public interface ITimeSlotRepository
    {
        public Task<List<TimeSlotDto>> GetTimeSlot();
        public Task<TimeSlotDto> GetTimeSlotById(Guid id);
        public Task AddTimeSlot(TimeSlotDto timeSlot);
        public Task UpdateTimeSlot(TimeSlotDto updatedTimeSlot);
        public Task DeleteTimeSlot(Guid id);
    }
}
