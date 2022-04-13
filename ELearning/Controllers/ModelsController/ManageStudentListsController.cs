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
    public class ManageStudentListsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ManageStudentListsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ManageStudentLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ManageStudentList>>> GetManageStudentLists()
        {
            return await _context.ManageStudentLists.ToListAsync();
        }

        // GET: api/ManageStudentLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ManageStudentList>> GetManageStudentList(Guid id)
        {
            var manageStudentList = await _context.ManageStudentLists.FindAsync(id);

            if (manageStudentList == null)
            {
                return NotFound();
            }

            return manageStudentList;
        }

        // PUT: api/ManageStudentLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManageStudentList(Guid id, ManageStudentList manageStudentList)
        {
            if (id != manageStudentList.ID)
            {
                return BadRequest();
            }

            _context.Entry(manageStudentList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManageStudentListExists(id))
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

        // POST: api/ManageStudentLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ManageStudentList>> PostManageStudentList(ManageStudentList manageStudentList)
        {
            _context.ManageStudentLists.Add(manageStudentList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetManageStudentList", new { id = manageStudentList.ID }, manageStudentList);
        }

        // DELETE: api/ManageStudentLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManageStudentList(Guid id)
        {
            var manageStudentList = await _context.ManageStudentLists.FindAsync(id);
            if (manageStudentList == null)
            {
                return NotFound();
            }

            _context.ManageStudentLists.Remove(manageStudentList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ManageStudentListExists(Guid id)
        {
            return _context.ManageStudentLists.Any(e => e.ID == id);
        }
    }
}
