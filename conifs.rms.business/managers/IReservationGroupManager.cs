using conifs.rms.data.entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace conifs.rms.business.managers
{
    public interface IReservationGroupManager
    {
        public Task<List<ReservationGroup>> GetReservationGroup();
        public Task<ReservationGroup> GetReservationGroupById(Guid id);
        public Task AddReservationGroup(ReservationGroup group);
        public Task UpdateReservationGroup(ReservationGroup updatedGroup);
        public Task DeleteReservationGroup(Guid id);
    }
}
