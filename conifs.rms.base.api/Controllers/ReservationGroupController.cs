using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using conifs.rms.data.entities;
using conifs.rms.data;
using Microsoft.EntityFrameworkCore;

namespace conifs.rms.@base.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationGroupController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReservationGroupController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<ReservationGroup>>> GetAllGroups()
        {
            var groups = await _context.ReservationGroups.ToListAsync();
            return Ok(groups);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<ReservationGroup>>> GetGroup(Guid id)
        {
            var group = await _context.ReservationGroups.FindAsync(id);
            if (group == null)
            {
                return NotFound("group not found");
            }
            return Ok(group);
        }

        [HttpPost]
        public async Task<ActionResult<List<ReservationGroup>>> AddGroup(ReservationGroup grp)
        {
            _context.ReservationGroups.Add(grp);
            await _context.SaveChangesAsync();

            return Ok(await _context.ReservationGroups.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<ReservationGroup>>> UpdateGroup(ReservationGroup UpdatedGroup)
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

        [HttpDelete]
        public async Task<ActionResult<List<ReservationGroup>>> DeleteGroup(Guid id)
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
    }
}

