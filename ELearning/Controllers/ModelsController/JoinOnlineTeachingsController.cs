#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ELearning.DataContext;
using ELearning.Models;
using Microsoft.AspNetCore.Authorization;

namespace ELearning.Controllers.ModelsController
{
    [Authorize(Roles = "Admin,Administrators,Teacher,Students")]

    [Route("api/[controller]")]
    [ApiController]
    public class JoinOnlineTeachingsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public JoinOnlineTeachingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/JoinOnlineTeachings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JoinOnlineTeaching>>> GetJoinOnlineTeachings()
        {
            return await _context.JoinOnlineTeachings.ToListAsync();
        }

        // GET: api/JoinOnlineTeachings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JoinOnlineTeaching>> GetJoinOnlineTeaching(Guid id)
        {
            var joinOnlineTeaching = await _context.JoinOnlineTeachings.FindAsync(id);

            if (joinOnlineTeaching == null)
            {
                return NotFound();
            }

            return joinOnlineTeaching;
        }

        // PUT: api/JoinOnlineTeachings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJoinOnlineTeaching(Guid id, JoinOnlineTeaching joinOnlineTeaching)
        {
            if (id != joinOnlineTeaching.ID)
            {
                return BadRequest();
            }

            _context.Entry(joinOnlineTeaching).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JoinOnlineTeachingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/JoinOnlineTeachings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<JoinOnlineTeaching>> PostJoinOnlineTeaching(JoinOnlineTeaching joinOnlineTeaching)
        {
            _context.JoinOnlineTeachings.Add(joinOnlineTeaching);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJoinOnlineTeaching", new { id = joinOnlineTeaching.ID }, joinOnlineTeaching);
        }

        // DELETE: api/JoinOnlineTeachings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJoinOnlineTeaching(Guid id)
        {
            var joinOnlineTeaching = await _context.JoinOnlineTeachings.FindAsync(id);
            if (joinOnlineTeaching == null)
            {
                return NotFound();
            }

            _context.JoinOnlineTeachings.Remove(joinOnlineTeaching);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JoinOnlineTeachingExists(Guid id)
        {
            return _context.JoinOnlineTeachings.Any(e => e.ID == id);
        }
    }
}
