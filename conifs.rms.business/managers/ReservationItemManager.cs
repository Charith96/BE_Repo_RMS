using conifs.rms.data.entities;
using conifs.rms.data.repositories.ReservationItems;
using System;

namespace conifs.rms.business.managers
{
    public class ReservationItemManager : IReservationItemManager
    {
        private readonly IReservationItemRepository _reservationItemRepository;

        public ReservationItemManager(IReservationItemRepository reservationItemRepository)
        {
            _reservationItemRepository = reservationItemRepository;
        }

        public void AddReservationItem(ReservationItem item)
        {
            try
            {
                _reservationItemRepository.AddReservationItem(item);
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception("Error adding reservation item", ex);
            }
        }

        public void DeleteReservationItem(Guid id)
        {
            try
            {
                _reservationItemRepository.DeleteReservationItem(id);
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception("Error deleting reservation item", ex);
            }
        }

        public void GetReservationItem()
        {
            try
            {
                _reservationItemRepository.GetReservationItem();
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception("Error getting reservation items", ex);
            }
        }

        public void GetReservationItemById(Guid id)
        {
            try
            {
                _reservationItemRepository.GetReservationItemById(id);
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception("Error getting reservation item by id", ex);
            }
        }

        public void UpdateReservationItem(ReservationItem updatedItem)
        {
            try
            {
                _reservationItemRepository.UpdateReservationItem(updatedItem);
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception("Error updating reservation item", ex);
            }
        }
    }
}

