using conifs.rms.data.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace conifs.rms.business.managers
{
    public interface IReservationItemManager
    {
        public Task<List<ReservationItem>> GetReservationItem();
        public Task<ReservationItem> GetReservationItemById(Guid id);
        public Task AddReservationItem(ReservationItem item);
        public Task UpdateReservationItem(ReservationItem updatedItem);
        public Task DeleteReservationItem(Guid id);
    }
}

