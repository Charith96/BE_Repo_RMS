using conifs.rms.data.entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using conifs.rms.dto.ReservationGroup;

namespace conifs.rms.business.managers
{
    public interface IReservationGroupManager
    {
        public Task<List<ReservationGroupDto>> GetReservationGroup();
        public Task<ReservationGroupDto> GetReservationGroupById(Guid id);
        public Task AddReservationGroup(ReservationGroupDto group);
        public Task UpdateReservationGroup(ReservationGroupDto updatedGroup);
        public Task DeleteReservationGroup(Guid id);
    }
}
