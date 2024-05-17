using conifs.rms.data.entities;
using conifs.rms.data.repositories.ReservationGroups;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace conifs.rms.business.managers
{
    public class ReservationGroupManager : IReservationGroupManager
    {
        private readonly IReservationGroupRepository _reservationGroupRepository;

        public ReservationGroupManager(IReservationGroupRepository reservationGroupRepository)
        {
            _reservationGroupRepository = reservationGroupRepository;
        }

        public Task<List<ReservationGroup>> GetReservationGroup()
        {
            try
            {
                return _reservationGroupRepository.GetReservationGroup();
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception("Error getting reservation groups", ex);
            }
        }

        public Task<ReservationGroup> GetReservationGroupById(Guid id)
        {
            try
            {
                return _reservationGroupRepository.GetReservationGroupById(id);
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception("Error getting reservation group by id", ex);
            }
        }

        public async Task AddReservationGroup(ReservationGroup group)
        {
            try
            {
                await _reservationGroupRepository.AddReservationGroup(group);
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception("Error adding reservation group", ex);
            }
        }

        public async Task UpdateReservationGroup(ReservationGroup updatedGroup)
        {
            try
            {
                await _reservationGroupRepository.UpdateReservationGroup(updatedGroup);
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception("Error updating reservation group", ex);
            }
        }

        public async Task DeleteReservationGroup(Guid id)
        {
            try
            {
                await _reservationGroupRepository.DeleteReservationGroup(id);
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception("Error deleting reservation group", ex);
            }
        }
    }
}
