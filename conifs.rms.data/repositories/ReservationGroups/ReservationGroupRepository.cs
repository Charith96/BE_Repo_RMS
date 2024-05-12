using conifs.rms.data.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
namespace conifs.rms.data.repositories.ReservationGroups
{
    public class ReservationGroupRepository : ControllerBase,IReservationGroupRepository
    {
        private readonly ApplicationDbContext _context;

        public ReservationGroupRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ReservationGroup>>> GetReservationGroup()
        {
            try
            {
                var groups = await _context.ReservationGroups.ToListAsync();
                return Ok(groups);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        
        public async Task<ActionResult<List<ReservationGroup>>> GetReservationGroupById(Guid id)
        {
            try
            {
                var group = await _context.ReservationGroups.FindAsync(id);
                if (group == null)
                {
                    return NotFound("group not found");
                }
                return Ok(group);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        
        public async Task<ActionResult<List<ReservationGroup>>> AddReservationGroup(ReservationGroup group)
        {
            try
            {
                _context.ReservationGroups.Add(group);
                await _context.SaveChangesAsync();
                return Ok(await _context.ReservationGroups.ToListAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        
        public async Task<ActionResult<List<ReservationGroup>>> UpdateReservationGroup(ReservationGroup UpdatedGroup)
        {
            try
            {
                var group = await _context.ReservationGroups.FindAsync(UpdatedGroup.id);
                if (group == null)
                {
                    return NotFound("group not found");
                }
                group.groupName = UpdatedGroup.groupName;
                await _context.SaveChangesAsync();
                return Ok(await _context.ReservationGroups.ToListAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        
        public async Task<ActionResult<List<ReservationGroup>>> DeleteReservationGroup(Guid id)
        {
            try
            {
                var group = await _context.ReservationGroups.FindAsync(id);
                if (group == null)
                {
                    return NotFound("group not found");
                }
                _context.ReservationGroups.Remove(group);
                await _context.SaveChangesAsync();
                return Ok(await _context.ReservationGroups.ToListAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
