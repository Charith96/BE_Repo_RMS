using conifs.rms.data.entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace conifs.rms.data.repositories.ReservationGroups
{
    public class ReservationGroupRepository : IReservationGroupRepository
    {
        private readonly ApplicationDbContext _context;

        public ReservationGroupRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ReservationGroup>> GetReservationGroup()
        {
            try
            {
                return await _context.ReservationGroups.ToListAsync();
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception($"Error getting reservation groups: {ex.Message}", ex);
            }
        }

        public async Task<ReservationGroup> GetReservationGroupById(Guid id)
        {
            try
            {
                return await _context.ReservationGroups.FindAsync(id);
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception($"Error getting reservation group by id: {ex.Message}", ex);
            }
        }

        public async Task AddReservationGroup(ReservationGroup group)
        {
            try
            {
                _context.ReservationGroups.Add(group);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception($"Error adding reservation group: {ex.Message}", ex);
            }
        }

        public async Task UpdateReservationGroup(ReservationGroup UpdatedGroup)
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
