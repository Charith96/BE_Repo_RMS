using conifs.rms.data.entities;
using conifs.rms.data.repositories.ReservationItems;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace conifs.rms.business.managers
{
    public class ReservationItemManager : IReservationItemManager
    {
        private readonly IReservationItemRepository _reservationItemRepository;

        public ReservationItemManager(IReservationItemRepository reservationItemRepository)
        {
            _reservationItemRepository = reservationItemRepository;
        }

        public Task<List<ReservationItem>> GetReservationItem()
        {
            try
            {
                return _reservationItemRepository.GetReservationItem();
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception("Error getting reservation items", ex);
            }
        }

        public Task<ReservationItem> GetReservationItemById(Guid id)
        {
            try
            {
                return _reservationItemRepository.GetReservationItemById(id);
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception("Error getting reservation item by id", ex);
            }
        }

        public async Task AddReservationItem(ReservationItem item)
        {
            try
            {
                await _reservationItemRepository.AddReservationItem(item);
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception("Error adding reservation item", ex);
            }
        }

        public async Task UpdateReservationItem(ReservationItem updatedItem)
        {
            try
            {
                await _reservationItemRepository.UpdateReservationItem(updatedItem);
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception("Error updating reservation item", ex);
            }
        }

        public async Task DeleteReservationItem(Guid id)
        {
            try
            {
                await _reservationItemRepository.DeleteReservationItem(id);
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception("Error deleting reservation item", ex);
            }
        }
    }
}
