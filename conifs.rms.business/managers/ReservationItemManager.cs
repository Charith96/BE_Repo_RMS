using conifs.rms.data.entities;
using conifs.rms.data.repositories.ReservationItems;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using conifs.rms.business.validators;
using FluentValidation;
using conifs.rms.dto.ReservationItem;
using conifs.rms.dto.ReservationGroup;
using AutoMapper;

namespace conifs.rms.business.managers
{
    public class ReservationItemManager : IReservationItemManager
    {
        private readonly IReservationItemRepository _reservationItemRepository;
        private readonly IMapper _mapper;

        public ReservationItemManager(IReservationItemRepository reservationItemRepository, IMapper mapper)
        {
            _reservationItemRepository = reservationItemRepository;
            _mapper = mapper;
        }

        public Task<List<ReservationItemDto>> GetReservationItem()
        {
            try
            {
                return _reservationItemRepository.GetReservationItem();
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception("Error getting reservation items", ex);
            }
        }

        public Task<ReservationItemDto> GetReservationItemById(Guid id)
        {
            try
            {
                return _reservationItemRepository.GetReservationItemById(id);
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception("Error getting reservation item by id", ex);
            }
        }

        public async Task AddReservationItem(ReservationItemDto item)
        {
            var validator = new ReservationItemValidator();
            var validationResult = await validator.ValidateAsync(item);

            if (!validationResult.IsValid)
            {
                // Handle validation errors
                throw new ValidationException(validationResult.Errors);
            }

            try
            {
                await _reservationItemRepository.AddReservationItem(item);
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception("Error adding reservation item", ex);
            }
        }


        public async Task UpdateReservationItem(ReservationItemDto item)
        {
            
            var validator = new ReservationItemValidator();
            var validationResult = await validator.ValidateAsync(item);
            

            if (!validationResult.IsValid)
            {
                // Handle validation errors
                throw new ValidationException(validationResult.Errors);
            }

            try
            {
                
                await _reservationItemRepository.UpdateReservationItem(item);
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception("Error updating reservation item", ex);
            }
        }

        public async Task DeleteReservationItem(Guid id)
        {
            try
            {
                await _reservationItemRepository.DeleteReservationItem(id);
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception("Error deleting reservation item", ex);
            }
        }
    }
}
