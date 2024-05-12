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
        public void GetReservationItem();
        public void GetReservationItemById(Guid id);

        public void AddReservationItem(ReservationItem item);
        public void UpdateReservationItem(ReservationItem updatedItem);
        public void DeleteReservationItem(Guid id);
    }
}
