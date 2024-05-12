using conifs.rms.data.entities;
using conifs.rms.data.repositories.ReservationGroups;
using System;

namespace conifs.rms.business.managers
{
    public class ReservationGroupManager : IReservationGroupManager
    {
        private readonly IReservationGroupRepository _reservationGroupRepository;

        public ReservationGroupManager(IReservationGroupRepository reservationGroupRepository)
        {
            _reservationGroupRepository = reservationGroupRepository;
        }

        public void AddReservationGroup(ReservationGroup group)
        {
            try
            {
                _reservationGroupRepository.AddReservationGroup(group);
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception("Error adding reservation group", ex);
            }
        }

        public void DeleteReservationGroup(Guid id)
        {
            try
            {
                _reservationGroupRepository.DeleteReservationGroup(id);
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception("Error deleting reservation group", ex);
            }
        }

        public void GetReservationGroup()
        {
            try
            {
                _reservationGroupRepository.GetReservationGroup();
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception("Error getting reservation groups", ex);
            }
        }

        public void GetReservationGroupById(Guid id)
        {
            try
            {
                _reservationGroupRepository.GetReservationGroupById(id);
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception("Error getting reservation group by id", ex);
            }
        }

        public void UpdateReservationGroup(ReservationGroup UpdatedGroup)
        {
            try
            {
                _reservationGroupRepository.UpdateReservationGroup(UpdatedGroup);
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception("Error updating reservation group", ex);
            }
        }
    }
}
