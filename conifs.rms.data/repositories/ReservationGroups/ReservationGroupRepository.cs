using conifs.rms.data.entities;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using conifs.rms.dto.ReservationGroup;
using System.Text.RegularExpressions;

namespace conifs.rms.data.repositories.ReservationGroups
{
    public class ReservationGroupRepository : IReservationGroupRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper; 

        public ReservationGroupRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ReservationGroupDto>> GetReservationGroup()
        {
            try
            {
                var groups=await _context.ReservationGroups.ToListAsync();
                return _mapper.Map<List<ReservationGroupDto>>(groups);
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception($"Error getting reservation groups: {ex.Message}", ex);
            }
        }

        public async Task<ReservationGroupDto> GetReservationGroupById(Guid id)
        {
            try
            {
                var groups = await _context.ReservationGroups.FindAsync(id);
                return _mapper.Map<ReservationGroupDto>(groups);
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception($"Error getting reservation group by id: {ex.Message}", ex);
            }
        }

        public async Task AddReservationGroup(ReservationGroupDto group)
        {
            try
            {
                var reservationGroup = _mapper.Map<ReservationGroup>(group);
                _context.ReservationGroups.Add(reservationGroup);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception($"Error adding reservation group: {ex.Message}", ex);
            }
        }

        public async Task UpdateReservationGroup(ReservationGroupDto UpdatedGroup)
        {
            try
            {
                var group = await _context.ReservationGroups.FindAsync(UpdatedGroup.Id);
                if (group == null)
                {
                    throw new KeyNotFoundException("Group not found");
                }
                group.GroupName = UpdatedGroup.GroupName;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception($"Error updating reservation group: {ex.Message}", ex);
            }
        }

        public async Task DeleteReservationGroup(Guid id)
        {
            try
            {
                var group = await _context.ReservationGroups.FindAsync(id);
                if (group == null)
                {
                    throw new KeyNotFoundException("Group not found");
                }
                _context.ReservationGroups.Remove(group);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception($"Error deleting reservation group: {ex.Message}", ex);
            }
        }
    }
}
