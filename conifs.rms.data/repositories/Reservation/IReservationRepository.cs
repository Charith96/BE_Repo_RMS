using conifs.rms.data.entities;
using conifs.rms.dto.Reservation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace conifs.rms.data.repositories
{
	public interface IReservationRepository
	{
		Task<List<Reservation>> GetAllReservationsAsync();
		Task<Reservation> GetReservationAsync(Guid id);
		Task AddReservationAsync(Reservation reservation);
		Task UpdateReservationAsync(Guid id, Reservation updatedReservation);
		Task DeleteReservationAsync(Guid id);
	}
}