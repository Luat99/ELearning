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
    public class ManageTeachersListsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ManageTeachersListsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ManageTeachersLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ManageTeachersList>>> GetManageTeachersLists()
        {
            return await _context.ManageTeachersLists.ToListAsync();
        }

        // GET: api/ManageTeachersLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ManageTeachersList>> GetManageTeachersList(Guid id)
        {
            var manageTeachersList = await _context.ManageTeachersLists.FindAsync(id);

            if (manageTeachersList == null)
            {
                return NotFound();
            }

            return manageTeachersList;
        }

        // PUT: api/ManageTeachersLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManageTeachersList(Guid id, ManageTeachersList manageTeachersList)
        {
            if (id != manageTeachersList.ID)
            {
                return BadRequest();
            }

            _context.Entry(manageTeachersList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManageTeachersListExists(id))
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

        // POST: api/ManageTeachersLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ManageTeachersList>> PostManageTeachersList(ManageTeachersList manageTeachersList)
        {
            _context.ManageTeachersLists.Add(manageTeachersList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetManageTeachersList", new { id = manageTeachersList.ID }, manageTeachersList);
        }

        // DELETE: api/ManageTeachersLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManageTeachersList(Guid id)
        {
            var manageTeachersList = await _context.ManageTeachersLists.FindAsync(id);
            if (manageTeachersList == null)
            {
                return NotFound();
            }

            _context.ManageTeachersLists.Remove(manageTeachersList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ManageTeachersListExists(Guid id)
        {
            return _context.ManageTeachersLists.Any(e => e.ID == id);
        }
    }
}
