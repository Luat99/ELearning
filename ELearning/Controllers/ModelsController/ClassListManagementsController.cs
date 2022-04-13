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
    public class ClassListManagementsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ClassListManagementsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ClassListManagements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassListManagement>>> GetClassListManagements()
        {
            return await _context.ClassListManagements.ToListAsync();
        }

        // GET: api/ClassListManagements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClassListManagement>> GetClassListManagement(Guid id)
        {
            var classListManagement = await _context.ClassListManagements.FindAsync(id);

            if (classListManagement == null)
            {
                return NotFound();
            }

            return classListManagement;
        }

        // PUT: api/ClassListManagements/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClassListManagement(Guid id, ClassListManagement classListManagement)
        {
            if (id != classListManagement.ID)
            {
                return BadRequest();
            }

            _context.Entry(classListManagement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassListManagementExists(id))
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

        // POST: api/ClassListManagements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClassListManagement>> PostClassListManagement(ClassListManagement classListManagement)
        {
            _context.ClassListManagements.Add(classListManagement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClassListManagement", new { id = classListManagement.ID }, classListManagement);
        }

        // DELETE: api/ClassListManagements/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClassListManagement(Guid id)
        {
            var classListManagement = await _context.ClassListManagements.FindAsync(id);
            if (classListManagement == null)
            {
                return NotFound();
            }

            _context.ClassListManagements.Remove(classListManagement);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClassListManagementExists(Guid id)
        {
            return _context.ClassListManagements.Any(e => e.ID == id);
        }
    }
}
