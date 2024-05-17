using conifs.rms.data.entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace conifs.rms.data.repositories.ReservationItems
{
    public class ReservationItemRepository : IReservationItemRepository
    {
        private readonly ApplicationDbContext _context;

        public ReservationItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ReservationItem>> GetReservationItem()
        {
            try
            {
                return await _context.ReservationItems.ToListAsync();
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception($"Error getting reservation items: {ex.Message}", ex);
            }
        }

        public async Task<ReservationItem> GetReservationItemById(Guid id)
        {
            try
            {
                return await _context.ReservationItems.FindAsync(id);
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception($"Error getting reservation item by id: {ex.Message}", ex);
            }
        }

        public async Task AddReservationItem(ReservationItem item)
        {
            try
            {
                _context.ReservationItems.Add(item);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception($"Error adding reservation item: {ex.Message}", ex);
            }
        }

        public async Task UpdateReservationItem(ReservationItem updatedItem)
        {
            try
            {
                var item = await _context.ReservationItems.FindAsync(updatedItem.Id);
                if (item == null)
                {
                    throw new KeyNotFoundException("Item not found");
                }
                item.ItemName = updatedItem.ItemName;
                item.TimeSlotType = updatedItem.TimeSlotType;
                item.SlotDurationType = updatedItem.SlotDurationType;
                item.DurationPerSlot = updatedItem.DurationPerSlot;
                item.NoOfSlots = updatedItem.NoOfSlots;
                item.NoOfReservations = updatedItem.NoOfReservations;
                item.Capacity = updatedItem.Capacity;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception($"Error updating reservation item: {ex.Message}", ex);
            }
        }

        public async Task DeleteReservationItem(Guid id)
        {
            try
            {
                var item = await _context.ReservationItems.FindAsync(id);
                if (item == null)
                {
                    throw new KeyNotFoundException("Item not found");
                }
                _context.ReservationItems.Remove(item);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception($"Error deleting reservation item: {ex.Message}", ex);
            }
        }
    }
}
