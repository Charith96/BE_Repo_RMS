using conifs.rms.data.entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conifs.rms.data.repositories.ReservationItems
{
    public interface IReservationItemRepository
    {
        public Task<ActionResult<List<ReservationItem>>> GetReservationItem();
        public Task<ActionResult<List<ReservationItem>>> GetReservationItemById(Guid id);

        public Task<ActionResult<List<ReservationItem>>> AddReservationItem(ReservationItem item);
        public Task<ActionResult<List<ReservationItem>>> UpdateReservationItem(ReservationItem updatedItem);
        public Task<ActionResult<List<ReservationItem>>> DeleteReservationItem(Guid id);
    }
}
