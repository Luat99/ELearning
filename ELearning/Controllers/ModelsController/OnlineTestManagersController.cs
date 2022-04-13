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
    public class OnlineTestManagersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OnlineTestManagersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/OnlineTestManagers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OnlineTestManager>>> GetOnlineTestManagers()
        {
            return await _context.OnlineTestManagers.ToListAsync();
        }

        // GET: api/OnlineTestManagers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OnlineTestManager>> GetOnlineTestManager(Guid id)
        {
            var onlineTestManager = await _context.OnlineTestManagers.FindAsync(id);

            if (onlineTestManager == null)
            {
                return NotFound();
            }

            return onlineTestManager;
        }

        // PUT: api/OnlineTestManagers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOnlineTestManager(Guid id, OnlineTestManager onlineTestManager)
        {
            if (id != onlineTestManager.ID)
            {
                return BadRequest();
            }

            _context.Entry(onlineTestManager).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OnlineTestManagerExists(id))
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

        // POST: api/OnlineTestManagers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OnlineTestManager>> PostOnlineTestManager(OnlineTestManager onlineTestManager)
        {
            _context.OnlineTestManagers.Add(onlineTestManager);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOnlineTestManager", new { id = onlineTestManager.ID }, onlineTestManager);
        }

        // DELETE: api/OnlineTestManagers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOnlineTestManager(Guid id)
        {
            var onlineTestManager = await _context.OnlineTestManagers.FindAsync(id);
            if (onlineTestManager == null)
            {
                return NotFound();
            }

            _context.OnlineTestManagers.Remove(onlineTestManager);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OnlineTestManagerExists(Guid id)
        {
            return _context.OnlineTestManagers.Any(e => e.ID == id);
        }
    }
}
