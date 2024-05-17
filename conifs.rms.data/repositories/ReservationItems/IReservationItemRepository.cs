using conifs.rms.data.entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace conifs.rms.data.repositories.ReservationItems
{
    public interface IReservationItemRepository
    {
        public Task<List<ReservationItem>> GetReservationItem();
        public Task<ReservationItem> GetReservationItemById(Guid id);
        public Task AddReservationItem(ReservationItem item);
        public Task UpdateReservationItem(ReservationItem updatedItem);
        public Task DeleteReservationItem(Guid id);
    }
}
