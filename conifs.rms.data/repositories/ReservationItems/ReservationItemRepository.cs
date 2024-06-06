using AutoMapper;
using conifs.rms.data.entities;
using conifs.rms.dto.ReservationGroup;
using conifs.rms.dto.ReservationItem;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace conifs.rms.data.repositories.ReservationItems
{
    public class ReservationItemRepository : IReservationItemRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ReservationItemRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ReservationItemDto>> GetReservationItem()
        {
            try
            {
                var items = await _context.ReservationItems.ToListAsync();
                return _mapper.Map<List<ReservationItemDto>>(items);
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception($"Error getting reservation items: {ex.Message}", ex);
            }
        }

        public async Task<ReservationItemDto> GetReservationItemById(Guid id)
        {
            try
            {
                var items = await _context.ReservationItems.FindAsync(id);
                return _mapper.Map<ReservationItemDto>(items);
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception($"Error getting reservation item by id: {ex.Message}", ex);
            }
        }

        public async Task AddReservationItem(ReservationItemDto item)
        {
            try
            {
                var reservationItem = _mapper.Map<ReservationItem>(item);

                
                _context.ReservationItems.Add(reservationItem);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception($"Error adding reservation item: {ex.Message}", ex);
            }
        }


        public async Task UpdateReservationItem(ReservationItemDto updatedItem)
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

                _context.Entry(item).State = EntityState.Modified;
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
