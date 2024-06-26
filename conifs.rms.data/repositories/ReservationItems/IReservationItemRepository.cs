using conifs.rms.data.entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using conifs.rms.dto.ReservationItem;

namespace conifs.rms.data.repositories.ReservationItems
{
    public interface IReservationItemRepository
    {
        public Task<List<ReservationItemDto>> GetReservationItem();
        public Task<ReservationItemDto> GetReservationItemById(Guid id);
        public Task<List<ReservationItemDto>> GetReservationItemsByGroupId(Guid groupId);
        public Task<ReservationItem> AddReservationItem(ReservationItemDto item);
        public Task UpdateReservationItem(ReservationItemDto updatedItem);
        public Task DeleteReservationItem(Guid id);
    }
}
