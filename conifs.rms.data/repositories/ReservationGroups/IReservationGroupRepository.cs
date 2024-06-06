using conifs.rms.data.entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using conifs.rms.dto.ReservationGroup;

namespace conifs.rms.data.repositories.ReservationGroups
{
    public interface IReservationGroupRepository
    {
        public Task<List<ReservationGroupDto>> GetReservationGroup();
        public Task<ReservationGroupDto> GetReservationGroupById(Guid id);
        public Task AddReservationGroup(ReservationGroupDto group);
        public Task UpdateReservationGroup(ReservationGroupDto UpdatedGroup);
        public Task DeleteReservationGroup(Guid id);
    }
}
