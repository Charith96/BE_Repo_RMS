using conifs.rms.data.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using conifs.rms.dto.ReservationItem;


namespace conifs.rms.business.managers
{
    public interface IReservationItemManager
    {
        public Task<List<ReservationItemDto>> GetReservationItem();
        public Task<List<ReservationItemDto>> GetReservationItemsByGroupId(Guid groupId);
        public Task<ReservationItemDto> GetReservationItemById(Guid id);
        public Task<ReservationItem> AddReservationItem(ReservationItemDto item);
        public Task UpdateReservationItem(ReservationItemDto updatedItem);
        public Task DeleteReservationItem(Guid id);
    }
}

