using conifs.rms.data.entities;
using conifs.rms.dto.Reservation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace conifs.rms.business
{
    public interface IReservationManager
    {
         Task<List<Reservation>> GetAllReservationsAsync();

         Task<Reservation> getreservationasync(Guid id);

         Task<List<Reservation>> AddReservationAsync(GetReservation reservation);
          Task<List<Reservation>> UpdateReservationAsync(Guid id, GetReservation updatedReservation);


        Task<List<Reservation>> DeleteReservationAsync(Guid id);
        
    }
}