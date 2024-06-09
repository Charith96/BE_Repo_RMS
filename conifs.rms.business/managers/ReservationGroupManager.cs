using conifs.rms.data.entities;
using conifs.rms.data.repositories.ReservationGroups;
using conifs.rms.business.validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using conifs.rms.dto.ReservationGroup;
using AutoMapper;
using System.Text.RegularExpressions;

namespace conifs.rms.business.managers
{
    public class ReservationGroupManager : IReservationGroupManager
    {
        private readonly IReservationGroupRepository _reservationGroupRepository;
        private readonly IMapper _mapper;

        public ReservationGroupManager(IReservationGroupRepository reservationGroupRepository, IMapper mapper)
        {
            _reservationGroupRepository = reservationGroupRepository;
            _mapper = mapper;

        }

        public Task<List<ReservationGroupDto>> GetReservationGroup()
        {
            try
            {
                return _reservationGroupRepository.GetReservationGroup();
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception("Error getting reservation groups", ex);
            }
        }

        public Task<ReservationGroupDto> GetReservationGroupById(Guid id)
        {
            try
            {
                return _reservationGroupRepository.GetReservationGroupById(id);
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception("Error getting reservation group by id", ex);
            }
        }

        public async Task AddReservationGroup(ReservationGroupDto group)
        {

            var validator = new ReservationGroupValidator();
            var validationResult = await validator.ValidateAsync(group);

            if (!validationResult.IsValid)
            {
                // Handle validation errors
                throw new ValidationException(validationResult.Errors);
            }

            try
            {
                await _reservationGroupRepository.AddReservationGroup(group);
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception("Error adding reservation group", ex);
            }
        }

        public async Task UpdateReservationGroup(ReservationGroupDto group)
        {
            
            var validator = new ReservationGroupValidator();
            var validationResult = await validator.ValidateAsync(group);

            if (!validationResult.IsValid)
            {
                // Handle validation errors
                throw new ValidationException(validationResult.Errors);
            }

            try
            {
                
                await _reservationGroupRepository.UpdateReservationGroup(group);
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception("Error updating reservation group", ex);
            }
        }

        public async Task DeleteReservationGroup(Guid id)
        {
            try
            {
                await _reservationGroupRepository.DeleteReservationGroup(id);
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception("Error deleting reservation group", ex);
            }
        }
    }
}
