using AutoMapper;
using conifs.rms.business.managers;
using conifs.rms.data;
using conifs.rms.data.entities;
using conifs.rms.data.Migrations;
using conifs.rms.data.repositories;
using conifs.rms.dto.Customer;
using conifs.rms.dto.Reservation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace conifs.rms.business
{
    public class ReservationManager : IReservationManager
    {
        private readonly IReservationRepository _reservationRepository;
         private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        private readonly ICustomerManager _customerManager;
        private readonly IReservationGroupManager _reservationGroupManager;
        private readonly IReservationItemManager _reservationItemManager;
        public ReservationManager(ICustomerManager customerManager,IReservationGroupManager reservationGroupManager,IReservationItemManager reservationItemManager,IReservationRepository reservationRepository, IMapper mapper, ApplicationDbContext context)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
            _context=context;
            _reservationItemManager = reservationItemManager;
            _customerManager = customerManager;
            _reservationGroupManager = reservationGroupManager;

        }

        public async Task<List<data.entities.Reservation>> GetAllReservationsAsync()
        {
            return await _reservationRepository.GetAllReservationsAsync();
        }

        public async Task<data.entities.Reservation> getreservationasync(Guid id)
        {
            var reservation = await _reservationRepository.GetReservationAsync(id);
            var Customer = _customerManager.GetCustomerByIdAsync( reservation.CustomerID).Result;
            var Group = _reservationGroupManager.GetReservationGroupById(reservation.GroupId).Result;
            var Item =_reservationItemManager.GetReservationItemById(reservation.ItemId).Result;
            var customer = _mapper.Map<Customer>(Customer);
            var gruop = _mapper.Map<ReservationGroup>(Group);
            var item=_mapper.Map<ReservationItem>(Item);
            reservation.Customer= customer;
            reservation.ReservationGroup = gruop;
            reservation.ReservationItem = item;


            return reservation;
        }

        public async Task<List<data.entities.Reservation>> AddReservationAsync(GetReservation reservationDTO)
        {
            var reservation = _mapper.Map<data.entities.Reservation>(reservationDTO);
            var CustomerID = await _context.Customers
                .Where(uc => uc.CustomerID.ToString() == reservationDTO.CustomerID)
                .Select(uc => uc.CustomerCode)
                .FirstOrDefaultAsync();

            var GroupID = await _context.ReservationGroups
                .Where(uc => uc.Id.ToString() == reservationDTO.GroupId)
                .Select(uc => uc.Id)
                .FirstOrDefaultAsync();

            var ItemID = await _context.ReservationItems
                .Where(uc => uc.Id.ToString() == reservationDTO.ItemId)
                .Select(uc => uc.Id)
                .FirstOrDefaultAsync();

            reservation.CustomerID = CustomerID;
            reservation.GroupId = GroupID;
            reservation.ItemId = ItemID;
         
            
            await _reservationRepository.AddReservationAsync(reservation);
            return await _reservationRepository.GetAllReservationsAsync();
        }

        public async Task<List<data.entities.Reservation>> UpdateReservationAsync(Guid id, GetReservation updatedReservation)
        {
            var reservation = _mapper.Map<data.entities.Reservation>(updatedReservation);
            await _reservationRepository.UpdateReservationAsync(id, reservation);
            return await _reservationRepository.GetAllReservationsAsync();
        }

        public async Task<List<data.entities.Reservation>> DeleteReservationAsync(Guid id)
        {
            await _reservationRepository.DeleteReservationAsync(id);
            return await _reservationRepository.GetAllReservationsAsync();
        }

    }
}