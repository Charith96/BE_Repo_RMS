using conifs.rms.data.entities;

namespace conifs.rms.business.managers
{
    public interface IReservationGroupManager
    {
        public void GetReservationGroup();
        public void GetReservationGroupById(Guid id);

        public void AddReservationGroup(ReservationGroup group);
        public void UpdateReservationGroup(ReservationGroup UpdatedGroup);
        public void DeleteReservationGroup(Guid id);
    }
}
