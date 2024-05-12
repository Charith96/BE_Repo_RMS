using conifs.rms.data.entities;
using Microsoft.AspNetCore.Mvc;

namespace conifs.rms.data.repositories.ReservationGroups
{
    public interface IReservationGroupRepository
    {
        public Task<ActionResult<List<ReservationGroup>>> GetReservationGroup();
        public Task<ActionResult<List<ReservationGroup>>> GetReservationGroupById(Guid id);

        public Task<ActionResult<List<ReservationGroup>>> AddReservationGroup(ReservationGroup group);
        public Task<ActionResult<List<ReservationGroup>>> UpdateReservationGroup(ReservationGroup UpdatedGroup);
        public Task<ActionResult<List<ReservationGroup>>> DeleteReservationGroup(Guid id);
    }
}
