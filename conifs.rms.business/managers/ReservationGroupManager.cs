using conifs.rms.data.entities;
using conifs.rms.data.repositories.ReservationGroups;
using conifs.rms.business.validations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace conifs.rms.business.managers
{
    public class ReservationGroupManager : IReservationGroupManager
    {
        private readonly IReservationGroupRepository _reservationGroupRepository;

        public ReservationGroupManager(IReservationGroupRepository reservationGroupRepository)
        {
            _reservationGroupRepository = reservationGroupRepository;
        }

        public Task<List<ReservationGroup>> GetReservationGroup()
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

        public Task<ReservationGroup> GetReservationGroupById(Guid id)
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

        public async Task AddReservationGroup(ReservationGroup group)
        {
            try
            {
                var validator = new ReservationGroupValidator();
                var validationResult = await validator.ValidateAsync(group);

                if (!validationResult.IsValid)
                {
                    // Handle validation errors
                    throw new ValidationException(validationResult.Errors);
                }

                await _reservationGroupRepository.AddReservationGroup(group);
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception("Error adding reservation group", ex);
            }
        }

        public async Task UpdateReservationGroup(ReservationGroup updatedGroup)
        {
            try
            {
                var validator = new ReservationGroupValidator();
                var validationResult = await validator.ValidateAsync(updatedGroup);

                if (!validationResult.IsValid)
                {
                    // Handle validation errors
                    throw new ValidationException(validationResult.Errors);
                }
                await _reservationGroupRepository.UpdateReservationGroup(updatedGroup);
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
