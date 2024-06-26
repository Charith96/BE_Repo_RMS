using AutoMapper;
using conifs.rms.data.entities;
using conifs.rms.data.Migrations;
using conifs.rms.dto.Reservation;
using conifs.rms.dto.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace conifs.rms.data.repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ReservationRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<entities.Reservation>> GetAllReservationsAsync()
        {
            return await _context.Reservations.ToListAsync();
        }
  
   
        public async Task<entities.Reservation> GetReservationAsync(Guid id)
        {
            var  reservation =  await _context.Reservations.FindAsync(id);
            return reservation;         
        }


        public async Task AddReservationAsync(entities.Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateReservationAsync(Guid id, entities.Reservation updatedReservation)
        {
            var dbReservation = await _context.Reservations.FindAsync(id);
            if (dbReservation == null)
                throw new Exception("Reservation not found.");


            dbReservation.date = updatedReservation.date;
            dbReservation.NoOfPeople = updatedReservation.NoOfPeople;
            dbReservation.Time1 = updatedReservation.Time1;
            dbReservation.Time2 = updatedReservation.Time2;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteReservationAsync(Guid id)
        {
        
            var dbReservation = _context.Reservations.FirstOrDefault(u => u.ReservationCode == id);
            if (dbReservation == null)
                throw new Exception("Reservation not found.");

            _context.Reservations.Remove(dbReservation);
            await _context.SaveChangesAsync();
        }
    }
}