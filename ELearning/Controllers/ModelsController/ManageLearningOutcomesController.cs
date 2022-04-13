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
    public class ManageLearningOutcomesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ManageLearningOutcomesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ManageLearningOutcomes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ManageLearningOutcomes>>> GetManageLearningOutcomess()
        {
            return await _context.ManageLearningOutcomess.ToListAsync();
        }

        // GET: api/ManageLearningOutcomes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ManageLearningOutcomes>> GetManageLearningOutcomes(Guid id)
        {
            var manageLearningOutcomes = await _context.ManageLearningOutcomess.FindAsync(id);

            if (manageLearningOutcomes == null)
            {
                return NotFound();
            }

            return manageLearningOutcomes;
        }

        // PUT: api/ManageLearningOutcomes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManageLearningOutcomes(Guid id, ManageLearningOutcomes manageLearningOutcomes)
        {
            if (id != manageLearningOutcomes.ID)
            {
                return BadRequest();
            }

            _context.Entry(manageLearningOutcomes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManageLearningOutcomesExists(id))
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

        // POST: api/ManageLearningOutcomes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ManageLearningOutcomes>> PostManageLearningOutcomes(ManageLearningOutcomes manageLearningOutcomes)
        {
            _context.ManageLearningOutcomess.Add(manageLearningOutcomes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetManageLearningOutcomes", new { id = manageLearningOutcomes.ID }, manageLearningOutcomes);
        }

        // DELETE: api/ManageLearningOutcomes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManageLearningOutcomes(Guid id)
        {
            var manageLearningOutcomes = await _context.ManageLearningOutcomess.FindAsync(id);
            if (manageLearningOutcomes == null)
            {
                return NotFound();
            }

            _context.ManageLearningOutcomess.Remove(manageLearningOutcomes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ManageLearningOutcomesExists(Guid id)
        {
            return _context.ManageLearningOutcomess.Any(e => e.ID == id);
        }
    }
}
